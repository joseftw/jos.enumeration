using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JOS.Enumeration;

public class EnumerationJsonConverter<T> : JsonConverter<Enumeration<T>> where T : Enumeration<T>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.BaseType == typeof(Enumeration<>).MakeGenericType(typeof(T));
    }

    public override Enumeration<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetInt32();
        return Enumeration<T>.FromValue(value);
    }

    public override void Write(Utf8JsonWriter writer, Enumeration<T> value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
