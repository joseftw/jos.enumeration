using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JOS.Enumeration.SourceGenerator;

internal static class EnumerationHelpers
{
    internal static IncrementalValueProvider<ImmutableArray<TypeDeclarationSyntax>> GetImplementations(
        IncrementalGeneratorInitializationContext context)
    {
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

    private static TypeDeclarationSyntax? Transform(GeneratorSyntaxContext context)
    {
        var typeDeclarationSyntax = (TypeDeclarationSyntax) context.Node;
        var symbol = context.SemanticModel.GetDeclaredSymbol(typeDeclarationSyntax);

        if (symbol?.BaseType == null)
        {
            return null;
        }

        return symbol.ImplementsIEnumeration() ? typeDeclarationSyntax : null;
    }
}
