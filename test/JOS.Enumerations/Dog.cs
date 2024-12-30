using JOS.Enumeration;
using System;
using System.Collections.Generic;

namespace JOS.Enumerations;

public partial class Dog : IEnumeration<string, Dog>
{
    public static readonly Dog Pug = new("pug", "Lovely dog");
    public static readonly Dog Bulldog = new("bulldog", "Adorable", 10);

    public int Age { get; }

    public string Value => throw new NotImplementedException();

    public string Description => throw new NotImplementedException();

    public static Type ValueType => throw new NotImplementedException();

    private Dog(string value, string description) : this(value, description, 0)
    {
    }

    private Dog(string value, string description, int age)
    {
        Value = value;
        Description = description;
        Age = age;
    }

    public static IReadOnlySet<Dog> GetAll()
    {
        throw new NotImplementedException();
    }

    public static IEnumerable<Dog> GetEnumerable()
    {
        throw new NotImplementedException();
    }

    public static Dog FromValue(string value)
    {
        throw new NotImplementedException();
    }

    public static Dog FromDescription(string description)
    {
        throw new NotImplementedException();
    }

    public static Dog FromDescription(ReadOnlySpan<char> description)
    {
        throw new NotImplementedException();
    }
}
