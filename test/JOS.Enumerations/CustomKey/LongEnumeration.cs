using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record LongEnumeration : IEnumeration<long, LongEnumeration>
{
    public static readonly LongEnumeration Item1 = new(1, "DisplayName1");
    public static readonly LongEnumeration Item2 = new(2, "DisplayName2");
}
