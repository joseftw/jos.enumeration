using JOS.Enumeration;

namespace JOS.Enumerations;

public partial class Phone : IEnumeration<Phone>
{
    public static readonly Phone Iphone14Pro = new Phone(1, "iPhone 14 Pro");
    public static readonly Phone SamsungS23Ultra = new(2, "Samsung S23 Ultra");
    public static readonly Phone GooglePixel = new(3, """Google Pixel""");
    public static readonly Phone OnePlus = new(4, """
        OnePlus
        Phone
        """);
}
