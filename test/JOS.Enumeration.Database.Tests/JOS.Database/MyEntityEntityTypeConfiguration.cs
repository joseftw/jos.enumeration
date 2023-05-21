using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JOS.Enumeration.Database.Tests.JOS.Database;

public class MyEntityEntityTypeConfiguration : IEntityTypeConfiguration<MyEntity>
{
    public void Configure(EntityTypeBuilder<MyEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Hamburger).ConfigureEnumeration().IsRequired();
    }
}
