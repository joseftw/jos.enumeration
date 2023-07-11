using System;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using JOS.Enumeration.Database.Dapper;
using JOS.Enumeration.Database.Tests.JOS.Test;
using JOS.Enumerations;
using Npgsql;
using Shouldly;
using Xunit;

namespace JOS.Enumeration.Database.Tests.Dapper;

[Collection(DatabaseTestCollection.Name)]
public class DapperTests : IClassFixture<JosEnumerationDatabaseFixture>
{
    private readonly JosEnumerationDatabaseFixture _fixture;

    public DapperTests(JosEnumerationDatabaseFixture fixture)
    {
        _fixture = fixture ?? throw new ArgumentNullException(nameof(fixture));
    }

    [Fact]
    public async Task CanSaveAndReadEntityWithEnumeration()
    {
        var myEntity = new MyEntity(Guid.NewGuid(), Hamburger.BigMac, Car.TeslaModelY);
        await using var arrangeConnection = new NpgsqlConnection(_fixture.PostgresDatabaseOptions.ConnectionString);
        SqlMapper.AddTypeHandler(new EnumerationTypeHandler<Hamburger>());
        SqlMapper.AddTypeHandler(new EnumerationTypeHandler<string, Car>());
        const string insertSql = """
            INSERT INTO my_entities
            VALUES (@id, @hamburger, @car)
        """;
        await arrangeConnection.ExecuteAsync(insertSql, new
        {
            id = myEntity.Id,
            car = myEntity.Car,
            hamburger = myEntity.Hamburger
        });
        await using var actConnection = new NpgsqlConnection(_fixture.PostgresDatabaseOptions.ConnectionString);

        var results = (await actConnection.QueryAsync<MyEntity>(
            "SELECT id, hamburger, car from my_entities WHERE id = @id", new { id = myEntity.Id })).ToList();

        results.ShouldNotBeNull();
        results.Count.ShouldBe(1);
        var result = results.First();
        result.Id.ShouldBe(myEntity.Id);
        result.Hamburger.ShouldBe(myEntity.Hamburger);
        result.Car.ShouldBe(myEntity.Car);
    }
}
