using JOS.Enumeration;

namespace JOS.Enumerations;

public partial class Drink : IEnumeration<Drink>
{
    public static readonly Drink GinTonic = new(1, "Gin" + "Tonic");
    public static readonly Drink RedBullVodka = new(2, nameof(RedBullVodka));
    public static readonly Drink WhiskeyCola = new(3, """Whiskey Cola""");
    public static readonly Drink LongIslandIcedTea = new(4, """
        Long Island
        Iced Tea
        """);
}
