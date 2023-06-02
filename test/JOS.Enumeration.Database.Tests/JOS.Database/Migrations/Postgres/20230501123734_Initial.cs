using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JOS.Enumeration.Database.Tests.JOS.Database.Migrations.Postgres;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "my_entities",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                hamburger = table.Column<int>(type: "integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("pk_my_entities", x => x.id);
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "my_entities");
    }
}