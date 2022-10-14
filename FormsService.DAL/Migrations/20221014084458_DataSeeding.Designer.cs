﻿// <auto-generated />
using System;
using FormsService.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormsService.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20221014084458_DataSeeding")]
    partial class DataSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FormsService.DAL.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dish 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dish 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dish 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Dish 4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Dish 5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Dish 6"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Dish 7"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Dish 8"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Dish 9"
                        });
                });

            modelBuilder.Entity("FormsService.DAL.Entities.DishOrder", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<int>("DishID")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("OrderID", "DishID");

                    b.HasIndex("DishID");

                    b.ToTable("DishOrders", (string)null);

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            DishID = 1,
                            Id = 1,
                            Price = 50
                        },
                        new
                        {
                            OrderID = 2,
                            DishID = 2,
                            Id = 2,
                            Price = 240
                        },
                        new
                        {
                            OrderID = 3,
                            DishID = 3,
                            Id = 3,
                            Price = 210
                        },
                        new
                        {
                            OrderID = 4,
                            DishID = 4,
                            Id = 4,
                            Price = 280
                        },
                        new
                        {
                            OrderID = 5,
                            DishID = 5,
                            Id = 5,
                            Price = 500
                        },
                        new
                        {
                            OrderID = 6,
                            DishID = 6,
                            Id = 6,
                            Price = 660
                        },
                        new
                        {
                            OrderID = 7,
                            DishID = 7,
                            Id = 7,
                            Price = 840
                        },
                        new
                        {
                            OrderID = 8,
                            DishID = 8,
                            Id = 8,
                            Price = 160
                        },
                        new
                        {
                            OrderID = 9,
                            DishID = 9,
                            Id = 9,
                            Price = 720
                        });
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateForming")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Location")
                        .HasColumnType("integer");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateForming = new DateTimeOffset(new DateTime(2022, 9, 30, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 1,
                            PersonId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateForming = new DateTimeOffset(new DateTime(2022, 10, 1, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1676), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 0,
                            PersonId = 2
                        },
                        new
                        {
                            Id = 3,
                            DateForming = new DateTimeOffset(new DateTime(2022, 10, 6, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 1,
                            PersonId = 3
                        },
                        new
                        {
                            Id = 4,
                            DateForming = new DateTimeOffset(new DateTime(2022, 9, 30, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 0,
                            PersonId = 4
                        },
                        new
                        {
                            Id = 5,
                            DateForming = new DateTimeOffset(new DateTime(2022, 10, 13, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1688), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 1,
                            PersonId = 5
                        },
                        new
                        {
                            Id = 6,
                            DateForming = new DateTimeOffset(new DateTime(2022, 10, 10, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 0,
                            PersonId = 6
                        },
                        new
                        {
                            Id = 7,
                            DateForming = new DateTimeOffset(new DateTime(2022, 10, 6, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1698), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 1,
                            PersonId = 7
                        },
                        new
                        {
                            Id = 8,
                            DateForming = new DateTimeOffset(new DateTime(2022, 10, 9, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 0,
                            PersonId = 8
                        },
                        new
                        {
                            Id = 9,
                            DateForming = new DateTimeOffset(new DateTime(2022, 10, 7, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 5, 0, 0, 0)),
                            Location = 1,
                            PersonId = 9
                        });
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Person 1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Person 2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Person 3"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Person 4"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Person 5"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Person 6"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Person 7"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Person 8"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Person 9"
                        });
                });

            modelBuilder.Entity("FormsService.DAL.Entities.DishOrder", b =>
                {
                    b.HasOne("FormsService.DAL.Entities.Dish", "Dish")
                        .WithMany("DishOrders")
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormsService.DAL.Entities.Order", "Order")
                        .WithMany("DishOrders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Order", b =>
                {
                    b.HasOne("FormsService.DAL.Entities.Person", "Person")
                        .WithMany("Orders")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Dish", b =>
                {
                    b.Navigation("DishOrders");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Order", b =>
                {
                    b.Navigation("DishOrders");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Person", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
