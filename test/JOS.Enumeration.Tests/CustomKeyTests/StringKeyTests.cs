using JOS.Enumerations.CustomKey;
using Shouldly;
using System.Linq;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class StringKeyTests
{
    [Fact]
    public void FromValueReturnsCorrectItem()
    {
        var result = StringEnumeration.FromValue("Second");

        result.ShouldBe(StringEnumeration.Item2);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = StringEnumeration.GetAll();

        result.Count.ShouldBe(4);
        result.ShouldContain(StringEnumeration.Item1);
        result.ShouldContain(StringEnumeration.Item2);
        result.ShouldContain(StringEnumeration.Item3);
        result.ShouldContain(StringEnumeration.Item4);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = StringEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(4);
        result.ShouldContain(StringEnumeration.Item1);
        result.ShouldContain(StringEnumeration.Item2);
        result.ShouldContain(StringEnumeration.Item3);
        result.ShouldContain(StringEnumeration.Item4);
    }

    [Fact]
    public void FromValueReturnsFalseIfValueDoesNotExist()
    {
        var result = StringEnumeration.FromValue("gone", out _);

        result.ShouldBeFalse();
    }

    [Fact]
    public void FromValueReturnsTrueIfValueExist()
    {
        var result = StringEnumeration.FromValue(StringEnumeration.Item1, out var item);

        result.ShouldBeTrue();
        item.ShouldBe(StringEnumeration.Item1);
    }

    [Fact]
    public void FromValueReturnsCorrectItem_WithRawStringLiteral()
    {
        var result = StringEnumeration.FromValue("Third");

        result.ShouldBe(StringEnumeration.Item3);
    }

    [Fact]
    public void FromDescriptionReturnsCorrectItem_WithRawStringLiteral()
    {
        var result = StringEnumeration.FromDescription("Raw string description");

        result.ShouldBe(StringEnumeration.Item3);
    }

    [Fact]
    public void FromValueReturnsCorrectItem_WithMultiLineRawStringLiteral()
    {
        var result = StringEnumeration.FromValue("Multi\nLine");

        result.ShouldBe(StringEnumeration.Item4);
    }

    [Fact]
    public void FromDescriptionReturnsCorrectItem_WithMultiLineRawStringLiteral()
    {
        var result = StringEnumeration.FromDescription("Multi-line\ndescription");

        result.ShouldBe(StringEnumeration.Item4);
    }

    [Fact]
    public void ValueProperty_ReturnsCorrectValue_ForRawStringItem()
    {
        var item = StringEnumeration.Item3;

        item.Value.ShouldBe("Third");
    }

    [Fact]
    public void ValueProperty_ReturnsCorrectValue_ForMultiLineRawStringItem()
    {
        var item = StringEnumeration.Item4;

        item.Value.ShouldBe("Multi\nLine");
    }
}
