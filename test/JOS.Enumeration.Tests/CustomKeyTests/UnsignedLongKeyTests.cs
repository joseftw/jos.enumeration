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

        result.Count.ShouldBe(2);
        result.ShouldContain(UnsignedLongEnumeration.Item1);
        result.ShouldContain(UnsignedLongEnumeration.Item2);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = UnsignedLongEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(2);
        result.ShouldContain(UnsignedLongEnumeration.Item1);
        result.ShouldContain(UnsignedLongEnumeration.Item2);
    }
}
