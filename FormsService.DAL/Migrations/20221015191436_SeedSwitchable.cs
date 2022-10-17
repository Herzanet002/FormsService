using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsService.DAL.Migrations
{
    public partial class SeedSwitchable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}