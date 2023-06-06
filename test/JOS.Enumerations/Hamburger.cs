using JOS.Enumeration;

namespace JOS.Enumerations;

public partial record Hamburger : IEnumeration<Hamburger>
{
    public static readonly Hamburger Cheeseburger = new (1, "Cheeseburger");
    public static readonly Hamburger BigMac = new(2, "Big Mac");
    public static readonly Hamburger BigTasty = new(3, "Big Tasty");
}
