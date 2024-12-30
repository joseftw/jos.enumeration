using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests;

public class ClassGenerationTests
{
    [Fact]
    public void SupportsCustomGetHashCodeMethod()
    {
        var result = CustomGetHashCode.MyItem1.GetHashCode();

        result.ShouldBe(1);
    }

    [Fact]
    public void SupportsGeneratedGetHashCodeMethod()
    {
        var result = GeneratedGetHashCode.MyItem1.GetHashCode();

        result.ShouldNotBe(1);
    }

    [Fact]
    public void SupportsCustomEqualsObjectMethod()
    {
        // Hardcoded Equals, returns true for everything
        var result = CustomEquals.MyItem1.Equals((object)CustomEquals.MyItem2);

        result.ShouldBeTrue();
    }

    [Fact]
    public void SupportsCustomEqualsMethod()
    {
        // Hardcoded Equals, returns true for everything
        var result = CustomEquals.MyItem1.Equals(CustomEquals.MyItem2);

        result.ShouldBeTrue();
    }

    [Fact]
    public void SupportsGeneratedEqualsMethod()
    {
        var result = GeneratedEquals.MyItem1.Equals(GeneratedEquals.MyItem2);

        result.ShouldBeFalse();
    }
}

internal partial class CustomGetHashCode : IEnumeration<CustomGetHashCode>
{
    internal static readonly CustomGetHashCode MyItem1 = new(1, "Item 1");
    internal static readonly CustomGetHashCode MyItem2 = new(2, "Item 2");

    public override int GetHashCode()
    {
        return 1;
    }
}

internal partial class GeneratedGetHashCode : IEnumeration<GeneratedGetHashCode>
{
    internal static readonly GeneratedGetHashCode MyItem1 = new(1, "Item 1");
    internal static readonly GeneratedGetHashCode MyItem2 = new(2, "Item 2");
}

internal partial class CustomEquals : IEnumeration<CustomEquals>
{
    internal static readonly CustomEquals MyItem1 = new(1, "Item 1");
    internal static readonly CustomEquals MyItem2 = new(2, "Item 2");

    public override bool Equals(object? obj)
    {
        return true;
    }

    public bool Equals(CustomEquals? other)
    {
        return true;
    }
}

internal partial class GeneratedEquals : IEnumeration<GeneratedEquals>
{
    internal static readonly GeneratedEquals MyItem1 = new(1, "Item 1");
    internal static readonly GeneratedEquals MyItem2 = new(2, "Item 2");
}
