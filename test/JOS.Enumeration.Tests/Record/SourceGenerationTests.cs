using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests.Record;

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
}
