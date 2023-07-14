using Microsoft.CodeAnalysis;

namespace JOS.Enumeration.SourceGenerator;

[Generator(LanguageNames.CSharp)]
public class EnumerationSourceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var implementations = EnumerationHelpers.GetImplementations(context);
        var incrementalValueProvider = context.CompilationProvider.Combine(implementations);
        context.RegisterSourceOutput(
            incrementalValueProvider,
            static (context, source) => ImplementationGenerator.Generate(source.Left, source.Right, context));
        context.RegisterSourceOutput(
            incrementalValueProvider,
            static (context, source) => EnumerationsClassGenerator.Generate(source.Left, source.Right, context));
    }
}
