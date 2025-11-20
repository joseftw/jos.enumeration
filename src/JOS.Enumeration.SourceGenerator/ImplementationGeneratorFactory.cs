using System;

namespace JOS.Enumeration.SourceGenerator;

/// <summary>
/// Factory for creating the appropriate implementation generator based on the enumeration value type.
/// </summary>
internal static class ImplementationGeneratorFactory
{
    private static readonly StringImplementationGenerator StringGenerator = new();
    private static readonly DecimalImplementationGenerator DecimalGenerator = new();
    private static readonly BoolImplementationGenerator BoolGenerator = new();
    private static readonly DefaultImplementationGenerator DefaultGenerator = new();

    /// <summary>
    /// Gets the appropriate implementation generator for the specified value type.
    /// </summary>
    public static ImplementationGeneratorBase GetGenerator(EnumerationValue value)
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
