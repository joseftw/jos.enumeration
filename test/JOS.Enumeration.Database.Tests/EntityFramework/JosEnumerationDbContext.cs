using Microsoft.EntityFrameworkCore;

namespace JOS.Enumeration.Database.Tests.EntityFramework;

public class JosEnumerationDbContext : DbContext
{
    public JosEnumerationDbContext(PostgresDatabaseOptions postgresDatabaseOptions)
        : base(postgresDatabaseOptions.DbContextOptions)
    {
    }

    public DbSet<MyEntity> MyEntities { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new MyEntityEntityTypeConfiguration().Configure(modelBuilder.Entity<MyEntity>());
    }
}
