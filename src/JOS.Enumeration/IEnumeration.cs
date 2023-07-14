using System;
using System.Collections.Generic;

namespace JOS.Enumeration;

public interface IEnumeration<T> : IEnumeration<int, T> where T : IEnumeration<T>
{
}

public interface IEnumeration<TValue, TType> where TValue : IConvertible
{
    TValue Value { get; }
    string Description { get; }
    static abstract IReadOnlySet<TType> GetAll();
    static abstract IEnumerable<TType> GetEnumerable();
    static abstract TType FromValue(TValue value);
    static abstract TType FromDescription(string description);
    static abstract TType FromDescription(ReadOnlySpan<char> description);
    static abstract Type ValueType { get; }
}
