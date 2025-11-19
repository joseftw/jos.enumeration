using JOS.Enumerations.CustomKey;
using Shouldly;
using System.Linq;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class BoolKeyTests
{
    [Fact]
    public void FromValueReturnsCorrectItem()
    {
        var result = BoolEnumeration.FromValue(false);

        result.ShouldBe(BoolEnumeration.Item2);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = BoolEnumeration.GetAll();

        result.Count.ShouldBe(2);
        result.ShouldContain(BoolEnumeration.Item1);
        result.ShouldContain(BoolEnumeration.Item2);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = BoolEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(2);
        result.ShouldContain(BoolEnumeration.Item1);
        result.ShouldContain(BoolEnumeration.Item2);
    }

    [Fact]
    public void FromDescription_WithRawStringLiteral_ReturnsCorrectItem()
    {
        var result = BoolEnumeration.FromDescription("Raw String Description");

        result.ShouldBe(BoolEnumeration.Item1);
    }

    [Fact]
    public void FromDescription_WithMultiLineRawStringLiteral_ReturnsCorrectItem()
    {
        var result = BoolEnumeration.FromDescription("Multi-line\nDescription");

        result.ShouldBe(BoolEnumeration.Item2);
    }
}
