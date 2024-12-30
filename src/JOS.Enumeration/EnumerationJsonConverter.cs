using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JOS.Enumeration;

public class EnumerationJsonConverter<TValue, TEnumeration> :
    JsonConverter<TEnumeration> where TEnumeration : IEnumeration<TValue, TEnumeration> where TValue : IConvertible
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsAssignableTo(typeof(IEnumeration<TValue, TEnumeration>));
    }

    public override TEnumeration Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = JsonSerializer.Deserialize<TValue>(ref reader, options)!;
        return TEnumeration.FromValue(value);
    }

    public override void Write(Utf8JsonWriter writer, TEnumeration value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(JsonSerializer.SerializeToUtf8Bytes(value.Value, options));
    }
}

public class EnumerationJsonConverter<TEnumeration> : EnumerationJsonConverter<int, TEnumeration>
    where TEnumeration : IEnumeration<int, TEnumeration>;
