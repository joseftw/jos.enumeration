using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Xunit;

namespace JOS.Enumeration.SourceGenerator.Tests;

public class Class1
{
    [Fact]
    public void TestGenerator()
    {
        var source = @"your test code";
        var generator = new EnumerationSourceGenerator();

        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);
        var compilation = CSharpCompilation.Create("test",
            new[] { CSharpSyntaxTree.ParseText(source, cancellationToken: TestContext.Current.CancellationToken) });

        driver.RunGeneratorsAndUpdateCompilation(compilation, out _, out _, TestContext.Current.CancellationToken);
    }
}
