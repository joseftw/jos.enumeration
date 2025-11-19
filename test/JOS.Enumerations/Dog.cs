using JOS.Enumeration;

namespace JOS.Enumerations;

public partial class Dog : IEnumeration<string, Dog>
{
    public static readonly Dog Pug = new("pug", "Lovely dog");
    public static readonly Dog Bulldog = new("bulldog", "Adorable", 10);
    public static readonly Dog GoldenRetriever = new("golden", """Golden Retriever""");
    public static readonly Dog GermanShepherd = new("german", """
        German
        Shepherd
        """, 5);

    public int Age { get; }


    private Dog(string value, string description) : this(value, description, 0)
    {
    }

    private Dog(string value, string description, int age)
    {
        Value = value;
        Description = description;
        Age = age;
    }
}
