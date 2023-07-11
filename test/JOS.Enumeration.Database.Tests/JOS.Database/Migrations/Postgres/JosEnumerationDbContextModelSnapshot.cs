﻿// <auto-generated />
using System;
using JOS.Enumeration.Database.Tests.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JOS.Enumeration.Database.Tests.JOS.Database.Migrations.Postgres
{
    [DbContext(typeof(JosEnumerationDbContext))]
    partial class JosEnumerationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JOS.Enumeration.Database.Tests.MyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Car")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("car");

                    b.Property<int>("Hamburger")
                        .HasColumnType("integer")
                        .HasColumnName("hamburger");

                    b.HasKey("Id")
                        .HasName("pk_my_entities");

                    b.ToTable("my_entities", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}