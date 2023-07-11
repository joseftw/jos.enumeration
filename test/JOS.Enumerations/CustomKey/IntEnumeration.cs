using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record IntEnumeration : IEnumeration<int, IntEnumeration>
{
    public static readonly IntEnumeration Item1 = new(1, "DisplayName1");
    public static readonly IntEnumeration Item2 = new(2, "DisplayName2");
}
