using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FormsService.DAL.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PersonId = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<int>(type: "integer", nullable: false),
                    DateForming = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishOrders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "integer", nullable: false),
                    DishID = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishOrders", x => new { x.OrderID, x.DishID });
                    table.ForeignKey(
                        name: "FK_DishOrders_Dishes_DishID",
                        column: x => x.DishID,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishOrders_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Dish 1" },
                    { 2, "Dish 2" },
                    { 3, "Dish 3" },
                    { 4, "Dish 4" },
                    { 5, "Dish 5" },
                    { 6, "Dish 6" },
                    { 7, "Dish 7" },
                    { 8, "Dish 8" },
                    { 9, "Dish 9" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Person 1" },
                    { 2, "Person 2" },
                    { 3, "Person 3" },
                    { 4, "Person 4" },
                    { 5, "Person 5" },
                    { 6, "Person 6" },
                    { 7, "Person 7" },
                    { 8, "Person 8" },
                    { 9, "Person 9" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DateForming", "Location", "PersonId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 9, 30, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 5, 0, 0, 0)), 1, 1 },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 1, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1676), new TimeSpan(0, 5, 0, 0, 0)), 0, 2 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 6, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 5, 0, 0, 0)), 1, 3 },
                    { 4, new DateTimeOffset(new DateTime(2022, 9, 30, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 5, 0, 0, 0)), 0, 4 },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 13, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1688), new TimeSpan(0, 5, 0, 0, 0)), 1, 5 },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 10, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 5, 0, 0, 0)), 0, 6 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 6, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1698), new TimeSpan(0, 5, 0, 0, 0)), 1, 7 },
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 9, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 5, 0, 0, 0)), 0, 8 },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 7, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 5, 0, 0, 0)), 1, 9 }
                });

            migrationBuilder.InsertData(
                table: "DishOrders",
                columns: new[] { "DishID", "OrderID", "Id", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, 50 },
                    { 2, 2, 2, 240 },
                    { 3, 3, 3, 210 },
                    { 4, 4, 4, 280 },
                    { 5, 5, 5, 500 },
                    { 6, 6, 6, 660 },
                    { 7, 7, 7, 840 },
                    { 8, 8, 8, 160 },
                    { 9, 9, 9, 720 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DishOrders_DishID",
                table: "DishOrders",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PersonId",
                table: "Orders",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DishOrders");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
