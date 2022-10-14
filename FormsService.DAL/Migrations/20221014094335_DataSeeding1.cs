using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsService.DAL.Migrations
{
    public partial class DataSeeding1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "DishOrders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 1, 60 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 2, 2 },
                column: "Count",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 3, 90 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 4, 4 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 4, 40 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 5, 5 },
                column: "Count",
                value: 5);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 6, 540 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 7, 7 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 7, 280 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 8, 8 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 8, 480 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 9, 9 },
                columns: new[] { "Count", "Price" },
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Count", "Price" },
                values: new object[] { 0, 50 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 2, 2 },
                column: "Count",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 3, 3 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 0, 210 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 4, 4 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 0, 280 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 5, 5 },
                column: "Count",
                value: 0);

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 6, 6 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 0, 660 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 7, 7 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 0, 840 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 8, 8 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 0, 160 });

            migrationBuilder.UpdateData(
                table: "DishOrders",
                keyColumns: new[] { "DishID", "OrderID" },
                keyValues: new object[] { 9, 9 },
                columns: new[] { "Count", "Price" },
                values: new object[] { 0, 720 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 9, 30, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1630), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 1, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1676), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 6, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1680), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 9, 30, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1684), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 13, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1688), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 10, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 6, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1698), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 9, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1701), new TimeSpan(0, 5, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateForming",
                value: new DateTimeOffset(new DateTime(2022, 10, 7, 13, 44, 58, 114, DateTimeKind.Unspecified).AddTicks(1705), new TimeSpan(0, 5, 0, 0, 0)));
        }
    }
}
