using JOS.Enumerations;
using Shouldly;
using System.CodeDom.Compiler;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Xunit;
using Sausage = JOS.Enumerations.Sausage;

namespace JOS.Enumeration.Tests;

public class SourceGenerationTests
{
    [Fact]
    public void SupportsImplicitConversionFromIntToSausage()
    {
        const int value = 2;

        Sausage result = value;

        result.ShouldBe(Sausage.Pølse);
    }

    [Fact]
    public void SupportsImplicitConversionFromSausageToInt()
    {
        var sausage = Sausage.Pølse;

        int result = sausage;

        result.ShouldBe(2);
    }

    [Fact]
    public void ShouldBeFrozenSet()
    {
        var result = Hamburger.GetAll();

        result.GetType().Name.ShouldBe("SmallFrozenSet`1");
    }

    [Fact]
    public void ShouldAddGeneratedCodeAttributeToClass()
    {
        var josEnumerationAssemblyName = typeof(Hamburger).Assembly.GetReferencedAssemblies()
                                                      .First(x => x.Name!.Equals("JOS.Enumeration"));
        var josEnumerationAssembly = Assembly.Load(josEnumerationAssemblyName);
        var informationalVersionAttribute = josEnumerationAssembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>();

        var generatedCodeAttribute = typeof(Hamburger).GetCustomAttribute<GeneratedCodeAttribute>();

        generatedCodeAttribute.ShouldNotBeNull();
        generatedCodeAttribute.Tool.ShouldBe("JOS.Enumeration.SourceGenerator");
        generatedCodeAttribute.Version.ShouldBe(informationalVersionAttribute!.InformationalVersion);
    }

    [Fact]
    public void ShouldAddGeneratedCodeAttributeToEnumerationsClass()
    {
        var josEnumerationAssemblyName = typeof(Enumerations).Assembly.GetReferencedAssemblies()
                                                          .First(x => x.Name!.Equals("JOS.Enumeration"));
        var josEnumerationAssembly = Assembly.Load(josEnumerationAssemblyName);
        var informationalVersionAttribute = josEnumerationAssembly
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>();

        var generatedCodeAttribute = typeof(Enumerations).GetCustomAttribute<GeneratedCodeAttribute>();

        generatedCodeAttribute.ShouldNotBeNull();
        generatedCodeAttribute.Tool.ShouldBe("JOS.Enumeration.SourceGenerator");
        generatedCodeAttribute.Version.ShouldBe(informationalVersionAttribute!.InformationalVersion);
    }

    [Fact]
    public void ShouldAddExcludeFromCodeAnalysisAttribute()
    {
        var excludeFromCodeAnalysisAttribute =
            typeof(Hamburger).GetCustomAttribute<ExcludeFromCodeCoverageAttribute>();

        excludeFromCodeAnalysisAttribute.ShouldNotBeNull();
    }

    [Fact]
    public void ShouldAddExcludeFromCodeAnalysisAttributeToEnumerationsClass()
    {
        var excludeFromCodeAnalysisAttribute =
            typeof(Enumerations).GetCustomAttribute<ExcludeFromCodeCoverageAttribute>();

        excludeFromCodeAnalysisAttribute.ShouldNotBeNull();
    }
}
