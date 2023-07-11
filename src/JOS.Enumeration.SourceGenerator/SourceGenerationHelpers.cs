using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace JOS.Enumeration.SourceGenerator;

internal static class SourceGenerationHelpers
{
    internal const string AutoGenerated = """
    // <auto-generated>
    //     This code was auto generated by JOS.Enumeration.SourceGenerator
    // </auto-generated>
    """;

    internal const string Nullable = "#nullable enable";

    internal static IReadOnlyCollection<EnumerationItem> ExtractEnumerationItems(
        IReadOnlyCollection<FieldDeclarationSyntax> fields)
    {
        var items = new List<EnumerationItem>(fields.Count);
        foreach(var field in fields)
        {
            var variable = field.Declaration.Variables.First();
            var objectCreationExpression = (BaseObjectCreationExpressionSyntax)variable.Initializer!.Value;
            var arguments = objectCreationExpression.ArgumentList!.Arguments;
            var value = ((LiteralExpressionSyntax)arguments[0].Expression).Token.Value!;
            var displayName = (string)((LiteralExpressionSyntax)arguments[1].Expression).Token.Value!;
            var fieldName = variable.Identifier.Value!.ToString();
            items.Add(new EnumerationItem(value, displayName, fieldName));
        }

        return items;
    }
}
