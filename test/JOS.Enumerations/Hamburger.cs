using JOS.Enumeration;

namespace JOS.Enumerations;

public partial record Hamburger : IEnumeration<Hamburger>
{
    public static readonly Hamburger Cheeseburger = new (1, "Cheeseburger");
    public static readonly Hamburger BigMac = new(2, "Big Mac");
    public static readonly Hamburger BigTasty = new(3, "Big Tasty");
    public static readonly Hamburger QuarterPounder = new(4, "Quarter Pounder");
    public static readonly Hamburger DoubleQuarterPounder = new(5, "Double Quarter Pounder");
    public static readonly Hamburger QuarterPounderWithCheeseDeluxe = new(6, "Quarter Pounder®* with Cheese Deluxe");
    public static readonly Hamburger McDouble = new(7, "McDouble®");
    public static readonly Hamburger QuarterPounderWithCheeseBacon = new(8, "Quarter Pounder®* with Cheese Bacon");
    public static readonly Hamburger DoubleCheeseburger = new(9, "Double Cheeseburger");
    public static readonly Hamburger OriginalHamburger = new(10, "Original Hamburger");
}
