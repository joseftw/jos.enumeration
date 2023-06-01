using Microsoft.CodeAnalysis;

namespace JOS.Enumeration.SourceGenerator;

[Generator]
internal class PrivateCtorSourceGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new EnumerationReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxContextReceiver is not EnumerationReceiver receiver)
        {
            return;
        }

        var enumerations = receiver.EnumerationImplementations;

        foreach (var enumeration in enumerations)
        {
            // TODO only generate if no other ctor has been specified
            context.CancellationToken.ThrowIfCancellationRequested();
            var visibility = enumeration.DeclaredAccessibility.ToLowerString();
            var source = $$"""
            // <auto-generated>
            //     This code was auto generated by {{typeof(PrivateCtorSourceGenerator).Namespace}}
            // </auto-generated>

            using JOS.Enumeration;

            namespace {{enumeration.ContainingNamespace}};

            {{visibility}} partial record {{enumeration.MetadataName}} : Enumeration<{{enumeration.MetadataName}}>
            {
                private {{enumeration.MetadataName}}(int value, string displayName) : base(value, displayName)
                {
                }
            }
            """;

            context.AddSource($"{enumeration.MetadataName}.Generated.Constructor.cs", source);
        }
    }
}