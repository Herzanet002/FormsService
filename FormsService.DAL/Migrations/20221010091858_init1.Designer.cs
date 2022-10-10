﻿// <auto-generated />
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
    [Migration("20221010091858_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DishOrder", b =>
                {
                    b.Property<int>("DishesId")
                        .HasColumnType("integer");

                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.HasKey("DishesId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("DishOrder");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("FormsService.DAL.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Location")
                        .HasColumnType("integer");

                    b.Property<int>("PersonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Orders");
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
                });

            modelBuilder.Entity("DishOrder", b =>
                {
                    b.HasOne("FormsService.DAL.Entities.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FormsService.DAL.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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

            modelBuilder.Entity("FormsService.DAL.Entities.Person", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}