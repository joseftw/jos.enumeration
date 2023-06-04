using System;

namespace JOS.Enumeration.SourceGenerator;

internal class EnumerationItem
{
    internal EnumerationItem(int value, string displayName, string fieldName)
    {
        Value = value;
        DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
        FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
    }

    public int Value { get; }
    public string DisplayName { get; }
    public string FieldName { get; }
}
