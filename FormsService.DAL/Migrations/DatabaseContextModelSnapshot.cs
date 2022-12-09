﻿// <auto-generated />
using System;
using FormsService.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormsService.DAL.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FormsService.DAL.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DishCategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("dish_category_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_dishes");

                    b.HasIndex("DishCategoryId")
                        .HasDatabaseName("ix_dishes_dish_category_id");

                    b.ToTable("dishes", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DishCategoryId = 1,
                            Name = "Кобб с куриной грудкой"
                        },
                        new
                        {
                            Id = 2,
                            DishCategoryId = 1,
                            Name = "Сельдь под шубой"
                        },
                        new
                        {
                            Id = 3,
                            DishCategoryId = 2,
                            Name = "Грибной крем-суп с пшеничными гренками"
                        },
                        new
                        {
                            Id = 4,
                            DishCategoryId = 2,
                            Name = "Финская сливочная уха"
                        },
                        new
                        {
                            Id = 5,
                            DishCategoryId = 3,
                            Name = "Филе трески на подушке из кус-куса с соусом рататуй"
                        },
                        new
                        {
                            Id = 6,
                            DishCategoryId = 3,
                            Name = "Фахитос из свинины с рисом тяхан"
                        },
                        new
                        {
                            Id = 7,
                            DishCategoryId = 3,
                            Name = "Куриное фрикасе с молодым картофелем"
                        });
                });

            modelBuilder.Entity("FormsService.DAL.Entities.DishCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Салат"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Суп"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Горячее"
                        });
                });

            modelBuilder.Entity("FormsService.DAL.Entities.DishOrder", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<int>("DishID")
                        .HasColumnType("integer")
                        .HasColumnName("dish_id");

                    b.Property<int>("Count")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(1)
                        .HasColumnName("count");

                    b.Property<int>("Price")
                        .HasColumnType("integer")
                        .HasColumnName("price");

                    b.HasKey("OrderID", "DishID")
                        .HasName("pk_dish_orders");

                    b.HasIndex("DishID")
                        .HasDatabaseName("ix_dish_orders_dish_id");

                    b.ToTable("dish_orders", (string)null);
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("DateForming")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_forming");

                    b.Property<int>("Location")
                        .HasColumnType("integer")
                        .HasColumnName("location");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer")
                        .HasColumnName("person_id");

                    b.HasKey("Id")
                        .HasName("pk_orders");

                    b.HasIndex("PersonId")
                        .HasDatabaseName("ix_orders_person_id");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_persons");

                    b.ToTable("persons", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Борисов"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Бухман"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Демидов"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Домашенко"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Менщиков"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Романова"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Смирнов"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Ковзик"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Цилюрик"
                        });
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Dish", b =>
                {
                    b.HasOne("FormsService.DAL.Entities.DishCategory", "Category")
                        .WithMany("Dish")
                        .HasForeignKey("DishCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_dishes_categories_dish_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.DishOrder", b =>
                {
                    b.HasOne("FormsService.DAL.Entities.Dish", "Dish")
                        .WithMany("DishOrders")
                        .HasForeignKey("DishID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_dish_orders_dishes_dish_id");

                    b.HasOne("FormsService.DAL.Entities.Order", "Order")
                        .WithMany("DishOrders")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_dish_orders_orders_order_id");

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Order", b =>
                {
                    b.HasOne("FormsService.DAL.Entities.Person", "Person")
                        .WithMany("Orders")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_persons_person_id");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Dish", b =>
                {
                    b.Navigation("DishOrders");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.DishCategory", b =>
                {
                    b.Navigation("Dish");
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
