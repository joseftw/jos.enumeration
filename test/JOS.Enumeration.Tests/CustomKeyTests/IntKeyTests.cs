using JOS.Enumerations.CustomKey;
using Shouldly;
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

        result.Count.ShouldBe(2);
        result.ShouldContain(IntEnumeration.Item1);
        result.ShouldContain(IntEnumeration.Item2);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = IntEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(2);
        result.ShouldContain(IntEnumeration.Item1);
        result.ShouldContain(IntEnumeration.Item2);
    }
}
