using System.Collections.Generic;

namespace JOS.Enumeration.SourceGenerator;

/// <summary>
/// Implementation generator for decimal-based enumeration values.
/// </summary>
internal class DecimalImplementationGenerator : ImplementationGeneratorBase
{
    public override string GenerateFromValueMethodBody(
        EnumerationValue value,
        IEnumerable<EnumerationItem> items,
        string symbolName)
    {
        var stringBuilder = CreateSwitchStart("value");

        foreach(var field in items)
        {
            var fieldValue = $"{field.Value}m";
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
            var fieldValue = $"{field.Value}m";
            AppendSwitchCase(stringBuilder, fieldValue, field.FieldName);
        }

        return CloseSwitchWithNull(stringBuilder);
    }
}
