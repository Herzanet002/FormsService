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
    [Migration("20220930113822_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MailService.Models.MenuModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FirstCourseId")
                        .HasColumnType("integer");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SaladId")
                        .HasColumnType("integer");

                    b.Property<int>("SoupId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FirstCourseId");

                    b.HasIndex("SaladId");

                    b.HasIndex("SoupId");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("MailService.Models.MenuModels.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Dish");
                });

            modelBuilder.Entity("MailService.Models.MenuModel", b =>
                {
                    b.HasOne("MailService.Models.MenuModels.Dish", "FirstCourse")
                        .WithMany()
                        .HasForeignKey("FirstCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MailService.Models.MenuModels.Dish", "Salad")
                        .WithMany()
                        .HasForeignKey("SaladId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MailService.Models.MenuModels.Dish", "Soup")
                        .WithMany()
                        .HasForeignKey("SoupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FirstCourse");

                    b.Navigation("Salad");

                    b.Navigation("Soup");
                });
#pragma warning restore 612, 618
        }
    }
}
