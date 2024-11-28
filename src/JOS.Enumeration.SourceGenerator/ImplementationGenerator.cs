﻿using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace JOS.Enumeration.SourceGenerator;

internal static class ImplementationGenerator
{
    internal static void Generate(
        IReadOnlyCollection<EnumerationImplementation> enumerations,
        SourceProductionContext context)
    {
        foreach(var enumeration in enumerations)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            var source = $$"""
            {{SourceGenerationHelpers.AutoGenerated}}
            {{SourceGenerationHelpers.Nullable}}
            using System;
            using System.Collections;
            using System.Collections.Generic;
            using System.Collections.Frozen;
            using JOS.Enumeration;

            namespace {{enumeration.Namespace}};

            [System.Diagnostics.DebuggerDisplay("{Description}")]
            {{SourceGenerationHelpers.CodeGenerated}}
            {{enumeration.Modifiers}} {{enumeration.Keyword}} {{enumeration.Symbol.MetadataName}}
                : {{GenerateInterfaces(enumeration.Symbol.Name, enumeration.KeywordType)}}
            {
                private static readonly IReadOnlySet<{{enumeration.Symbol.Name}}> AllItems;

                static {{enumeration.Symbol.MetadataName}}()
                {
                    AllItems = new HashSet<{{enumeration.Symbol.Name}}>({{enumeration.Items.Count}})
                    {
                        {{AllItemsSet(enumeration.Items)}}
                    }.ToFrozenSet();
                }

                {{GenerateDefaultConstructor(enumeration.HasDeclaredConstructor, enumeration.Symbol.MetadataName, enumeration.Value)}}

                public {{enumeration.Value.ValueType}} Value { get; }
                public string Description { get; }

                public static IReadOnlySet<{{enumeration.Symbol.Name}}> GetAll()
                {
                    return AllItems;
                }

                public static IEnumerable<{{enumeration.Symbol.Name}}> GetEnumerable()
                {
                    {{GetEnumeratorBody(enumeration.Items)}}
                }

                public static {{enumeration.Symbol.Name}} FromValue({{enumeration.Value.ValueType}} value)
                {
                    {{FromValueMethodBody(enumeration.Value, enumeration.Items, enumeration.Symbol.Name)}}
                }

                public static {{enumeration.Symbol.Name}} FromDescription(string description)
                {
                    {{FromDescriptionBody(enumeration.Items, enumeration.Symbol.Name)}}
                }

                public static {{enumeration.Symbol.Name}} FromDescription(ReadOnlySpan<char> description)
                {
                    {{FromDescriptionBody(enumeration.Items, enumeration.Symbol.Name)}}
                }

                public static Type ValueType => typeof({{enumeration.Value.ValueType}});

                public int CompareTo({{enumeration.Symbol.Name}}? other) => Value.CompareTo(other!.Value);
                public static implicit operator {{enumeration.Value.OriginalDefinition}}({{enumeration.Symbol.Name}} item) => item.Value;
                public static implicit operator {{enumeration.Symbol.Name}}({{enumeration.Value.OriginalDefinition}} value) => FromValue(value);

                {{ClassSpecificMethods(enumeration.UserDefinedMethods, enumeration.KeywordType, enumeration.Symbol.Name)}}
            }
            """;

            context.AddSource($"{enumeration.Symbol.MetadataName}.Implementation.generated.cs", source.FormatSource());
        }
    }

    private static string GenerateDefaultConstructor(
        bool hasDeclaredConstructor, string metadataName, EnumerationValue enumerationValue)
    {
        return hasDeclaredConstructor
            ? string.Empty
            : $$"""
               private {{metadataName}}({{enumerationValue.ValueType}} value, string description)
               {
                   Value = value;
                   Description = description ?? throw new ArgumentNullException(nameof(description));
               }
               """;
    }

    private static string GenerateInterfaces(string symbolName, KeywordType keywordType)
    {
        return keywordType switch
        {
            KeywordType.Record => $"IComparable<{symbolName}>",
            KeywordType.Class => $"IComparable<{symbolName}>, IEquatable<{symbolName}>",
            _ => throw new NotSupportedException($"{keywordType.ToString()} is not supported")
        };
    }

    private static string ClassSpecificMethods(
        ImmutableHashSet<string> userDefinedMethods, KeywordType keywordType, string symbolName)
    {
        if(keywordType is KeywordType.Record)
        {
            return String.Empty;
        }

        var stringBuilder = new StringBuilder(3);

        if(!userDefinedMethods.Any(x => x.StartsWith("Equals(object?")))
        {
            var equalsMethod = $$"""
            public override bool Equals(object? obj)
            {
                if (!(obj is {{symbolName}} other))
                {
                    return false;
                }

                return Value.Equals(other.Value);
            }
            """;
            stringBuilder.AppendLine(equalsMethod);
        }

        if(!userDefinedMethods.Any(x => x.StartsWith($"Equals({symbolName}?")))
        {
            var genericEqualsMethod = $$"""
            public bool Equals({{symbolName}}? other)
            {
                return Value.Equals(other?.Value);
            }
            """;
            stringBuilder.AppendLine(genericEqualsMethod);
        }

        if(!userDefinedMethods.Any(x => x.StartsWith("GetHashCode(")))
        {
            var getHashCodeMethod = """
            public override int GetHashCode()
            {
                return HashCode.Combine(Value);
            }
            """;
            stringBuilder.AppendLine(getHashCodeMethod);
        }

        return stringBuilder.ToString();
    }

    private static string GetEnumeratorBody(IEnumerable<EnumerationItem> items)
    {
        var stringBuilder = new StringBuilder();
        foreach(var item in items)
        {
            stringBuilder.AppendLine($"yield return {item.FieldName};");
        }

        return stringBuilder.ToString();
    }

    private static string AllItemsSet(IEnumerable<EnumerationItem> items)
    {
        var stringBuilder = new StringBuilder();
        foreach(var item in items)
        {
            stringBuilder.AppendLine($"{item.FieldName},");
        }

        return stringBuilder.ToString();
    }

    private static string FromValueMethodBody(
        EnumerationValue value, IEnumerable<EnumerationItem> items, string symbolName)
    {
        var wrapInQuotes = ShouldWrapInQuotes(value);
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("return value switch");
        stringBuilder.AppendLine("{");
        foreach(var field in items)
        {
            var fieldValue = field.Value;
            if(wrapInQuotes)
            {
                fieldValue = WrapValueInQuotes(field.Value);
            }

            if(fieldValue is bool)
            {
                fieldValue = field.Value.ToString().ToLower();
            }

            stringBuilder.AppendLine($"{fieldValue} => {field.FieldName},");
        }

        if(ShouldAppendDefaultThrowCase(value))
        {
            stringBuilder.AppendLine(
                $"_ => throw new InvalidOperationException($\"'{{value}}' is not a valid value in '{symbolName}'\")");
        }

        stringBuilder.Append("};");
        return stringBuilder.ToString();

        static bool ShouldAppendDefaultThrowCase(EnumerationValue value)
        {
            return value.OriginalDefinition switch
            {
                "bool" => false,
                _ => true
            };
        }
    }

    private static string FromDescriptionBody(IEnumerable<EnumerationItem> items, string symbolName)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine("return description switch");
        stringBuilder.AppendLine("{");
        foreach(var field in items)
        {
            stringBuilder.AppendLine($"\"{field.Description}\" => {field.FieldName},");
        }

        stringBuilder.AppendLine(
            $"_ => throw new InvalidOperationException($\"'{{description}}' is not a valid description in '{symbolName}'\")");
        stringBuilder.Append("};");
        return stringBuilder.ToString();
    }

    private static bool ShouldWrapInQuotes(EnumerationValue value)
    {
        return value.ValueType.ToLowerInvariant() switch
        {
            "string" => true,
            _ => false
        };
    }

    private static string WrapValueInQuotes(object value)
    {
        return $"\"{value}\"";
    }
}
