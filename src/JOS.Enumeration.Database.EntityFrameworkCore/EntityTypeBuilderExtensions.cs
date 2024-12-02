using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JOS.Enumeration.Database.EntityFrameworkCore;

public static class EntityTypeBuilderExtensions
{
    public static ElementTypeBuilder ConfigureEnumeration<TEntity, TProperty>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression)
        where TEntity : class where TProperty : IEnumeration<int, TProperty>
    {
        return ConfigureEnumeration<TEntity, int, TProperty>(builder, propertyExpression);
    }

    public static ElementTypeBuilder ConfigureEnumeration<TEntity, TValue, TProperty>(
        this EntityTypeBuilder<TEntity> builder,
        Expression<Func<TEntity, IEnumerable<TProperty>>> propertyExpression) where TEntity : class
        where TValue : IConvertible
        where TProperty : IEnumeration<TValue, TProperty>
    {
        return builder.PrimitiveCollection(propertyExpression)
                      .ElementType()
                      .HasConversion(new EnumerationConverter<TValue, TProperty>());
    }
}
