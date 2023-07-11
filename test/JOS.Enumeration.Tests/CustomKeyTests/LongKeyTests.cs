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

        result.Count.ShouldBe(2);
        result.ShouldContain(LongEnumeration.Item1);
        result.ShouldContain(LongEnumeration.Item2);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = LongEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(2);
        result.ShouldContain(LongEnumeration.Item1);
        result.ShouldContain(LongEnumeration.Item2);
    }
}
