using System.Collections.Generic;

namespace JOS.Enumeration;

public interface IEnumeration<out T>
{
    int Value { get; }
    string DisplayName { get; }
    static abstract IReadOnlyCollection<T> GetAll();
    static abstract IEnumerable<T> GetEnumerable();
    static abstract T FromValue(int value);
    static abstract T FromDisplayName(string displayName);
}
