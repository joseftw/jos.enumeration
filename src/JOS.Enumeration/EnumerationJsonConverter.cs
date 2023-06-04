using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JOS.Enumeration;

public class EnumerationJsonConverter<T> : JsonConverter<T> where T : IEnumeration<T>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsAssignableTo(typeof(IEnumeration<T>));
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetInt32();
        return T.FromValue(value);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteNumberValue(value.Value);
    }
}
