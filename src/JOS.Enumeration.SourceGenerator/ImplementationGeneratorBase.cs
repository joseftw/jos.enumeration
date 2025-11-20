using System.Collections.Generic;
using System.Text;

namespace JOS.Enumeration.SourceGenerator;

/// <summary>
/// Base class for implementation generators with common functionality.
/// </summary>
internal abstract class ImplementationGeneratorBase
{
    public abstract string GenerateFromValueMethodBody(
        EnumerationValue value,
        IEnumerable<EnumerationItem> items,
        string symbolName);

    public abstract string GenerateFromValueOutMethodBody(
        EnumerationValue value,
        IEnumerable<EnumerationItem> items);

    public abstract string GenerateTryParseMethodBody(
        EnumerationValue enumeration,
        string? formatProvider);

    protected static string FormatFieldValue(object fieldValue)
    {
        if(fieldValue is bool)
        {
            return fieldValue.ToString()!.ToLower();
        }
        return fieldValue.ToString()!;
    }

    protected static StringBuilder CreateSwitchStart(string variableName)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"return {variableName} switch");
        stringBuilder.AppendLine("{");
        return stringBuilder;
    }

    protected static StringBuilder CreateOutSwitchStart()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("result = value switch");
        stringBuilder.AppendLine("{");
        return stringBuilder;
    }

    protected static void AppendSwitchCase(StringBuilder stringBuilder, string fieldValue, string fieldName)
    {
        stringBuilder.AppendLine($"{fieldValue} => {fieldName},");
    }

    protected static string CloseSwitchWithThrow(StringBuilder stringBuilder, string symbolName)
    {
        stringBuilder.AppendLine(
            $"_ => throw new InvalidOperationException($\"'{{value}}' is not a valid value in '{symbolName}'\")");
        stringBuilder.AppendLine("};");
        return stringBuilder.ToString();
    }

    protected static string CloseSwitchWithNull(StringBuilder stringBuilder)
    {
        stringBuilder.AppendLine("_ => null!");
        stringBuilder.AppendLine("};");
        stringBuilder.Append("return result is not null;");
        return stringBuilder.ToString();
    }
}
