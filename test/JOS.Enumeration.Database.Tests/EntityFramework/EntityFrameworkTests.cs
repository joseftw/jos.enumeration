using JOS.Enumeration.Database.Tests.JOS.Database;
using JOS.Enumerations;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace JOS.Enumeration.Database.Tests.EntityFramework;

[Collection(DatabaseTestCollection.Name)]
public class EntityFrameworkTests : IClassFixture<JosEnumerationDatabaseFixture>
{
    private readonly JosEnumerationDatabaseFixture _fixture;
    private readonly CancellationToken _cancellationToken;

    public EntityFrameworkTests(JosEnumerationDatabaseFixture fixture, ITestContextAccessor testContextAccessor)
    {
        _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
        _cancellationToken = testContextAccessor.Current.CancellationToken;
    }

    [Fact]
    public async Task CanSaveAndReadEntityWithEnumeration()
    {
        var cars = new[] { Car.FerrariSpider, Car.TeslaModelY };
        var myEntity = new MyEntity(Guid.NewGuid(), Hamburger.BigMac, Car.TeslaModelY, cars);
        await using var arrangeDbContext = new JosEnumerationDbContext(_fixture.PostgresDatabaseOptions);
        arrangeDbContext.MyEntities.Add(myEntity);
        await arrangeDbContext.SaveChangesAsync(_cancellationToken);
        await using var actDbContext = new JosEnumerationDbContext(_fixture.PostgresDatabaseOptions);

        var result = await actDbContext.MyEntities.FirstAsync(x => x.Id == myEntity.Id, _cancellationToken);

        result.ShouldNotBeNull();
        result.Id.ShouldBe(myEntity.Id);
        result.Hamburger.ShouldBe(myEntity.Hamburger);
        result.Car.ShouldBe(myEntity.Car);
        result.Cars.ShouldBe(cars);
    }
}
