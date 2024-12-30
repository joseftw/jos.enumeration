using Dapper;
using JOS.Enumeration.Database.Dapper;
using JOS.Enumeration.Database.Tests.JOS.Test;
using JOS.Enumerations;
using Npgsql;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
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
        var cars = new[] { Car.FerrariSpider, Car.TeslaModelY };
        var myEntity = new MyEntity(Guid.NewGuid(), Hamburger.BigMac, Car.TeslaModelY, cars);
        await using var arrangeConnection = new NpgsqlConnection(_fixture.PostgresDatabaseOptions.ConnectionString);
        SqlMapper.AddTypeHandler(new EnumerationTypeHandler<Hamburger>());
        SqlMapper.AddTypeHandler(new EnumerationTypeHandler<string, Car>());
        SqlMapper.AddTypeHandler(new EnumerationArrayTypeHandler<string, Car>());
        const string insertSql = """
            INSERT INTO "MyEntities"
            VALUES (@id, @hamburger, @car, @cars)
        """;
        await arrangeConnection.ExecuteAsync(insertSql, new
        {
            id = myEntity.Id,
            car = myEntity.Car,
            hamburger = myEntity.Hamburger,
            cars = myEntity.Cars
        });
        await using var actConnection = new NpgsqlConnection(_fixture.PostgresDatabaseOptions.ConnectionString);
        var selectSql = """
            SELECT "Id", "Hamburger", "Car", "Cars" from "MyEntities" WHERE "Id" = @id
            """;
        var results = (await actConnection.QueryAsync<MyEntity>(selectSql, new { Id = myEntity.Id })).ToList();

        results.ShouldNotBeNull();
        results.Count.ShouldBe(1);
        var result = results.First();
        result.Id.ShouldBe(myEntity.Id);
        result.Hamburger.ShouldBe(myEntity.Hamburger);
        result.Car.ShouldBe(myEntity.Car);
        result.Cars.ShouldBe(cars);
    }
}
