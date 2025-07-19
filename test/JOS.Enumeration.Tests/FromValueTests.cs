using JOS.Enumerations.CustomKey;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests;

public class FromValueTests
{
    [Theory]
    [InlineData(2)]
    [InlineData(2m)]
    public void FromValueWorksForDecimalValue(decimal value)
    {
        var result = DecimalEnumeration.FromValue(value, out var item);

        result.ShouldBeTrue();
        item.ShouldBe(DecimalEnumeration.Item2);
    }
}
