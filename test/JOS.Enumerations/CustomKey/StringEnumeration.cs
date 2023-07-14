using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record StringEnumeration : IEnumeration<string, StringEnumeration>
{
    public static readonly StringEnumeration Item1 = new("First", "Description1");
    public static readonly StringEnumeration Item2 = new("Second", "Description2");
}
