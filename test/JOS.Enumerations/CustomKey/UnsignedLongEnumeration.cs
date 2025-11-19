using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record UnsignedLongEnumeration : IEnumeration<ulong, UnsignedLongEnumeration>
{
    public static readonly UnsignedLongEnumeration Item1 = new(1, "Description1");
    public static readonly UnsignedLongEnumeration Item2 = new(2, "Description2");
    public static readonly UnsignedLongEnumeration Item3 = new(3, """Raw String Description""");
    public static readonly UnsignedLongEnumeration Item4 = new(4, """
        Multi-line
        Description
        """);
}
