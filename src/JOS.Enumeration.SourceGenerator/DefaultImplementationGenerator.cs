using System.Collections.Generic;

namespace JOS.Enumeration.SourceGenerator;

/// <summary>
/// Default implementation generator for numeric and other enumeration value types (int, long, uint, ulong, etc.).
/// </summary>
internal class DefaultImplementationGenerator : ImplementationGeneratorBase
{
    public override string GenerateFromValueMethodBody(
        EnumerationValue value,
        IEnumerable<EnumerationItem> items,
        string symbolName)
    {
        var stringBuilder = CreateSwitchStart("value");

        foreach(var field in items)
        {
            var fieldValue = FormatFieldValue(field.Value);
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
            var fieldValue = FormatFieldValue(field.Value);
            AppendSwitchCase(stringBuilder, fieldValue, field.FieldName);
        }

        return CloseSwitchWithNull(stringBuilder);
    }

    public override string GenerateTryParseMethodBody(
        EnumerationValue enumeration,
        string? formatProvider)
    {
        return
        $$"""
        try
        {
            var convertedValue =
                ({{enumeration.ValueType}})Convert.ChangeType(value, typeof({{enumeration.ValueType}}), {{formatProvider}});
            return FromValue(convertedValue, out result);
        }
        catch
        {
            result = null;
            return false;
        }
        """;
    }
}
