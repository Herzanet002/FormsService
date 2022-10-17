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
                    Count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0)
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
                    { 1, "Name 1" },
                    { 2, "Name 2" },
                    { 3, "Name 3" },
                    { 4, "Name 4" },
                    { 5, "Name 5" },
                    { 6, "Name 6" },
                    { 7, "Name 7" },
                    { 8, "Name 8" },
                    { 9, "Name 9" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DateForming", "Location", "PersonId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2022, 10, 8, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8256), new TimeSpan(0, 5, 0, 0, 0)), 1, 1 },
                    { 2, new DateTimeOffset(new DateTime(2022, 10, 5, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8304), new TimeSpan(0, 5, 0, 0, 0)), 0, 2 },
                    { 3, new DateTimeOffset(new DateTime(2022, 10, 12, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8306), new TimeSpan(0, 5, 0, 0, 0)), 1, 3 },
                    { 4, new DateTimeOffset(new DateTime(2022, 10, 6, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8308), new TimeSpan(0, 5, 0, 0, 0)), 0, 4 },
                    { 5, new DateTimeOffset(new DateTime(2022, 10, 9, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8310), new TimeSpan(0, 5, 0, 0, 0)), 1, 5 },
                    { 6, new DateTimeOffset(new DateTime(2022, 10, 2, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8313), new TimeSpan(0, 5, 0, 0, 0)), 0, 6 },
                    { 7, new DateTimeOffset(new DateTime(2022, 10, 12, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8314), new TimeSpan(0, 5, 0, 0, 0)), 1, 7 },
                    { 8, new DateTimeOffset(new DateTime(2022, 10, 1, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8316), new TimeSpan(0, 5, 0, 0, 0)), 0, 8 },
                    { 9, new DateTimeOffset(new DateTime(2022, 10, 2, 1, 57, 17, 694, DateTimeKind.Unspecified).AddTicks(8318), new TimeSpan(0, 5, 0, 0, 0)), 1, 9 }
                });

            migrationBuilder.InsertData(
                table: "DishOrders",
                columns: new[] { "DishID", "OrderID", "Count", "Price" },
                values: new object[,]
                {
                    { 1, 1, 1, 10 },
                    { 2, 2, 2, 80 },
                    { 3, 3, 3, 240 },
                    { 4, 4, 4, 520 },
                    { 5, 5, 5, 100 },
                    { 6, 6, 6, 780 },
                    { 7, 7, 7, 280 },
                    { 8, 8, 8, 80 },
                    { 9, 9, 9, 270 }
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