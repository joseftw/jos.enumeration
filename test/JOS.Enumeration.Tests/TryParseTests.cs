using JOS.Enumerations.CustomKey;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests;

public class TryParseTests
{
    [Theory]
    [InlineData("False")]
    [InlineData("false")]
    public void TryParseWorksForBoolValue(string value)
    {
        var result = BoolEnumeration.TryParse(value, out var item);

        result.ShouldBeTrue();
        item.ShouldBe(BoolEnumeration.Item2);
    }

    [Fact]
    public void TryParseWorksForDecimalValue()
    {
        var result = DecimalEnumeration.TryParse("2", out var item);

        result.ShouldBeTrue();
        item.ShouldBe(DecimalEnumeration.Item2);
    }

    [Fact]
    public void TryParseWorksForDecimalValueWithDecimals()
    {
        var result = DecimalEnumeration.TryParse("3.1", out var item);

        result.ShouldBeTrue();
        item.ShouldBe(DecimalEnumeration.Item3);
    }

    [Fact]
    public void TryParseWorksForLongValue()
    {
        var result = LongEnumeration.TryParse("2", out var item);

        result.ShouldBeTrue();
        item.ShouldBe(LongEnumeration.Item2);
    }

    [Fact]
    public void TryParseWorksForStringValue()
    {
        var result = StringEnumeration.TryParse("Second", out var item);

        result.ShouldBeTrue();
        item.ShouldBe(StringEnumeration.Item2);
    }

    [Fact]
    public void TryParseWorksForIntValue()
    {
        var result = IntEnumeration.TryParse("2", out var item);

        result.ShouldBeTrue();
        item.ShouldBe(IntEnumeration.Item2);
    }

    [Fact]
    public void TryParseWorksForUnsignedIntValue()
    {
        var result = UnsignedIntEnumeration.TryParse("2", out var item);

        result.ShouldBeTrue();
        item.ShouldBe(UnsignedIntEnumeration.Item2);
    }

    [Fact]
    public void TryParseWorksForUnsignedLongValue()
    {
        var result = UnsignedLongEnumeration.TryParse("2", out var item);

        result.ShouldBeTrue();
        item.ShouldBe(UnsignedLongEnumeration.Item2);
    }
}
