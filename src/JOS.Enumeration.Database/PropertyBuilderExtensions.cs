using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JOS.Enumeration.Database;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> ConfigureEnumeration<TProperty>(
        this PropertyBuilder<TProperty> propertyBuilder) where TProperty : IEnumeration<TProperty>
    {
        return propertyBuilder.HasConversion(
            enumeration => enumeration.Value,
            value => FromValue<TProperty>(value));
    }

    private static TProperty FromValue<TProperty>(int value) where TProperty : IEnumeration<TProperty>
    {
        return TProperty.FromValue(value);
    }
}
