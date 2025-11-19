using JOS.Enumerations;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class RawStringEnumerationTests
{
    [Fact]
    public void FromValueReturnsCorrectItem_WithSimpleRawString()
    {
        var result = RawStringEnumeration.FromValue("Second");

        result.ShouldBe(RawStringEnumeration.Item2);
    }

    [Fact]
    public void FromValueReturnsCorrectItem_WithMultiLineRawString()
    {
        // Raw string literals with indentation get normalized - newlines and indentation are removed
        var result = RawStringEnumeration.FromValue("First");

        result.ShouldBe(RawStringEnumeration.Item1);
    }

    [Fact]
    public void FromDescriptionReturnsCorrectItem_WithSimpleRawString()
    {
        var result = RawStringEnumeration.FromDescription("Simple Description");

        result.ShouldBe(RawStringEnumeration.Item2);
    }

    [Fact]
    public void FromDescriptionReturnsCorrectItem_WithMultiLineRawString()
    {
        // Multi-line raw strings preserve newlines
        var result = RawStringEnumeration.FromDescription("Description with\nmultiple lines");

        result.ShouldBe(RawStringEnumeration.Item1);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = RawStringEnumeration.GetAll();

        result.Count.ShouldBe(3);
        result.ShouldContain(RawStringEnumeration.Item1);
        result.ShouldContain(RawStringEnumeration.Item2);
        result.ShouldContain(RawStringEnumeration.Item3);
    }

    [Fact]
    public void ValueProperty_ReturnsCorrectValue_ForItem1()
    {
        var item = RawStringEnumeration.Item1;

        // Raw string with indentation and newlines gets normalized to just "First"
        item.Value.ShouldBe("First");
    }

    [Fact]
    public void ValueProperty_ReturnsCorrectValue_ForItem2()
    {
        var item = RawStringEnumeration.Item2;

        item.Value.ShouldBe("Second");
    }

    [Fact]
    public void DescriptionProperty_ReturnsCorrectDescription_ForItem1()
    {
        var item = RawStringEnumeration.Item1;

        // Multi-line raw string preserves newlines
        item.Description.ShouldBe("Description with\nmultiple lines");
    }

    [Fact]
    public void DescriptionProperty_ReturnsCorrectDescription_ForItem2()
    {
        var item = RawStringEnumeration.Item2;

        item.Description.ShouldBe("Simple Description");
    }

    [Fact]
    public void FromValueReturnsTrueIfValueExists()
    {
        var result = RawStringEnumeration.FromValue("Second", out var item);

        result.ShouldBeTrue();
        item.ShouldBe(RawStringEnumeration.Item2);
    }

    [Fact]
    public void FromValueReturnsFalseIfValueDoesNotExist()
    {
        var result = RawStringEnumeration.FromValue("NonExistent", out _);

        result.ShouldBeFalse();
    }
}
