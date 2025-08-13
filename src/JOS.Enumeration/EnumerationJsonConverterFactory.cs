using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JOS.Enumeration;

public class EnumerationJsonConverterFactory : JsonConverterFactory
{
    private static readonly ConcurrentDictionary<Type, JsonConverter> Converters = new();
    private static readonly ConcurrentDictionary<Type, bool> CanConvertCache = new();

    public override bool CanConvert(Type typeToConvert)
    {
        return CanConvertCache.GetOrAdd(typeToConvert, type =>
            type.GetInterface(typeof(IEnumeration<,>).Name) is not null ||
            type.GetInterface(typeof(IEnumeration<>).Name) is not null);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return Converters.GetOrAdd(typeToConvert, type =>
        {
            var customValueInterface = type.GetInterface(typeof(IEnumeration<,>).Name);
            if(customValueInterface != null)
            {
                var valueType = customValueInterface.GetGenericArguments()[0];
                var converterType = typeof(EnumerationJsonConverter<,>).MakeGenericType(valueType, type);
                return (JsonConverter)Activator.CreateInstance(converterType)!;
            }

            var converterTypeDefault = typeof(EnumerationJsonConverter<,>).MakeGenericType(typeof(int), type);
            return (JsonConverter)Activator.CreateInstance(converterTypeDefault)!;
        });
    }
}
