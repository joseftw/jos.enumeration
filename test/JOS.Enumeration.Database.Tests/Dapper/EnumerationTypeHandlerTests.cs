using JOS.Enumeration.Database.Dapper;
using JOS.Enumerations.CustomKey;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Database.Tests.Dapper;

public class EnumerationTypeHandlerTests
{
    [Fact]
    public void CanParseDefaultIntegerKey()
    {
        var sut = new EnumerationTypeHandler<IntEnumeration>();

        var result = sut.Parse(IntEnumeration.Item2.Value);

        result.ShouldBe(IntEnumeration.Item2);
    }

    [Fact]
    public void CanParseBoolKey()
    {
        var sut = new EnumerationTypeHandler<bool, BoolEnumeration>();

        var result = sut.Parse(BoolEnumeration.Item2.Value);

        result.ShouldBe(BoolEnumeration.Item2);
    }

    [Fact]
    public void CanParseDecimalKey()
    {
        var sut = new EnumerationTypeHandler<decimal, DecimalEnumeration>();

        var result = sut.Parse(DecimalEnumeration.Item2.Value);

        result.ShouldBe(DecimalEnumeration.Item2);
    }

    [Fact]
    public void CanParseIntKey()
    {
        var sut = new EnumerationTypeHandler<int, IntEnumeration>();

        var result = sut.Parse(IntEnumeration.Item2.Value);

        result.ShouldBe(IntEnumeration.Item2);
    }

    [Fact]
    public void CanParseLongKey()
    {
        var sut = new EnumerationTypeHandler<long, LongEnumeration>();

        var result = sut.Parse(LongEnumeration.Item2.Value);

        result.ShouldBe(LongEnumeration.Item2);
    }

    [Fact]
    public void CanParseStringKey()
    {
        var sut = new EnumerationTypeHandler<string, StringEnumeration>();

        var result = sut.Parse(StringEnumeration.Item2.Value);

        result.ShouldBe(StringEnumeration.Item2);
    }

    [Fact]
    public void CanParseUnsignedIntKey()
    {
        var sut = new EnumerationTypeHandler<uint, UnsignedIntEnumeration>();

        var result = sut.Parse(UnsignedIntEnumeration.Item2.Value);

        result.ShouldBe(UnsignedIntEnumeration.Item2);
    }

    [Fact]
    public void CanParseUnsignedLongKey()
    {
        var sut = new EnumerationTypeHandler<ulong, UnsignedLongEnumeration>();

        var result = sut.Parse(UnsignedLongEnumeration.Item2.Value);

        result.ShouldBe(UnsignedLongEnumeration.Item2);
    }
}
