using JOS.Enumeration;

namespace JOS.Enumerations;

public partial record Car : IEnumeration<string, Car>
{
    public static readonly Car FerrariSpider = new("Ferrari", "Ferrari", "Spider");
    public static readonly Car TeslaModelY = new("Tesla", "Tesla", "Model Y");
    public static readonly Car Porsche911 = new("Porsche", """Porsche""", "911");
    public static readonly Car LamborghiniAventador = new("Lamborghini", """
        Lamborghini
        Aventador
        """, "Aventador");

    public string Model { get; } = null!;

    private Car(string value, string description, string model) : this(value, description)
    {
        Model = model;
    }
}
