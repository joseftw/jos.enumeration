using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record BoolEnumeration : IEnumeration<bool, BoolEnumeration>
{
    public static readonly BoolEnumeration Item1 = new(true, "Description1");
    public static readonly BoolEnumeration Item2 = new(false, "Description2");
}
