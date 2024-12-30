using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace JOS.Enumeration.Database.Tests.JOS.Database.Migrations.Postgres;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "MyEntities",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uuid", nullable: false),
                Hamburger = table.Column<int>(type: "integer", nullable: false),
                Car = table.Column<string>(type: "text", nullable: false),
                Cars = table.Column<string[]>(type: "text[]", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_MyEntities", x => x.Id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "MyEntities");
    }
}
