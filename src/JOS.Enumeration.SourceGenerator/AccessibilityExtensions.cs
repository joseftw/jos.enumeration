using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace JOS.Enumeration.SourceGenerator;

internal static class AccessibilityExtensions
{
    private static readonly IReadOnlyDictionary<Accessibility, string> AccessibilityMap;

    static AccessibilityExtensions()
    {
        AccessibilityMap = new Dictionary<Accessibility, string>
        {
            [Accessibility.Internal] = "internal",
            [Accessibility.Private] = "private",
            [Accessibility.Protected] = "protected",
            [Accessibility.ProtectedAndInternal] = "protected internal",
            [Accessibility.Public] = "public"
        };
    }

    internal static string ToLowerString(this Accessibility accessibility)
    {
        if (AccessibilityMap.TryGetValue(accessibility, out var stringValue))
        {
            return stringValue;
        }

        throw new NotSupportedException($"{accessibility} has not been mapped to a string");
    }
}
