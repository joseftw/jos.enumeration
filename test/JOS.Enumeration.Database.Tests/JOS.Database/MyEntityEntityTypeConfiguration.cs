using JOS.Enumeration.Database.EntityFrameworkCore;
using JOS.Enumerations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JOS.Enumeration.Database.Tests.JOS.Database;

public class MyEntityEntityTypeConfiguration : IEntityTypeConfiguration<MyEntity>
{
    public void Configure(EntityTypeBuilder<MyEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Hamburger).ConfigureEnumeration().IsRequired();
        builder.Property(x => x.Car).ConfigureEnumeration<string, Car>().IsRequired();
#if NET8_0_OR_GREATER
        builder.ConfigureEnumeration<MyEntity, string, Car>(x => x.Cars).IsRequired();
#else
        builder.Property(x => x.Cars)
               .HasPostgresArrayConversion(x => x.Value, x => Car.FromValue(x))
               .IsRequired();
#endif
    }
}
