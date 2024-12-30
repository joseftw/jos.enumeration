using JOS.Enumeration;
using System;

namespace JOS.Enumerations;

public partial class Drink : IEnumeration<Drink>
{
    public static readonly Drink GinTonic = new (1, "Gin" + "Tonic");
    public static readonly Drink RedBullVodka = new(2, nameof(RedBullVodka));
}
