using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Immutable;
using System.Linq;

namespace JOS.Enumeration.SourceGenerator;

internal static class EnumerationHelpers
{
    internal static IncrementalValueProvider<ImmutableArray<EnumerationImplementation>> GetImplementations(
        IncrementalGeneratorInitializationContext context)
    {
#if DEBUG
        System.Diagnostics.Debugger.Launch();
#endif
        var declarations = context.SyntaxProvider
                                  .CreateSyntaxProvider(
                                      predicate: static (node, _) => Predicate(node),
                                      transform: static (context, _) => Transform(context))
                                  .Where(static m => m is not null);
        return declarations.Collect()!;
    }

    private static bool Predicate(SyntaxNode node)
    {
        return node is TypeDeclarationSyntax typeDeclarationSyntax &&
               typeDeclarationSyntax.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword));
    }

    private static EnumerationImplementation? Transform(GeneratorSyntaxContext context)
    {
        var typeDeclarationSyntax = (TypeDeclarationSyntax)context.Node;
        var symbol = context.SemanticModel.GetDeclaredSymbol(typeDeclarationSyntax);

        if(symbol?.BaseType == null)
        {
            return null;
        }

        if(!symbol.ImplementsIEnumeration())
        {
            return null;
        }

        var @namespace = symbol.ContainingNamespace.ToString() ?? string.Empty;
        var typeSymbol = (ITypeSymbol)symbol;
        var enumerationInterface =
            typeSymbol.AllInterfaces.Single(x => x is { Name: "IEnumeration", TypeArguments.Length: 2 });
        var fieldDeclarationSyntaxes =
            typeDeclarationSyntax.GetFields(context.SemanticModel, typeSymbol).ToList();
        var items =
            SourceGenerationHelpers.ExtractEnumerationItems(fieldDeclarationSyntaxes).WithoutDuplicates();
        var value = enumerationInterface.TypeArguments.First();
        var hasDeclaredConstructor = typeSymbol.GetMembers()
                  .OfType<IMethodSymbol>()
                  .Any(methodSymbol =>
                      methodSymbol.MethodKind == MethodKind.Constructor &&
                      methodSymbol.Parameters.Length == 2 &&
                      methodSymbol.Parameters[0].Type.SpecialType == value.SpecialType &&
                      methodSymbol.Parameters[1].Type.SpecialType == SpecialType.System_String);
        var userDefinedMethods =
            typeSymbol.GetMembers()
                      .Where(x => x is IMethodSymbol
                      {
                          MethodKind: not (MethodKind.Constructor or MethodKind.StaticConstructor)
                      })
                      .Cast<IMethodSymbol>()
                      .Select(x =>
                      {
                          var parameters = x.Parameters;
                          if(!parameters.Any())
                          {
                              return $"{x.Name}()";
                          }

                          var parametersString = string.Join(",", x.Parameters.Select(p => p.ToString()));
                          return string.Concat($"{x.Name}(", parametersString, ")");
                      })
                      .ToImmutableHashSet();
        var keyword = typeDeclarationSyntax.Keyword.Value;
        var keywordType = typeDeclarationSyntax switch
        {
            RecordDeclarationSyntax => KeywordType.Record,
            ClassDeclarationSyntax => KeywordType.Class,
            _ => throw new ArgumentException($"{typeDeclarationSyntax} is not supported")
        };
        return new EnumerationImplementation(
            new EnumerationValue(
                value.Name,
                value.ToString(),
                value.OriginalDefinition.ToString()!),
            items,
            userDefinedMethods,
            keywordType,
            new Symbol(symbol.ToString()!, symbol.MetadataName),
            hasDeclaredConstructor,
            keyword!.ToString(),
            typeDeclarationSyntax.Modifiers.ToString(),
            @namespace);
    }
}
