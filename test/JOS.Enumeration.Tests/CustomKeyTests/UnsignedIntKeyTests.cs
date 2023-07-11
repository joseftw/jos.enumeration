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

        result.Count.ShouldBe(2);
        result.ShouldContain(UnsignedIntEnumeration.Item1);
        result.ShouldContain(UnsignedIntEnumeration.Item2);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = UnsignedIntEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(2);
        result.ShouldContain(UnsignedIntEnumeration.Item1);
        result.ShouldContain(UnsignedIntEnumeration.Item2);
    }
}
