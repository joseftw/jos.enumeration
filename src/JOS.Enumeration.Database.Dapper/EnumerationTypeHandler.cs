using Dapper;
using System;
using System.Data;

namespace JOS.Enumeration.Database.Dapper;

public class EnumerationTypeHandler<TEnumeration>
    : EnumerationTypeHandler<int, TEnumeration> where TEnumeration : IEnumeration<int, TEnumeration>;

public class EnumerationTypeHandler<TKey, TEnumeration> :
    SqlMapper.TypeHandler<TEnumeration>
    where TEnumeration : IEnumeration<TKey, TEnumeration>
    where TKey : IConvertible
{
    public override void SetValue(IDbDataParameter parameter, TEnumeration value)
    {
        parameter.Value = value.Value;
    }

    public override TEnumeration Parse(object value)
    {
        return TEnumeration.FromValue((TKey)value);
    }
}
