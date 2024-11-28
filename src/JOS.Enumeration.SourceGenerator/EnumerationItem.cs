using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;

namespace JOS.Enumeration.SourceGenerator;

internal record EnumerationItem
{
    internal EnumerationItem(
        object value, string description, string fieldName, SyntaxTree syntaxTree, TextSpan textSpan)
    {
        Value = value;
        Description = description ?? throw new ArgumentNullException(nameof(description));
        FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
        SyntaxTree = syntaxTree;
        TextSpan = textSpan;
    }

    public object Value { get; }
    public string Description { get; }
    public string FieldName { get; }
    public SyntaxTree SyntaxTree { get; }
    public TextSpan TextSpan { get; }
}
