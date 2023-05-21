using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace JOS.Enumeration.Database.Tests;

public static class RequiredConfigurationValidator
{
    public static bool Validate<T>(T arg) where T : class
    {
        var requiredProperties = typeof(T)
                                 .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 .Where(x => Attribute.IsDefined(x, typeof(RequiredMemberAttribute)));

        foreach(var requiredProperty in requiredProperties)
        {
            var propertyValue = requiredProperty.GetValue(arg);
            if(propertyValue is null)
            {
                throw new Exception($"Required property '{requiredProperty.Name}' was null");
            }
        }
        return true;
    }
}
