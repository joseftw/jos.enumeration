using Microsoft.CodeAnalysis;
using System.Linq;

namespace JOS.Enumeration.SourceGenerator;

internal static class INamedTypeSymbolExtensions
{
    internal static bool ImplementsIEnumeration(this INamedTypeSymbol symbol)
    {
        return symbol.Interfaces.Any(
            x => x.ContainingNamespace.ToString() == "JOS.Enumeration" && x.Name == "IEnumeration");
    }
}
