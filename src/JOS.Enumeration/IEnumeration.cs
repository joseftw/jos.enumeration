using System.Collections.Generic;

namespace JOS.Enumeration;

public interface IEnumeration<T>
{
    int Value { get; }
    string DisplayName { get; }
    static abstract IReadOnlySet<T> GetAll();
    static abstract IEnumerable<T> GetEnumerable();
    static abstract T FromValue(int value);
    static abstract T FromDisplayName(string displayName);
}
