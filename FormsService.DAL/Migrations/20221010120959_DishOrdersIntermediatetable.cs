using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsService.DAL.Migrations
{
    public partial class DishOrdersIntermediatetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dishes_DishesId",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Orders_OrdersId",
                table: "DishOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder");

            migrationBuilder.DropIndex(
                name: "IX_DishOrder_OrdersId",
                table: "DishOrder");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "DishOrder",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "DishesId",
                table: "DishOrder",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "DishOrder",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "DishOrder",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "DishOrder",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder",
                columns: new[] { "OrderID", "DishID" });

            migrationBuilder.CreateIndex(
                name: "IX_DishOrder_DishID",
                table: "DishOrder",
                column: "DishID");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dishes_DishID",
                table: "DishOrder",
                column: "DishID",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Orders_OrderID",
                table: "DishOrder",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Dishes_DishID",
                table: "DishOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrder_Orders_OrderID",
                table: "DishOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder");

            migrationBuilder.DropIndex(
                name: "IX_DishOrder_DishID",
                table: "DishOrder");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "DishOrder");

            migrationBuilder.DropColumn(
                name: "DishID",
                table: "DishOrder");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "DishOrder");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "DishOrder",
                newName: "OrdersId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "DishOrder",
                newName: "DishesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrder",
                table: "DishOrder",
                columns: new[] { "DishesId", "OrdersId" });

            migrationBuilder.CreateIndex(
                name: "IX_DishOrder_OrdersId",
                table: "DishOrder",
                column: "OrdersId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Dishes_DishesId",
                table: "DishOrder",
                column: "DishesId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrder_Orders_OrdersId",
                table: "DishOrder",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
