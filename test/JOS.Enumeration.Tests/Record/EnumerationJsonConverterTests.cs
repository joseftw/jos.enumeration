using System.Text.Json;
using JOS.Enumerations.Record;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Tests.Record;

public class EnumerationJsonConverterTests
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public EnumerationJsonConverterTests()
    {
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverter<Hamburger>() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    [Fact]
    public void SerializesCorrectly()
    {
        var dto = new MyDto
        {
            Hamburger = Hamburger.BigMac
        };

        var result = JsonSerializer.Serialize(dto, _jsonSerializerOptions);

        result.ShouldBe("{\"hamburger\":2}");
    }

    [Fact]
    public void DeserializesCorrectly()
    {
        var json = "{\"hamburger\":2}";

        var result = JsonSerializer.Deserialize<MyDto>(json, _jsonSerializerOptions)!;

        result.Hamburger.ShouldBe(Hamburger.BigMac);
    }
}

file class MyDto
{
    public required Hamburger Hamburger { get; init; }
}
