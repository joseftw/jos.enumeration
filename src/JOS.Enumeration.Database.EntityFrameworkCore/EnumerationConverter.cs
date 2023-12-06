using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace JOS.Enumeration.Database.EntityFrameworkCore;

public class EnumerationConverter<TEnumeration> : EnumerationConverter<int, TEnumeration>
    where TEnumeration : IEnumeration<int, TEnumeration>;

public class EnumerationConverter<TValue, TEnumeration> :
    ValueConverter<TEnumeration, TValue> where TEnumeration : IEnumeration<TValue, TEnumeration> where TValue : IConvertible
{
    public EnumerationConverter() : base(x => x.Value,  x => FromValue(x))
    {
    }

    public static TEnumeration FromValue(TValue value)
    {
        return TEnumeration.FromValue(value);
    }
}
