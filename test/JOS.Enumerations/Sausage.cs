using JOS.Enumeration;

namespace JOS.Enumerations;

public partial record Sausage : IEnumeration<Sausage>
{
    public static readonly Sausage HotDog = new(1, "Hot Dog");
    public static readonly Sausage Pølse = new(2, "Pølse");
}
