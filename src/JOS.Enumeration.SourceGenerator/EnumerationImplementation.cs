using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace JOS.Enumeration.SourceGenerator;

internal record EnumerationImplementation
{
    public EnumerationImplementation(
        EnumerationValue value,
        IReadOnlyCollection<EnumerationItem> items,
        ImmutableHashSet<string> userDefinedMethods,
        KeywordType keywordType,
        Symbol symbol,
        bool hasDeclaredConstructor,
        string keyword,
        string modifiers,
        string @namespace)
    {
        Value = value;
        Items = items;
        UserDefinedMethods = userDefinedMethods;
        KeywordType = keywordType;
        Symbol = symbol;
        HasDeclaredConstructor = hasDeclaredConstructor;
        Keyword = keyword;
        Modifiers = modifiers;
        Namespace = @namespace;
    }

    internal EnumerationValue Value { get; }
    internal IReadOnlyCollection<EnumerationItem> Items { get; }
    internal ImmutableHashSet<string> UserDefinedMethods { get; }
    internal KeywordType KeywordType { get; }
    internal Symbol Symbol { get; }
    internal bool HasDeclaredConstructor { get; }
    internal string Keyword { get; }
    internal string Modifiers { get; }
    internal string Namespace { get; }
}

internal record EnumerationValue
{
    public EnumerationValue(
        string name, string valueType, string originalDefinition)
    {
        Name = name;
        ValueType = valueType;
        OriginalDefinition = originalDefinition;
    }

    internal string Name { get; }
    internal string ValueType { get; }
    internal string OriginalDefinition { get; }
}

internal record Symbol
{
    public Symbol(string name, string metadataName)
    {
        Name = name;
        MetadataName = metadataName;
    }

    internal string Name { get; }
    internal string MetadataName { get; }
}

internal enum KeywordType
{
    Record,
    Class
}
