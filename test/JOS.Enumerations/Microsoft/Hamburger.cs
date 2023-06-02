namespace JOS.Enumerations.Microsoft;

public class Hamburger : Enumeration
{
    public static readonly Hamburger Cheeseburger = new(1, "Cheeseburger");
    public static readonly Hamburger BigMac = new(2, "Big Mac");
    public static readonly Hamburger BigTasty = new(3, "Big Tasty");
        
    private Hamburger(int value, string name) : base(value, name)
    {
    }
}