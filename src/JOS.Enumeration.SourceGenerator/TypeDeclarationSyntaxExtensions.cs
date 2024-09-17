using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace JOS.Enumeration.SourceGenerator;

internal static class TypeDeclarationSyntaxExtensions
{
    internal static IEnumerable<FieldDeclarationSyntax> GetFields(
        this TypeDeclarationSyntax typeDeclarationSyntax, SemanticModel semanticModel, ITypeSymbol typeSymbol)
    {
        return typeDeclarationSyntax.Members.OfType<FieldDeclarationSyntax>()
                             .Where(field =>
                                 field.Modifiers.Any(SyntaxKind.StaticKeyword) &&
                                 field.Modifiers.Any(SyntaxKind.ReadOnlyKeyword))
                             .Where(field =>
                             {
                                 var fieldSymbol =
                                     semanticModel.GetDeclaredSymbol(field.Declaration.Variables.First()) as
                                         IFieldSymbol;
                                 return SymbolEqualityComparer.Default.Equals(fieldSymbol?.Type, typeSymbol);
                             });
    }
}
