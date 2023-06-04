using System;
using System.Data;
using Dapper;

namespace JOS.Enumeration.Database;

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

        throw new NotImplementedException();
    }
}
