using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DishWithPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "dish_price",
                table: "dishes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 1,
                column: "dish_price",
                value: 100);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 2,
                column: "dish_price",
                value: 120);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 3,
                column: "dish_price",
                value: 150);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 4,
                column: "dish_price",
                value: 140);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 5,
                column: "dish_price",
                value: 180);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 6,
                column: "dish_price",
                value: 170);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 7,
                column: "dish_price",
                value: 165);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dish_price",
                table: "dishes");
        }
    }
}
