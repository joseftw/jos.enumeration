using JOS.Enumerations.CustomKey;
using Shouldly;
using System.Linq;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class LongKeyTests
{
    [Fact]
    public void FromValueReturnsCorrectItem()
    {
        var result = LongEnumeration.FromValue(2);

        result.ShouldBe(LongEnumeration.Item2);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = LongEnumeration.GetAll();

        result.Count.ShouldBe(4);
        result.ShouldContain(LongEnumeration.Item1);
        result.ShouldContain(LongEnumeration.Item2);
        result.ShouldContain(LongEnumeration.Item3);
        result.ShouldContain(LongEnumeration.Item4);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = LongEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(4);
        result.ShouldContain(LongEnumeration.Item1);
        result.ShouldContain(LongEnumeration.Item2);
        result.ShouldContain(LongEnumeration.Item3);
        result.ShouldContain(LongEnumeration.Item4);
    }

    [Fact]
    public void FromDescription_WithRawStringLiteral_ReturnsCorrectItem()
    {
        var result = LongEnumeration.FromDescription("Raw String Description");

        result.ShouldBe(LongEnumeration.Item3);
    }

    [Fact]
    public void FromDescription_WithMultiLineRawStringLiteral_ReturnsCorrectItem()
    {
        var result = LongEnumeration.FromDescription("Multi-line\nDescription");

        result.ShouldBe(LongEnumeration.Item4);
    }
}
