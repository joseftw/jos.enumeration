namespace JOS.Enumeration.Tests.Record;

internal partial record Sausage : Enumeration<Sausage>
{
    public static readonly Sausage HotDog = new(1, "Hot Dog");
    public static readonly Sausage Pølse = new(2, "Pølse");
}
