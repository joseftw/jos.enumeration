﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace JOS.Enumeration.SourceGenerator;

internal static class EnumerationsClassGenerator
{
    internal static void Generate(
        Compilation compilation,
        ImmutableArray<TypeDeclarationSyntax> enumerations,
        SourceProductionContext context)
    {
        if(enumerations.IsDefaultOrEmpty)
        {
            return;
        }

        context.CancellationToken.ThrowIfCancellationRequested();
        var @namespace = compilation.Assembly.Identity.Name;
        var source = $$"""
            {{SourceGenerationHelpers.AutoGenerated}}
            {{SourceGenerationHelpers.Nullable}}
            using System;
            using JOS.Enumeration;

            namespace {{@namespace}};

            public static class Enumerations
            {
                {{GenerateNestedClasses(compilation, enumerations)}}
            }
            """;

        context.AddSource("Enumerations.Generated.cs", source.FormatSource());
    }

    private static string GenerateNestedClasses(
        Compilation compilation, ImmutableArray<TypeDeclarationSyntax> enumerations)
    {
        var stringBuilder = new StringBuilder();
        foreach(var enumeration in enumerations)
        {
            var symbol =
                compilation.GetSemanticModel(enumeration.SyntaxTree).GetDeclaredSymbol(enumeration)!;
            var typeSymbol = (ITypeSymbol)symbol;
            var enumerationInterface =
                typeSymbol.AllInterfaces.Single(x => x.Name == "IEnumeration" && x.TypeArguments.Length == 2);
            var valueType = enumerationInterface.TypeArguments.First();
            var name = symbol.Name;
            stringBuilder.AppendLine($"public static class {name}");
            stringBuilder.AppendLine("{");
            var fieldDeclarationSyntaxes =
                enumeration.Members.Where(x => x is FieldDeclarationSyntax).Cast<FieldDeclarationSyntax>().ToList();
            var items = SourceGenerationHelpers.ExtractEnumerationItems(fieldDeclarationSyntaxes);
            foreach(var item in items)
            {
                var value = FormatValue(valueType, item.Value);
                stringBuilder.AppendLine($"public static class {item.FieldName}");
                stringBuilder.AppendLine("{");
                stringBuilder.AppendLine($"public const {valueType.OriginalDefinition} Value = {value};");
                stringBuilder.AppendLine($"public const string Description = \"{item.Description}\";");
                stringBuilder.AppendLine("}");
            }
            stringBuilder.AppendLine("}");
        }

        return stringBuilder.ToString();
    }

    private static string FormatValue(ITypeSymbol typeSymbol, object value)
    {
        var type = typeSymbol.OriginalDefinition.ToString();
        return type switch
        {
            "bool" => value.ToString().ToLower(),
            "string" => $"\"{value}\"",
            _ => value.ToString()
        };
    }
}
