using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JOS.Enumeration.Database;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<TProperty> ConfigureEnumeration<TProperty>(
        this PropertyBuilder<TProperty> propertyBuilder) where TProperty : IEnumeration<TProperty>
    {
        throw new NotImplementedException();
        // return propertyBuilder.HasConversion(
        //     enumeration => enumeration.Value, value => Enumeration<TProperty>.FromValue(value));
    }
}
