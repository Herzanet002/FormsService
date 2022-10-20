using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormsService.DAL.Migrations
{
    public partial class InitImproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dishes", x => x.id);
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
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    location = table.Column<int>(type: "integer", nullable: false),
                    date_forming = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orders", x => x.id);
                    table.ForeignKey(
                        name: "fk_orders_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dish_orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "integer", nullable: false),
                    dish_id = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<int>(type: "integer", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dish_orders", x => new { x.order_id, x.dish_id });
                    table.ForeignKey(
                        name: "fk_dish_orders_dishes_dish_id",
                        column: x => x.dish_id,
                        principalTable: "dishes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dish_orders_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "dishes",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Кобб с куриной грудкой" },
                    { 2, "Сельдь под шубой" },
                    { 3, "Грибной крем-суп с пшеничными гренками" },
                    { 4, "Финская сливочная уха" },
                    { 5, "Филе трески на подушке из кус-куса с соусом рататуй" },
                    { 6, "Фахитос из свинины с рисом тяхан" },
                    { 7, "Куриное фрикасе с молодым картофелем" }
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

            migrationBuilder.CreateIndex(
                name: "ix_dish_orders_dish_id",
                table: "dish_orders",
                column: "dish_id");

            migrationBuilder.CreateIndex(
                name: "ix_orders_person_id",
                table: "orders",
                column: "person_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dish_orders");

            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
