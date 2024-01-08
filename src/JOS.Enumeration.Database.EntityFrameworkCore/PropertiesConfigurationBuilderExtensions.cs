using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JOS.Enumeration.Database.EntityFrameworkCore;

public static class PropertiesConfigurationBuilderExtensions
{
    public static PropertiesConfigurationBuilder<TProperty> ConfigureEnumeration<TProperty>(
        this PropertiesConfigurationBuilder<TProperty> propertyBuilder) where TProperty : IEnumeration<TProperty>
    {
        return ConfigureEnumeration<int, TProperty>(propertyBuilder);
    }

    public static PropertiesConfigurationBuilder<TProperty> ConfigureEnumeration<TValue, TProperty>(
        this PropertiesConfigurationBuilder<TProperty> propertyBuilder)
        where TProperty : IEnumeration<TValue, TProperty> where TValue : IConvertible
    {
        return propertyBuilder.HaveConversion(typeof(EnumerationConverter<TValue, TProperty>));
    }
}
