using JOS.Enumeration.Database.EntityFrameworkCore;
using JOS.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JOS.Enumeration.Database.Tests;

public class MyEntityEntityTypeConfiguration : IEntityTypeConfiguration<MyEntity>
{
    public void Configure(EntityTypeBuilder<MyEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Hamburger).ConfigureEnumeration().IsRequired();
        builder.Property(x => x.Car).ConfigureEnumeration<string, Car>().IsRequired();
        builder.ConfigureEnumeration<MyEntity, string, Car>(x => x.Cars).IsRequired();
    }
}
