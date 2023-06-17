using JOS.Enumerations;
using Shouldly;
#if NET8_0_OR_GREATER
using System.Collections.Frozen;
#endif
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

    #if NET8_0_OR_GREATER
    [Fact]
    public void ShouldBeFrozenSetIfNet80()
    {
        var result = Hamburger.GetAll();

        result.GetType().Name.ShouldBe("SmallFrozenSet`1");
    }
    #endif
}
