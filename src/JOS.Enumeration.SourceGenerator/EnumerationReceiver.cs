using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JOS.Enumeration.SourceGenerator;

internal class EnumerationReceiver : ISyntaxContextReceiver
{
    internal EnumerationReceiver()
    {
        EnumerationImplementations = new List<INamedTypeSymbol>();
    }

    internal List<INamedTypeSymbol> EnumerationImplementations { get; }

    public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
    {
        if (context.Node is not RecordDeclarationSyntax recordDeclarationSyntax)
        {
            return;
        }

        if (ModelExtensions.GetDeclaredSymbol(
                context.SemanticModel, recordDeclarationSyntax) is not INamedTypeSymbol classSymbol)
        {
            return;
        }

        if (classSymbol.BaseType == null)
        {
            return;
        }

        var constructedFrom = classSymbol.BaseType.ConstructedFrom.ToString();
        if (constructedFrom == "JOS.Enumeration.Enumeration<T>"
            && recordDeclarationSyntax.Modifiers.Any(x => x.IsKind(SyntaxKind.PartialKeyword)))
        {
            EnumerationImplementations.Add(classSymbol);
        }
    }
}
