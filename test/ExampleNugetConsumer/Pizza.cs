using JOS.Enumeration;

namespace ExampleNugetConsumer;

public partial record Pizza : IEnumeration<Pizza>
{
    public static readonly Pizza Vesuvio = new Pizza(1, "Vesuvio");
    public static readonly Pizza Calzone = new(2, "Calzone");
    public static readonly Pizza Hawaii = new(3, "Hawaii");
    public static readonly Pizza Kebab = new(4, "Kebab");
}
