using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsService.DAL.Migrations
{
    public partial class TableNamingConvention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Dishes_DishID",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_DishOrders_Orders_OrderID",
                table: "DishOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Persons_PersonId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "persons");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "Dishes",
                newName: "dishes");

            migrationBuilder.RenameTable(
                name: "DishOrders",
                newName: "dish_orders");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "persons",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "persons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "orders",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "orders",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "DateForming",
                table: "orders",
                newName: "date_forming");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PersonId",
                table: "orders",
                newName: "ix_orders_person_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "dishes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "dishes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "dish_orders",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "dish_orders",
                newName: "count");

            migrationBuilder.RenameColumn(
                name: "DishID",
                table: "dish_orders",
                newName: "dish_id");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "dish_orders",
                newName: "order_id");

            migrationBuilder.RenameIndex(
                name: "IX_DishOrders_DishID",
                table: "dish_orders",
                newName: "ix_dish_orders_dish_id");

            migrationBuilder.AlterColumn<int>(
                name: "count",
                table: "dish_orders",
                type: "integer",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_persons",
                table: "persons",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_dishes",
                table: "dishes",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_dish_orders",
                table: "dish_orders",
                columns: new[] { "order_id", "dish_id" });

            migrationBuilder.AddForeignKey(
                name: "fk_dish_orders_dishes_dish_id",
                table: "dish_orders",
                column: "dish_id",
                principalTable: "dishes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_dish_orders_orders_order_id",
                table: "dish_orders",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_persons_person_id",
                table: "orders",
                column: "person_id",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_dish_orders_dishes_dish_id",
                table: "dish_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_dish_orders_orders_order_id",
                table: "dish_orders");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_persons_person_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_persons",
                table: "persons");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_dishes",
                table: "dishes");

            migrationBuilder.DropPrimaryKey(
                name: "pk_dish_orders",
                table: "dish_orders");

            migrationBuilder.RenameTable(
                name: "persons",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "dishes",
                newName: "Dishes");

            migrationBuilder.RenameTable(
                name: "dish_orders",
                newName: "DishOrders");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Persons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Persons",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Orders",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "Orders",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "date_forming",
                table: "Orders",
                newName: "DateForming");

            migrationBuilder.RenameIndex(
                name: "ix_orders_person_id",
                table: "Orders",
                newName: "IX_Orders_PersonId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Dishes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Dishes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "DishOrders",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "count",
                table: "DishOrders",
                newName: "Count");

            migrationBuilder.RenameColumn(
                name: "dish_id",
                table: "DishOrders",
                newName: "DishID");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "DishOrders",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "ix_dish_orders_dish_id",
                table: "DishOrders",
                newName: "IX_DishOrders_DishID");

            migrationBuilder.AlterColumn<int>(
                name: "Count",
                table: "DishOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldDefaultValue: 1);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dishes",
                table: "Dishes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishOrders",
                table: "DishOrders",
                columns: new[] { "OrderID", "DishID" });

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Dishes_DishID",
                table: "DishOrders",
                column: "DishID",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DishOrders_Orders_OrderID",
                table: "DishOrders",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Persons_PersonId",
                table: "Orders",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}