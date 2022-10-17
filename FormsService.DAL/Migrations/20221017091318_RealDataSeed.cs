using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormsService.DAL.Migrations
{
    public partial class RealDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "dishes",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "persons",
                keyColumn: "id",
                keyValue: 9);
        }
    }
}
