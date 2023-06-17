# JOS.Enumeration
Enumeration implementation based on Record and source generation

## Installation
### JOS.Enumeration
Contains the `IEnumeration interface` and a `System.Text.Json` JsonConverter.

`dotnet add package JOS.Enumeration`

### JOS.Enumeration.SourceGenerator
Contains the source generator that generates the enumeration records for you.

Has **NO** dependency on **JOS.Enumeration**, you'll need to add that explicitly.

`dotnet add package JOS.Enumeration.SourceGenerator`

### JOS.Enumeration.Database.Dapper
Contains a custom `TypeHandler` for use with Dapper.

`dotnet add package JOS.Enumeration.Database.Dapper`

### JOS.Enumeration.Database.EntityFrameworkCore
Contains ConfigureEnumeration extension method to allow usage with EntityFramework Core.

`dotnet add package JOS.Enumeration.Database.EntityFrameworkCore`

## Usage
* Create a new record
* Make it partial
* Implement the `IEnumeration<T>` interface
* Add your Enumeration items
```csharp
public partial record Hamburger : IEnumeration<Hamburger>
{
    public static readonly Hamburger Cheeseburger = new (1, "Cheeseburger");
    public static readonly Hamburger BigMac = new(2, "Big Mac");
    public static readonly Hamburger BigTasty = new(3, "Big Tasty");
}
```
The following code will be generated:
```csharp
public partial record Hamburger : IComparable<Hamburger>
{
    private Hamburger(int value, string displayName)
    {
        Value = value;
        DisplayName = displayName ?? throw new ArgumentNullException(nameof(displayName));
    }

    public int Value { get; }
    public string DisplayName { get; }
    public static IEnumerable<Hamburger> GetAll()
    {
        yield return Cheeseburger;
        yield return BigMac;
        yield return BigTasty;
    }

    public static Hamburger FromValue(int value)
    {
        return value switch
        {
            1 => Cheeseburger,
            2 => BigMac,
            3 => BigTasty,
            _ => throw new InvalidOperationException($"'{value}' is not a valid value in 'JOS.Enumerations.Hamburger'")};
    }

    public static Hamburger FromDisplayName(string displayName)
    {
        return displayName switch
        {
            "Cheeseburger" => Cheeseburger,
            "Big Mac" => BigMac,
            "Big Tasty" => BigTasty,
            _ => throw new InvalidOperationException($"'{displayName}' is not a valid display name in 'JOS.Enumerations.Hamburger'")};
    }

    public int CompareTo(Hamburger? other) => Value.CompareTo(other!.Value);
    public static implicit operator int (Hamburger item) => item.Value;
    public static implicit operator Hamburger(int value) => FromValue(value);
}
```
## Features
* Generated `IComparable<T>` method.
* Generated implicit operators (convert to/from int).
* Generated optimized `GetAll`, `FromValue` and `FromDisplayName` methods.
* System.Text.Json support *(AOT support coming soon)*
* Database support (Dapper and EF Core).

### JSON

### Database
```csharp
public class MyEntity
{
    public MyEntity(Guid id, Hamburger hamburger)
    {
        Id = id;
        Hamburger = hamburger;
    }

    public Guid Id { get; }
    public Hamburger Hamburger { get; }
}
```
#### Dapper
* Register the TypeHandler: `SqlMapper.AddTypeHandler(new EnumerationTypeHandler<Hamburger>())`
* Query like this:
```csharp
var results = (await actConnection.QueryAsync<MyEntity>(
            "SELECT id, hamburger from my_entities WHERE id = @id", new {id = myEntity.Id})).ToList(); 
```

#### EF Core
* Configure your DB Context
```csharp
public DbSet<MyEntity> MyEntities { get; set; } = null!;

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(JosEnumerationDbContext).Assembly);
} 
```
```csharp
public class MyEntityEntityTypeConfiguration : IEntityTypeConfiguration<MyEntity>
{
    public void Configure(EntityTypeBuilder<MyEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Hamburger).ConfigureEnumeration().IsRequired();
    }
}
```
* Query:
```csharp
var result = await myDbContext.MyEntities.FirstAsync(x => x.Id == myEntity.Id); 
```
