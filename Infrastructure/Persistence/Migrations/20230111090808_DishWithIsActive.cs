using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DishWithIsActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "dishes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 1,
                column: "is_active",
                value: false);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 2,
                column: "is_active",
                value: false);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 3,
                column: "is_active",
                value: false);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 4,
                column: "is_active",
                value: false);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 5,
                column: "is_active",
                value: false);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 6,
                column: "is_active",
                value: false);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 7,
                column: "is_active",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "dishes");
        }
    }
}
