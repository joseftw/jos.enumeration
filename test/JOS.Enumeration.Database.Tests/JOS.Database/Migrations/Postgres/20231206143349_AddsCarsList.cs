using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JOS.Enumeration.Database.Tests.JOS.Database.Migrations.Postgres;

/// <inheritdoc />
public partial class AddsCarsList : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string[]>(
            name: "cars",
            table: "my_entities",
            type: "text[]",
            nullable: false,
            defaultValue: new string[0]);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "cars",
            table: "my_entities");
    }
}
