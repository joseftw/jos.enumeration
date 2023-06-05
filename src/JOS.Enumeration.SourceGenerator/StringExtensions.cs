using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace JOS.Enumeration.SourceGenerator;

internal static class StringExtensions
{
    internal static string FormatSource(this string source)
    {
#if DEBUG
        source = CSharpSyntaxTree.ParseText(source).GetRoot().NormalizeWhitespace().SyntaxTree.GetText().ToString();
#endif
        return source;
    }
}
