using JOS.Enumeration.Record;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JOS.Enumeration.Database;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> ConfigureEnumeration<TProperty>(
        this PropertyBuilder<TProperty> propertyBuilder) where TProperty : Enumeration<TProperty>
    {
        return propertyBuilder.HasConversion(
            enumeration => enumeration.Value, value => Enumeration<TProperty>.FromValue(value));
    }
}