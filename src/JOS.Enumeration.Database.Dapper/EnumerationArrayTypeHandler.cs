using Dapper;
using System;
using System.Data;
using System.Linq;

namespace JOS.Enumeration.Database.Dapper;

public class EnumerationArrayTypeHandler<T> : EnumerationTypeHandler<int, T> where T : IEnumeration<int, T>;

public class EnumerationArrayTypeHandler<TValue, T> :
    SqlMapper.TypeHandler<T[]> where T : IEnumeration<TValue, T> where TValue : IConvertible
{
    public override void SetValue(IDbDataParameter parameter, T[] value)
    {
        parameter.Value = value.Select(x => x.Value).ToArray();
    }

    public override T[] Parse(object value)
    {
        var values = (TValue[])value;
        return values.Select(T.FromValue).ToArray();
    }
}
