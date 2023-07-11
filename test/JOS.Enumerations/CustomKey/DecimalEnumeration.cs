using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record DecimalEnumeration : IEnumeration<decimal, DecimalEnumeration>
{
    public static readonly DecimalEnumeration Item1 = new(1, "DisplayName1");
    public static readonly DecimalEnumeration Item2 = new(2, "DisplayName2");
}
