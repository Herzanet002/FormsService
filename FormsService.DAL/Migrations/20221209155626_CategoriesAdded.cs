using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FormsService.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_persons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    dishcategoryid = table.Column<int>(name: "dish_category_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dishes", x => x.id);
                    table.ForeignKey(
                        name: "fk_dishes_categories_dish_category_id",
                        column: x => x.dishcategoryid,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    personid = table.Column<int>(name: "person_id", type: "integer", nullable: false),
                    location = table.Column<int>(type: "integer", nullable: false),
                    dateforming = table.Column<DateTimeOffset>(name: "date_forming", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_persons_person_id",
                        column: x => x.personid,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dish_orders",
                columns: table => new
                {
                    orderid = table.Column<int>(name: "order_id", type: "integer", nullable: false),
                    dishid = table.Column<int>(name: "dish_id", type: "integer", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dish_orders", x => new { x.orderid, x.dishid });
                    table.ForeignKey(
                        name: "fk_dish_orders_dishes_dish_id",
                        column: x => x.dishid,
                        principalTable: "dishes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dish_orders_orders_order_id",
                        column: x => x.orderid,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Салат" },
                    { 2, "Суп" },
                    { 3, "Горячее" }
                });

            migrationBuilder.InsertData(
                table: "persons",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Борисов" },
                    { 2, "Бухман" },
                    { 3, "Демидов" },
                    { 4, "Домашенко" },
                    { 5, "Менщиков" },
                    { 6, "Романова" },
                    { 7, "Смирнов" },
                    { 8, "Ковзик" },
                    { 9, "Цилюрик" }
                });

            migrationBuilder.InsertData(
                table: "dishes",
                columns: new[] { "id", "dish_category_id", "name" },
                values: new object[,]
                {
                    { 1, 1, "Кобб с куриной грудкой" },
                    { 2, 1, "Сельдь под шубой" },
                    { 3, 2, "Грибной крем-суп с пшеничными гренками" },
                    { 4, 2, "Финская сливочная уха" },
                    { 5, 3, "Филе трески на подушке из кус-куса с соусом рататуй" },
                    { 6, 3, "Фахитос из свинины с рисом тяхан" },
                    { 7, 3, "Куриное фрикасе с молодым картофелем" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_dish_orders_dish_id",
                table: "dish_orders",
                column: "dish_id");

            migrationBuilder.CreateIndex(
                name: "ix_dishes_dish_category_id",
                table: "dishes",
                column: "dish_category_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_person_id",
                table: "orders",
                column: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dish_orders");

            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
