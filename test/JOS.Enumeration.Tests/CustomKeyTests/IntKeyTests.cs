using JOS.Enumerations.CustomKey;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class IntKeyTests
{
    [Fact]
    public void FromValueReturnsCorrectItem()
    {
        var result = IntEnumeration.FromValue(2);

        result.ShouldBe(IntEnumeration.Item2);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = IntEnumeration.GetAll();

        result.Count.ShouldBe(4);
        result.ShouldContain(IntEnumeration.Item1);
        result.ShouldContain(IntEnumeration.Item2);
        result.ShouldContain(IntEnumeration.Item3);
        result.ShouldContain(IntEnumeration.Item4);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = IntEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(4);
        result.ShouldContain(IntEnumeration.Item1);
        result.ShouldContain(IntEnumeration.Item2);
        result.ShouldContain(IntEnumeration.Item3);
        result.ShouldContain(IntEnumeration.Item4);
    }

    [Fact]
    public void FromDescription_WithRawStringLiteral_ReturnsCorrectItem()
    {
        var result = IntEnumeration.FromDescription("Raw String Description");

        result.ShouldBe(IntEnumeration.Item3);
    }

    [Fact]
    public void FromDescription_WithMultiLineRawStringLiteral_ReturnsCorrectItem()
    {
        var result = IntEnumeration.FromDescription("Multi-line\nDescription");

        result.ShouldBe(IntEnumeration.Item4);
    }

    [Fact]
    public void Span_FromDescription_WithRawStringLiteral_ReturnsCorrectItem()
    {
        var result = IntEnumeration.FromDescription("Raw String Description".AsSpan());

        result.ShouldBe(IntEnumeration.Item3);
    }

    [Fact]
    public void Span_FromDescription_WithMultiLineRawStringLiteral_ReturnsCorrectItem()
    {
        var result = IntEnumeration.FromDescription("Multi-line\nDescription".AsSpan());

        result.ShouldBe(IntEnumeration.Item4);
    }
}
