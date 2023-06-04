using JOS.Enumerations.Record;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests.Record;

public class EnumerationSourceGenerationTests
{
    [Fact]
    public void GeneratesGetAllMethod()
    {
        var getAllSausageResult = Sausage.GetAll();

        var generatedResult = Enumerations.Enumeration.GetAll<Sausage>();

        getAllSausageResult.ShouldBe(generatedResult);
    }

    [Fact]
    public void GeneratesFromValueMethod()
    {
        const int value = 1;
        var fromValueSausageResult = Sausage.FromValue(value);


        var generatedResult = Enumerations.Enumeration.FromValue<Sausage>(value);

        fromValueSausageResult.ShouldBe(generatedResult);
    }

    [Fact]
    public void GeneratesFromDisplayNameMethod()
    {
        const string displayName = "Hot Dog";
        var fromValueSausageResult = Sausage.FromDisplayName(displayName);

        var generatedResult = Enumerations.Enumeration.FromDisplayName<Sausage>(displayName);

        fromValueSausageResult.ShouldBe(generatedResult);
    }
}
