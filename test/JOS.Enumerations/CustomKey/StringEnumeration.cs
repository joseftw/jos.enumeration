using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record StringEnumeration : IEnumeration<string, StringEnumeration>
{
    public static readonly StringEnumeration Item1 = new("First", "DisplayName1");
    public static readonly StringEnumeration Item2 = new("Second", "DisplayName2");
}
