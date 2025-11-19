using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record UnsignedIntEnumeration : IEnumeration<uint, UnsignedIntEnumeration>
{
    public static readonly UnsignedIntEnumeration Item1 = new(1, "Description1");
    public static readonly UnsignedIntEnumeration Item2 = new(2, "Description2");
    public static readonly UnsignedIntEnumeration Item3 = new(3, """Raw String Description""");
    public static readonly UnsignedIntEnumeration Item4 = new(4, """
        Multi-line
        Description
        """);
}
