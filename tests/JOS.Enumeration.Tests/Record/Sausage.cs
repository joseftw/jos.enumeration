using JOS.Enumeration.Record;

namespace JOS.Enumeration.Tests.Record;

internal record Sausage : Enumeration<Sausage>
{
    public static Sausage HotDog = new(1, "Hot Dog");
    public static Sausage Pølse = new(2, "Pølse");

    private Sausage(int value, string displayName) : base(value, displayName)
    {
    }
}