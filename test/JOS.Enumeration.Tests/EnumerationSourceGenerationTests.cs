using JOS.Enumerations;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests;

public class EnumerationSourceGenerationTests
{
    [Fact]
    public void GeneratesSausageClass()
    {
        var hotDog = JOS.Enumerations.Enumerations.Sausage.HotDog.Value;
        var pølse = JOS.Enumerations.Enumerations.Sausage.Pølse.Value;

        hotDog.ShouldBe(Sausage.HotDog.Value);
        pølse.ShouldBe(Sausage.Pølse.Value);
    }
}
