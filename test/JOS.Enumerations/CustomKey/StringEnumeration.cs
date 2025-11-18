using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record StringEnumeration : IEnumeration<string, StringEnumeration>
{
    public static readonly StringEnumeration Item1 = new("First", "Description1");
    public static readonly StringEnumeration Item2 = new("Second", "Description2");
    public static readonly StringEnumeration Item3 = new("""Third""", """Raw string description""");
    public static readonly StringEnumeration Item4 = new("""
        Multi
        Line
        """, """
        Multi-line
        description
        """);
}
