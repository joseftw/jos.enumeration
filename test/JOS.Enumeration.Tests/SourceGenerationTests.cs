using JOS.Enumerations;
using Shouldly;
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
}
