using JOS.Enumerations.CustomKey;
using Shouldly;
using System.Linq;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class UnsignedIntKeyTests
{
    [Fact]
    public void FromValueReturnsCorrectItem()
    {
        var result = UnsignedIntEnumeration.FromValue(2);

        result.ShouldBe(UnsignedIntEnumeration.Item2);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = UnsignedIntEnumeration.GetAll();

        result.Count.ShouldBe(4);
        result.ShouldContain(UnsignedIntEnumeration.Item1);
        result.ShouldContain(UnsignedIntEnumeration.Item2);
        result.ShouldContain(UnsignedIntEnumeration.Item3);
        result.ShouldContain(UnsignedIntEnumeration.Item4);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = UnsignedIntEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(4);
        result.ShouldContain(UnsignedIntEnumeration.Item1);
        result.ShouldContain(UnsignedIntEnumeration.Item2);
        result.ShouldContain(UnsignedIntEnumeration.Item3);
        result.ShouldContain(UnsignedIntEnumeration.Item4);
    }

    [Fact]
    public void FromDescription_WithRawStringLiteral_ReturnsCorrectItem()
    {
        var result = UnsignedIntEnumeration.FromDescription("Raw String Description");

        result.ShouldBe(UnsignedIntEnumeration.Item3);
    }

    [Fact]
    public void FromDescription_WithMultiLineRawStringLiteral_ReturnsCorrectItem()
    {
        var result = UnsignedIntEnumeration.FromDescription("Multi-line\nDescription");

        result.ShouldBe(UnsignedIntEnumeration.Item4);
    }
}
