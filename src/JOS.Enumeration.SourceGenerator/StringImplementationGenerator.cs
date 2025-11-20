using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Generic;

namespace JOS.Enumeration.SourceGenerator;

/// <summary>
/// Implementation generator for string-based enumeration values.
/// </summary>
internal class StringImplementationGenerator : ImplementationGeneratorBase
{
    public override string GenerateFromValueMethodBody(
        EnumerationValue value,
        IEnumerable<EnumerationItem> items,
        string symbolName)
    {
        var stringBuilder = CreateSwitchStart("value");

        foreach(var field in items)
        {
            var fieldValue = WrapValueInQuotes(field.Value);
            AppendSwitchCase(stringBuilder, fieldValue, field.FieldName);
        }

        return CloseSwitchWithThrow(stringBuilder, symbolName);
    }

    public override string GenerateFromValueOutMethodBody(
        EnumerationValue value,
        IEnumerable<EnumerationItem> items)
    {
        var stringBuilder = CreateOutSwitchStart();

        foreach(var field in items)
        {
            var fieldValue = WrapValueInQuotes(field.Value);
            AppendSwitchCase(stringBuilder, fieldValue, field.FieldName);
        }

        return CloseSwitchWithNull(stringBuilder);
    }

    public override string GenerateTryParseMethodBody(
        EnumerationValue enumeration,
        string? formatProvider)
    {
        return "return FromValue(value, out result);";
    }

    private static string WrapValueInQuotes(object value)
    {
        return SyntaxFactory.Literal(value.ToString()).ToString();
    }
}
