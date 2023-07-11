using JOS.Enumerations.CustomKey;
using Shouldly;
using System.Linq;
using Xunit;

namespace JOS.Enumeration.Tests.CustomKeyTests;

public class StringKeyTests
{
    [Fact]
    public void FromValueReturnsCorrectItem()
    {
        var result = StringEnumeration.FromValue("Second");

        result.ShouldBe(StringEnumeration.Item2);
    }

    [Fact]
    public void GetAllReturnsCorrectItems()
    {
        var result = StringEnumeration.GetAll();

        result.Count.ShouldBe(2);
        result.ShouldContain(StringEnumeration.Item1);
        result.ShouldContain(StringEnumeration.Item2);
    }

    [Fact]
    public void GetEnumerableReturnsCorrectItem()
    {
        var enumerable = StringEnumeration.GetEnumerable();

        var result = enumerable.ToList();

        result.Count.ShouldBe(2);
        result.ShouldContain(StringEnumeration.Item1);
        result.ShouldContain(StringEnumeration.Item2);
    }
}
