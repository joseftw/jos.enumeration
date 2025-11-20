using System;

namespace JOS.Enumeration.SourceGenerator;

/// <summary>
/// Factory for creating the appropriate value type code generator based on the enumeration value type.
/// </summary>
internal static class ValueTypeCodeGeneratorFactory
{
    private static readonly StringValueTypeCodeGenerator StringGenerator = new();
    private static readonly DecimalValueTypeCodeGenerator DecimalGenerator = new();
    private static readonly BoolValueTypeCodeGenerator BoolGenerator = new();
    private static readonly DefaultValueTypeCodeGenerator DefaultGenerator = new();

    /// <summary>
    /// Gets the appropriate code generator for the specified value type.
    /// </summary>
    public static IValueTypeCodeGenerator GetGenerator(EnumerationValue value)
    {
        return value.ValueType.ToLowerInvariant() switch
        {
            "string" => StringGenerator,
            "decimal" => DecimalGenerator,
            "bool" => BoolGenerator,
            _ => DefaultGenerator
        };
    }
}
