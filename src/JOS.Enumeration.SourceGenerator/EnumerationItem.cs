using System;

namespace JOS.Enumeration.SourceGenerator;

internal class EnumerationItem
{
    internal EnumerationItem(object value, string description, string fieldName)
    {
        Value = value;
        Description = description ?? throw new ArgumentNullException(nameof(description));
        FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
    }

    public object Value { get; }
    public string Description { get; }
    public string FieldName { get; }
}
