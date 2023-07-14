using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record LongEnumeration : IEnumeration<long, LongEnumeration>
{
    public static readonly LongEnumeration Item1 = new(1, "Description1");
    public static readonly LongEnumeration Item2 = new(2, "Description2");
}
