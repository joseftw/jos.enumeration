using JOS.Enumeration;

namespace JOS.Enumerations;

public partial record RawStringEnumeration : IEnumeration<string, RawStringEnumeration>
{
    public static readonly RawStringEnumeration Item1 = new("""
        First
        """, """
        Description with
        multiple lines
        """);
    public static readonly RawStringEnumeration Item2 = new("""Second""", """Simple Description""");
    public static readonly RawStringEnumeration Item3 = new("""Third Value""", """
        Another multi-line
        description here
        """);
}
