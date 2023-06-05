using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace JOS.Enumeration.SourceGenerator;

internal static class StringExtensions
{
    internal static string FormatSource(this string source)
    {
        return CSharpSyntaxTree.ParseText(source).GetRoot().NormalizeWhitespace().SyntaxTree.GetText().ToString();
    }
}
