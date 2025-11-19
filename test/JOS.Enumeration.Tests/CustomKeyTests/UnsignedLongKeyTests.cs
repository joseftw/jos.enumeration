using JOS.Enumerations.CustomKey;
using Shouldly;
using System.Linq;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class UnsignedLongKeyTests
{
    [Fact]
    public void FromValueReturnsCorrectItem()
    {
        var result = UnsignedLongEnumeration.FromValue(2);

        result.ShouldBe(UnsignedLongEnumeration.Item2);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = UnsignedLongEnumeration.GetAll();

        result.Count.ShouldBe(4);
        result.ShouldContain(UnsignedLongEnumeration.Item1);
        result.ShouldContain(UnsignedLongEnumeration.Item2);
        result.ShouldContain(UnsignedLongEnumeration.Item3);
        result.ShouldContain(UnsignedLongEnumeration.Item4);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = UnsignedLongEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(4);
        result.ShouldContain(UnsignedLongEnumeration.Item1);
        result.ShouldContain(UnsignedLongEnumeration.Item2);
        result.ShouldContain(UnsignedLongEnumeration.Item3);
        result.ShouldContain(UnsignedLongEnumeration.Item4);
    }

    [Fact]
    public void FromDescription_WithRawStringLiteral_ReturnsCorrectItem()
    {
        var result = UnsignedLongEnumeration.FromDescription("Raw String Description");

        result.ShouldBe(UnsignedLongEnumeration.Item3);
    }

    [Fact]
    public void FromDescription_WithMultiLineRawStringLiteral_ReturnsCorrectItem()
    {
        var result = UnsignedLongEnumeration.FromDescription("Multi-line\nDescription");

        result.ShouldBe(UnsignedLongEnumeration.Item4);
    }
}
