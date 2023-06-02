using JOS.Enumeration;

namespace JOS.Enumerations.Record;

public record Hamburger : Enumeration<Hamburger>
{
    public static readonly Hamburger Cheeseburger = new (1, "Cheeseburger");
    public static readonly Hamburger BigMac = new(2, "Big Mac");
    public static readonly Hamburger BigTasty = new(3, "Big Tasty");

    private Hamburger(int id, string displayName) : base(id, displayName)
    {
    }
}
