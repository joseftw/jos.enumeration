using System.Collections.Generic;

namespace JOS.Enumeration.SourceGenerator;

/// <summary>
/// Implementation generator for bool-based enumeration values.
/// </summary>
internal class BoolImplementationGenerator : ImplementationGeneratorBase
{
    public override string GenerateFromValueMethodBody(
        EnumerationValue value,
        IEnumerable<EnumerationItem> items,
        string symbolName)
    {
        var stringBuilder = CreateSwitchStart("value");

        foreach(var field in items)
        {
            var fieldValue = FormatBoolValue(field.Value);
            AppendSwitchCase(stringBuilder, fieldValue, field.FieldName);
        }

        // Bool enumerations don't need a default throw case since bool only has two values
        stringBuilder.AppendLine("};");
        return stringBuilder.ToString();
    }

    public override string GenerateFromValueOutMethodBody(
        EnumerationValue value,
        IEnumerable<EnumerationItem> items)
    {
        var stringBuilder = CreateOutSwitchStart();

        foreach(var field in items)
        {
            var fieldValue = FormatBoolValue(field.Value);
            AppendSwitchCase(stringBuilder, fieldValue, field.FieldName);
        }

        // Bool enumerations don't need a default null case since bool only has two values
        stringBuilder.AppendLine("};");
        stringBuilder.Append("return result is not null;");
        return stringBuilder.ToString();
    }

    private static string FormatBoolValue(object fieldValue)
    {
        return fieldValue.ToString()!.ToLower();
    }
}
