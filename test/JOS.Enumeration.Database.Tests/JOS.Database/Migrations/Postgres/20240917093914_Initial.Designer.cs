﻿// <auto-generated />
using System;
using JOS.Enumeration.Database.Tests.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JOS.Enumeration.Database.Tests.JOS.Database.Migrations.Postgres
{
    [DbContext(typeof(JosEnumerationDbContext))]
    [Migration("20240917093914_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JOS.Enumeration.Database.Tests.MyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Car")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string[]>("Cars")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int>("Hamburger")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("MyEntities");
                });
#pragma warning restore 612, 618
        }
    }
}