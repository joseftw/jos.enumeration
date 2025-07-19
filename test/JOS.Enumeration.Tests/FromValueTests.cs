using JOS.Enumerations.CustomKey;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests;

public class FromValueTests
{
    [Fact]
    public void FromValueWorksForDecimalValue()
    {
        var result = DecimalEnumeration.FromValue(2, out var item);

        result.ShouldBeTrue();
        item.ShouldBe(DecimalEnumeration.Item2);
    }

    [Fact]
    public void FromValueWorksForDecimalValueWithM()
    {
        var result = DecimalEnumeration.FromValue(2m, out var item);

        result.ShouldBeTrue();
        item.ShouldBe(DecimalEnumeration.Item2);
    }
}
