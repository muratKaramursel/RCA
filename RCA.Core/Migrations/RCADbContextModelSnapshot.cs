﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RCA.Core;

#nullable disable

namespace RCA.Core.Migrations
{
    [DbContext(typeof(RCADbContext))]
    partial class RCADbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RCA.Model.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "IX_Name")
                        .IsUnique();

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Türkiye"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "İngiltere"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "İtalya"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Fransa"
                        },
                        new
                        {
                            Id = 5,
                            IsActive = true,
                            Name = "Almanya"
                        },
                        new
                        {
                            Id = 6,
                            IsActive = true,
                            Name = "Hollanda"
                        },
                        new
                        {
                            Id = 7,
                            IsActive = true,
                            Name = "Belçika"
                        },
                        new
                        {
                            Id = 8,
                            IsActive = true,
                            Name = "Finlandiya"
                        },
                        new
                        {
                            Id = 9,
                            IsActive = true,
                            Name = "Yunanistan"
                        },
                        new
                        {
                            Id = 10,
                            IsActive = true,
                            Name = "İsveç"
                        },
                        new
                        {
                            Id = 11,
                            IsActive = true,
                            Name = "İsviçre"
                        },
                        new
                        {
                            Id = 12,
                            IsActive = true,
                            Name = "Rusya"
                        },
                        new
                        {
                            Id = 13,
                            IsActive = true,
                            Name = "Bulgaristan"
                        },
                        new
                        {
                            Id = 14,
                            IsActive = true,
                            Name = "Norveç"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
