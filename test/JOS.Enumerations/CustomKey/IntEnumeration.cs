using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record IntEnumeration : IEnumeration<int, IntEnumeration>
{
    public static readonly IntEnumeration Item1 = new(1, "Description1");
    public static readonly IntEnumeration Item2 = new(2, "Description2");
}
