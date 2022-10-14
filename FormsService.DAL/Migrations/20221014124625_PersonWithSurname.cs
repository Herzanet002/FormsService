using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsService.DAL.Migrations
{
    public partial class PersonWithSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "DishOrders");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Persons",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "DishOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 1, 1 },
                column: "Price",
                value: 140);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 2, 2 },
                column: "Price",
                value: 40);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 3, 3 },
                column: "Price",
                value: 240);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 4, 4 },
                column: "Price",
                value: 520);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 5, 5 },
                column: "Price",
                value: 700);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 6, 6 },
                column: "Price",
                value: 360);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 7, 7 },
                column: "Price",
                value: 560);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 8, 8 },
                column: "Price",
                value: 1120);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 9, 9 },
                column: "Price",
                value: 540);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 9, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4052), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 9, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4099), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4103), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 4, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4106), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 2, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4109), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 8, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4114), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 13, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4117), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 10, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4120), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 9, 30, 17, 46, 24, 737, DateTimeKind.Unspecified).AddTicks(4124), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 1", "Surname 1" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 2", "Surname 2" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 3", "Surname 3" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 4", "Surname 4" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 5", "Surname 5" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 6", "Surname 6" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 7", "Surname 7" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 8", "Surname 8" });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "Surname" },
                values: new object[] { "Name 9", "Surname 9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "DishOrders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DishOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 1, 60 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 2, 240 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 3, 90 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 4, 4 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 4, 40 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 5, 5 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 5, 500 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 6, 540 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 7, 7 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 7, 280 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 8, 8 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 8, 480 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 9, 9 },
                columns: new[] { "Id", "Price" },
                values: new object[] { 9, 1170 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 11, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6022), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 11, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6068), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 5, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6108), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 5, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6112), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 2, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6116), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 4, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6122), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 1, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6125), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 4, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6127), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 12, 14, 43, 35, 483, DateTimeKind.Unspecified).AddTicks(6131), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Person 1");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Person 2");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Person 3");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Person 4");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Person 5");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Person 6");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Person 7");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "Person 8");

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9,
                column: "Name",
                value: "Person 9");
        }
    }
}
