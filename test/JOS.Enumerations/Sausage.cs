using JOS.Enumeration;

namespace JOS.Enumerations;

public partial record Sausage : IEnumeration<Sausage>
{
    public static readonly Sausage HotDog = new(1, "Hot Dog");
    public static readonly Sausage Pølse = new(2, "Pølse");
    public static readonly Sausage Bratwurst = new(3, """Bratwurst""");
    public static readonly Sausage ItalianSausage = new(4, """
        Italian
        Sausage
        """);
}
