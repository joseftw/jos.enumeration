using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JOS.Enumeration.SourceGenerator;

internal static class EnumerationHelpers
{
    internal static IncrementalValueProvider<ImmutableArray<RecordDeclarationSyntax>> GetEnumerationRecordDeclarations(
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
        return node is RecordDeclarationSyntax recordDeclarationSyntax &&
               recordDeclarationSyntax.Modifiers.Any(modifier => modifier.IsKind(SyntaxKind.PartialKeyword));
    }

    private static RecordDeclarationSyntax? Transform(GeneratorSyntaxContext context)
    {
        var recordDeclarationSyntax = (RecordDeclarationSyntax) context.Node;
        var classSymbol = context.SemanticModel.GetDeclaredSymbol(recordDeclarationSyntax);

        if (classSymbol?.BaseType == null)
        {
            return null;
        }

        var implementsIEnumeration = classSymbol.Interfaces.Any(
            x => x.ContainingNamespace.ToString() == "JOS.Enumeration" && x.Name == "IEnumeration");
        return implementsIEnumeration ? recordDeclarationSyntax : null;
    }
}
