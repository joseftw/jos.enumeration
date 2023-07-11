using JOS.Enumeration;

namespace JOS.Enumerations;

public partial record Car : IEnumeration<string, Car>
{
    public static readonly Car FerrariSpider = new("Ferrari", "Ferrari", "Spider");
    public static readonly Car TeslaModelY = new("Tesla", "Tesla", "Model Y");

    public string Model { get; } = null!;

    private Car(string value, string displayName, string model) : this(value, displayName)
    {
        Model = model;
    }
}
