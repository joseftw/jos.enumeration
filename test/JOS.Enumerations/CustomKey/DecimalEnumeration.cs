using JOS.Enumeration;

namespace JOS.Enumerations.CustomKey;

public partial record DecimalEnumeration : IEnumeration<decimal, DecimalEnumeration>
{
    public static readonly DecimalEnumeration Item1 = new(1, "Description1");
    public static readonly DecimalEnumeration Item2 = new(2, "Description2");
    public static readonly DecimalEnumeration Item3 = new(3.1m, "Description3");
}
