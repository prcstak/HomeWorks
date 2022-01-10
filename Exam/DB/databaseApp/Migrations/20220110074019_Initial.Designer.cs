﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using databaseApp.DataBase;

namespace databaseApp.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220110074019_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("databaseApp.Models.Creature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AC")
                        .HasColumnType("integer");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("integer");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("integer");

                    b.Property<int>("Damage")
                        .HasColumnType("integer");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("integer");

                    b.Property<int>("Dice")
                        .HasColumnType("integer");

                    b.Property<int>("HitPoints")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.Property<int>("Weapon")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Creature");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AC = 12,
                            AttackModifier = 5,
                            AttackPerRound = 1,
                            Damage = 12,
                            DamageModifier = 6,
                            Dice = 8,
                            HitPoints = 59,
                            UserName = "Griffon",
                            Weapon = 6
                        },
                        new
                        {
                            Id = 2,
                            AC = 17,
                            AttackModifier = 5,
                            AttackPerRound = 2,
                            Damage = 12,
                            DamageModifier = 2,
                            Dice = 6,
                            HitPoints = 161,
                            UserName = "Djinni",
                            Weapon = 9
                        },
                        new
                        {
                            Id = 3,
                            AC = 11,
                            AttackModifier = 0,
                            AttackPerRound = 1,
                            Damage = 1,
                            DamageModifier = 0,
                            Dice = 6,
                            HitPoints = 3,
                            UserName = "Frog",
                            Weapon = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
