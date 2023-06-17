using Dapper;
using System;
using System.Data;

namespace JOS.Enumeration.Database.Dapper;

public class EnumerationTypeHandler<T> : SqlMapper.TypeHandler<T> where T : IEnumeration<T>
{
    public override void SetValue(IDbDataParameter parameter, T value)
    {
        parameter.Value = value.Value;
    }

    public override T Parse(object value)
    {
        if(!int.TryParse(value.ToString(), out var intValue))
        {
            throw new ArgumentException($"Could not convert {value} to int", nameof(value));
        }

        return T.FromValue(intValue);
    }
}
