using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record UnsignedIntEnumeration : IEnumeration<uint, UnsignedIntEnumeration>
{
    public static readonly UnsignedIntEnumeration Item1 = new(1, "DisplayName1");
    public static readonly UnsignedIntEnumeration Item2 = new(2, "DisplayName2");
}
