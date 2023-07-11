using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JOS.Enumeration.Database.EntityFrameworkCore;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> ConfigureEnumeration<TProperty>(
        this PropertyBuilder<TProperty> propertyBuilder) where TProperty : IEnumeration<TProperty>
    {
        return ConfigureEnumeration<int, TProperty>(propertyBuilder);
    }

    public static PropertyBuilder<TProperty> ConfigureEnumeration<TKey, TProperty>(
        this PropertyBuilder<TProperty> propertyBuilder)
        where TProperty : IEnumeration<TKey, TProperty> where TKey : IConvertible
    {
        return propertyBuilder.HasConversion(
            enumeration => enumeration.Value,
            value => FromValue<TKey, TProperty>(value));
    }

    private static TProperty FromValue<TKey, TProperty>(TKey value)
        where TProperty : IEnumeration<TKey, TProperty> where TKey : IConvertible
    {
        return TProperty.FromValue(value);
    }
}
