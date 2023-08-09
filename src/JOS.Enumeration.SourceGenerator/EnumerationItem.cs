using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace JOS.Enumeration.SourceGenerator;

internal class EnumerationItem
{
    internal EnumerationItem(object value, string description, string fieldName, VariableDeclaratorSyntax syntax)
    {
        Value = value;
        Description = description ?? throw new ArgumentNullException(nameof(description));
        FieldName = fieldName ?? throw new ArgumentNullException(nameof(fieldName));
        Syntax = syntax ?? throw new ArgumentNullException(nameof(syntax));
    }

    public object Value { get; }
    public string Description { get; }
    public string FieldName { get; }
    public VariableDeclaratorSyntax Syntax { get; }
}
