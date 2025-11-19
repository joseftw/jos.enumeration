using JOS.Enumerations.CustomKey;
using Shouldly;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace JOS.Enumeration.Tests;

public class EnumerationJsonConverterFactoryTests
{
    [Fact]
    public void SerializesBoolKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var dto = new { BoolItem = BoolEnumeration.Item2, BoolItems = BoolEnumeration.GetAll() };

        var result = JsonSerializer.Serialize(dto, jsonSerializerOptions);

        result.ShouldBe("{\"boolItem\":false,\"boolItems\":[true,false]}");
    }

    [Fact]
    public void DeserializesBoolKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        const string json = """
                            { "bool": true }
                            """;

        var result = JsonSerializer.Deserialize<MyDto>(json, jsonSerializerOptions)!;

        result.Bool.ShouldBe(BoolEnumeration.Item1);
    }

    [Fact]
    public void SerializesDecimalKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var dto = new { DecimalItem = DecimalEnumeration.Item2, DecimalItems = DecimalEnumeration.GetAll() };

        var result = JsonSerializer.Serialize(dto, jsonSerializerOptions);

        // Deserialize and verify contents
        var deserialized = JsonSerializer.Deserialize<JsonElement>(result);
        deserialized.GetProperty("decimalItem").GetDecimal().ShouldBe(2);
        
        var items = deserialized.GetProperty("decimalItems").EnumerateArray().Select(x => x.GetDecimal()).ToArray();
        items.ShouldContain(1m);
        items.ShouldContain(2m);
        items.ShouldContain(3.1m);
        items.ShouldContain(4.2m);
        items.ShouldContain(5.3m);
        items.Length.ShouldBe(5);
    }

    [Fact]
    public void DeserializesDecimalKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        const string json = """
                            { "decimal": 2.0 }
                            """;

        var result = JsonSerializer.Deserialize<MyDto>(json, jsonSerializerOptions)!;

        result.Decimal.ShouldBe(DecimalEnumeration.Item2);
    }

    [Fact]
    public void SerializesIntegerKeyCorrectly_Default()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var dto = new { IntItem = IntEnumeration.Item2, IntItems = IntEnumeration.GetAll() };

        var result = JsonSerializer.Serialize(dto, jsonSerializerOptions);

        result.ShouldBe("{\"intItem\":2,\"intItems\":[1,2,3,4]}");
    }

    [Fact]
    public void DeserializesIntKeyCorrectly_Default()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        const string json = """
                            { "int": 2 }
                            """;

        var result = JsonSerializer.Deserialize<MyDto>(json, jsonSerializerOptions)!;

        result.Int.ShouldBe(IntEnumeration.Item2);
    }

    [Fact]
    public void SerializesIntegerKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var dto = new { IntItem = IntEnumeration.Item2, IntItems = IntEnumeration.GetAll() };

        var result = JsonSerializer.Serialize(dto, jsonSerializerOptions);

        result.ShouldBe("{\"intItem\":2,\"intItems\":[1,2,3,4]}");
    }

    [Fact]
    public void DeserializesIntKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        const string json = """
                            { "int": 2 }
                            """;

        var result = JsonSerializer.Deserialize<MyDto>(json, jsonSerializerOptions)!;

        result.Int.ShouldBe(IntEnumeration.Item2);
    }

    [Fact]
    public void SerializesLongKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var dto = new { LongItem = LongEnumeration.Item2, LongItems = LongEnumeration.GetAll() };

        var result = JsonSerializer.Serialize(dto, jsonSerializerOptions);

        result.ShouldBe("{\"longItem\":2,\"longItems\":[1,2,3,4]}");
    }

    [Fact]
    public void DeserializesLongKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        const string json = """
                            { "long": 2}
                            """;

        var result = JsonSerializer.Deserialize<MyDto>(json, jsonSerializerOptions)!;

        result.Long.ShouldBe(LongEnumeration.Item2);
    }

    [Fact]
    public void SerializesStringKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var dto = new { StringItem = StringEnumeration.Item2, StringItems = StringEnumeration.GetAll() };

        var result = JsonSerializer.Serialize(dto, jsonSerializerOptions);

        result.ShouldBe("{\"stringItem\":\"Second\",\"stringItems\":[\"First\",\"Second\",\"Third\",\"Multi\\nLine\"]}");
    }

    [Fact]
    public void DeserializesStringKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        const string json = """
                            { "string": "Second"}
                            """;

        var result = JsonSerializer.Deserialize<MyDto>(json, jsonSerializerOptions)!;

        result.String.ShouldBe(StringEnumeration.Item2);
    }

    [Fact]
    public void SerializesUnsignedIntKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var dto = new { UintItem = UnsignedIntEnumeration.Item2, UintItems = UnsignedIntEnumeration.GetAll() };

        var result = JsonSerializer.Serialize(dto, jsonSerializerOptions);

        result.ShouldBe("{\"uintItem\":2,\"uintItems\":[1,2,3,4]}");
    }

    [Fact]
    public void DeserializesUnsignedIntKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        const string json = """
                            { "uint": 2}
                            """;

        var result = JsonSerializer.Deserialize<MyDto>(json, jsonSerializerOptions)!;

        result.Uint.ShouldBe(UnsignedIntEnumeration.Item2);
    }

    [Fact]
    public void SerializesUnsignedLongKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        var dto = new { UlongItem = UnsignedLongEnumeration.Item2, UlongItems = UnsignedLongEnumeration.GetAll() };

        var result = JsonSerializer.Serialize(dto, jsonSerializerOptions);

        result.ShouldBe("{\"ulongItem\":2,\"ulongItems\":[1,2,3,4]}");
    }

    [Fact]
    public void DeserializesUnsignedLongKeyCorrectly()
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            Converters = { new EnumerationJsonConverterFactory() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        const string json = """
                            { "ulong": 2}
                            """;

        var result = JsonSerializer.Deserialize<MyDto>(json, jsonSerializerOptions)!;

        result.Ulong.ShouldBe(UnsignedLongEnumeration.Item2);
    }
}

file class MyDto
{
    public BoolEnumeration Bool { get; init; } = null!;
    public DecimalEnumeration Decimal { get; init; } = null!;
    public IntEnumeration Int { get; init; } = null!;
    public LongEnumeration Long { get; init; } = null!;
    public StringEnumeration String { get; init; } = null!;
    public UnsignedLongEnumeration Ulong { get; init; } = null!;
    public UnsignedIntEnumeration Uint { get; init; } = null!;
}
