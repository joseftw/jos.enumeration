using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JOS.Enumeration.SourceGenerator;

internal static class SourceGenerationHelpers
{
    internal const string AutoGenerated = """
    // <auto-generated>
    //     This code was auto generated by JOS.Enumeration.SourceGenerator
    // </auto-generated>
    """;

    internal const string Nullable = "#nullable enable";

    // TODO Set correct version
    internal const string CodeGenerated =
        "[System.CodeDom.Compiler.GeneratedCode(\"JOS.Enumeration.SourceGenerator\", null)]";

    internal static IReadOnlyCollection<EnumerationItem> ExtractEnumerationItems(
        IReadOnlyCollection<FieldDeclarationSyntax> fields)
    {
        var items = new List<EnumerationItem>(fields.Count);
        foreach(var field in fields)
        {
            var syntax = field.Declaration.Variables.First();
            var item = CreateEnumerationItem(syntax);
            items.Add(item);
        }

        return items;
    }

    internal static IReadOnlyCollection<EnumerationItem> ExtractEnumerationItems(
        IReadOnlyCollection<IFieldSymbol> fields)
    {
        var items = new List<EnumerationItem>(fields.Count);
        foreach(var field in fields)
        {
            var syntax = field.DeclaringSyntaxReferences.FirstOrDefault()?.GetSyntax();
            if(syntax is not VariableDeclaratorSyntax variableDeclarationSyntax)
            {
                continue;
            }
            var item = CreateEnumerationItem(variableDeclarationSyntax);
            items.Add(item);
        }

        return items;
    }

    // TODO make this...much less error prone :D
    private static EnumerationItem CreateEnumerationItem(VariableDeclaratorSyntax variable)
    {
        var objectCreationExpression = (BaseObjectCreationExpressionSyntax)variable.Initializer!.Value;
        var arguments = objectCreationExpression.ArgumentList!.Arguments;
        var valueExpression = arguments[0].Expression;
        var value = GetExpressionValue(valueExpression);
        var descriptionExpression = arguments[1].Expression;
        var description = GetExpressionValue(descriptionExpression);
        var fieldName = variable.Identifier.Value!.ToString()!;
        return new EnumerationItem(value!, (string)description, fieldName, variable.SyntaxTree, variable.FullSpan);
    }

    private static object GetExpressionValue(ExpressionSyntax expression)
    {
        return expression switch
        {
            LiteralExpressionSyntax literal => literal.Token.Value ?? string.Empty,
            BinaryExpressionSyntax binary when binary.IsKind(SyntaxKind.AddExpression) =>
                GetExpressionValue(binary.Left).ToString() + GetExpressionValue(binary.Right).ToString(),
            InvocationExpressionSyntax { Expression: IdentifierNameSyntax { Identifier.Text: "nameof" } } invocation =>
                ((IdentifierNameSyntax)invocation.ArgumentList.Arguments[0].Expression).Identifier.Text,
            InterpolatedStringExpressionSyntax _ => throw new InvalidOperationException("String interpolation is not supported"),
            _ => throw new InvalidOperationException($"Unsupported expression type: {expression.GetType()}")
        };
    }
}
