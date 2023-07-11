using System;
using System.Threading.Tasks;
using JOS.Enumeration.Database.Tests.JOS.Test;
using JOS.Enumerations;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Hamburger = JOS.Enumerations.Hamburger;

namespace JOS.Enumeration.Database.Tests.EntityFramework;

[Collection(DatabaseTestCollection.Name)]
public class EntityFrameworkTests : IClassFixture<JosEnumerationDatabaseFixture>
{
    private readonly JosEnumerationDatabaseFixture _fixture;

    public EntityFrameworkTests(JosEnumerationDatabaseFixture fixture)
    {
        _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task CanSaveAndReadEntityWithEnumeration()
    {
        var myEntity = new MyEntity(Guid.NewGuid(), Hamburger.BigMac, Car.TeslaModelY);
        await using var arrangeDbContext = new JosEnumerationDbContext(_fixture.PostgresDatabaseOptions);
        arrangeDbContext.MyEntities.Add(myEntity);
        await arrangeDbContext.SaveChangesAsync();
        await using var actDbContext = new JosEnumerationDbContext(_fixture.PostgresDatabaseOptions);

        var result = await actDbContext.MyEntities.FirstAsync(x => x.Id == myEntity.Id);

        result.ShouldNotBeNull();
        result.Id.ShouldBe(myEntity.Id);
        result.Hamburger.ShouldBe(myEntity.Hamburger);
        result.Car.ShouldBe(myEntity.Car);
    }
}
