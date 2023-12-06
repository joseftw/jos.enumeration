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

    public static PropertyBuilder<TProperty> ConfigureEnumeration<TValue, TProperty>(
        this PropertyBuilder<TProperty> propertyBuilder)
        where TProperty : IEnumeration<TValue, TProperty> where TValue : IConvertible
    {
        return propertyBuilder.HasConversion(new EnumerationConverter<TValue, TProperty>());
    }
}
