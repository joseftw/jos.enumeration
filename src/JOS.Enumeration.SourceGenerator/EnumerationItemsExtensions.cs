using System.Collections.Generic;
using System.Linq;

namespace JOS.Enumeration.SourceGenerator;

internal static class EnumerationItemsExtensions
{
    internal static IReadOnlyCollection<EnumerationItem> WithoutDuplicates(
        this IReadOnlyCollection<EnumerationItem> items)
    {
        var seenValues = new HashSet<object>();
        var seenDescriptions = new HashSet<string>();
        return items.Where(item => seenValues.Add(item.Value) && seenDescriptions.Add(item.Description)).ToArray();
    }
}
