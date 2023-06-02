namespace JOS.Enumerations.Ours;

public class Hamburger : Enumeration
{
    public static readonly Hamburger Cheeseburger = new(1, "Cheeseburger");
    public static readonly Hamburger BigMac = new(2, "Big Mac");
    public static readonly Hamburger BigTasty = new(3, "Big Tasty");

    private Hamburger(int id, string description) : base(id, description)
    {
    }
}