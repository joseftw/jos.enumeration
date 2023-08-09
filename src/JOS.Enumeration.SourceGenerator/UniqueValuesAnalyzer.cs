using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace JOS.Enumeration.SourceGenerator;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class UniqueValuesAnalyzer : DiagnosticAnalyzer
{
    internal const string UniqueValueDiagnosticId = "JOSEnumeration0001";
    internal const string UniqueDescriptionDiagnosticId = "JOSEnumeration0002";

    public override void Initialize(AnalysisContext context)
    {
        var codeAnalysis = GeneratedCodeAnalysisFlags.None;
        context.ConfigureGeneratedCodeAnalysis(codeAnalysis);
        context.EnableConcurrentExecution();
        context.RegisterSymbolAction(c =>
        {
            var namedTypeSymbol = (INamedTypeSymbol)c.Symbol;
            if(!namedTypeSymbol.ImplementsIEnumeration())
            {
                return;
            }

            var typeSymbol = (ITypeSymbol)c.Symbol;
            var items = typeSymbol
                        .GetMembers()
                        .Where(x => x.IsStatic &&
                                    x is IFieldSymbol field &&
                                    SymbolEqualityComparer.Default.Equals(field.Type, typeSymbol))
                        .Cast<IFieldSymbol>()
                        .ToArray();
            var enumerationItems = SourceGenerationHelpers.ExtractEnumerationItems(items);
            var values = new HashSet<object>();
            var descriptions = new HashSet<string>();
            foreach(var enumerationItem in enumerationItems)
            {
                if(!values.Add(enumerationItem.Value))
                {
                    var diagnostic = CreateUniqueValueDiagnostic(enumerationItem, enumerationItem.Value);
                    c.ReportDiagnostic(diagnostic);
                }

                if(!descriptions.Add(enumerationItem.Description))
                {
                    var diagnostic =
                        CreateUniqueDescriptionDiagnostic(enumerationItem, enumerationItem.Description);
                    c.ReportDiagnostic(diagnostic);
                }
            }
        }, SymbolKind.NamedType);
    }

    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(UniqueValueRule, UniqueDescriptionRule);

    private static readonly DiagnosticDescriptor UniqueValueRule = new(
        id: UniqueValueDiagnosticId,
        title: "Value needs to be unique",
        messageFormat: "Value needs to be unique. Value '{0}' has already been added.",
        category: "Design",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static readonly DiagnosticDescriptor UniqueDescriptionRule = new(
        id: UniqueDescriptionDiagnosticId,
        title: "Description needs to be unique",
        messageFormat: "Description needs to be unique. Description '{0}' has already been added.",
        category: "Design",
        defaultSeverity: DiagnosticSeverity.Error,
        isEnabledByDefault: true);

    private static Diagnostic CreateUniqueValueDiagnostic(EnumerationItem enumerationItem, object propertyValue)
    {
        return CreateDiagnostic(UniqueValueRule, enumerationItem, propertyValue);
    }

    private static Diagnostic CreateUniqueDescriptionDiagnostic(
        EnumerationItem enumerationItem, object propertyValue)
    {
        return CreateDiagnostic(UniqueDescriptionRule, enumerationItem, propertyValue);
    }

    private static Diagnostic CreateDiagnostic(
        DiagnosticDescriptor descriptor, EnumerationItem enumerationItem, object propertyValue)
    {
        var tree = enumerationItem.Syntax.SyntaxTree;
        var syntax = enumerationItem.Syntax;
        var location = Location.Create(tree, syntax.FullSpan);
        return Diagnostic.Create(descriptor, location, propertyValue);
    }
}
