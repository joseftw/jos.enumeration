using JOS.Enumerations;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests;

public class ExplicitConstructorTests
{
    [Fact]
    public void DogCanUseExplicitConstructor()
    {
        var pug = Dog.Pug;
        var bulldog = Dog.Bulldog;

        pug.Age.ShouldBe(0);
        bulldog.Age.ShouldBe(10);
    }
}
