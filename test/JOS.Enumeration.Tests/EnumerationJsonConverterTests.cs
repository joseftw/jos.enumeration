using JOS.Enumerations;
using Shouldly;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace JOS.Enumeration.Tests;

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
            Hamburger = Hamburger.BigMac,
            Hamburgers = new List<Hamburger>(Hamburger.GetAll())
        };

        var result = JsonSerializer.Serialize(dto, _jsonSerializerOptions);

        result.ShouldBe("{\"hamburger\":2,\"hamburgers\":[1,2,3]}");
    }

    [Fact]
    public void DeserializesCorrectly()
    {
        var json = "{\"hamburger\":2,\"hamburgers\":[1,2,3]}";

        var result = JsonSerializer.Deserialize<MyDto>(json, _jsonSerializerOptions)!;

        result.Hamburger.ShouldBe(Hamburger.BigMac);
        result.Hamburgers.ShouldBe(Hamburger.GetAll());
    }
}

file class MyDto
{
    public required Hamburger Hamburger { get; init; }
    public required List<Hamburger> Hamburgers { get; init; }
}
