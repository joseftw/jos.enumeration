using JOS.Enumerations.CustomKey;
using Shouldly;
using System.Linq;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class DecimalKeyTests
{
    [Fact]
    public void FromValueReturnsCorrectItem()
    {
        var result = DecimalEnumeration.FromValue(2);

        result.ShouldBe(DecimalEnumeration.Item2);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = DecimalEnumeration.GetAll();

        result.Count.ShouldBe(5);
        result.ShouldContain(DecimalEnumeration.Item1);
        result.ShouldContain(DecimalEnumeration.Item2);
        result.ShouldContain(DecimalEnumeration.Item3);
        result.ShouldContain(DecimalEnumeration.Item4);
        result.ShouldContain(DecimalEnumeration.Item5);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = DecimalEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(5);
        result.ShouldContain(DecimalEnumeration.Item1);
        result.ShouldContain(DecimalEnumeration.Item2);
        result.ShouldContain(DecimalEnumeration.Item3);
        result.ShouldContain(DecimalEnumeration.Item4);
        result.ShouldContain(DecimalEnumeration.Item5);
    }

    [Fact]
    public void FromDescription_WithRawStringLiteral_ReturnsCorrectItem()
    {
        var result = DecimalEnumeration.FromDescription("Raw String Description");

        result.ShouldBe(DecimalEnumeration.Item4);
    }

    [Fact]
    public void FromDescription_WithMultiLineRawStringLiteral_ReturnsCorrectItem()
    {
        var result = DecimalEnumeration.FromDescription("Multi-line\nDescription");

        result.ShouldBe(DecimalEnumeration.Item5);
    }
}
