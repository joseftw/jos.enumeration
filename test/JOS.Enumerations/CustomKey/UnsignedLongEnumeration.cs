using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record UnsignedLongEnumeration : IEnumeration<ulong, UnsignedLongEnumeration>
{
    public static readonly UnsignedLongEnumeration Item1 = new(1, "Description1");
    public static readonly UnsignedLongEnumeration Item2 = new(2, "Description2");
}
