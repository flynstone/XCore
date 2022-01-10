using Microsoft.EntityFrameworkCore.Migrations;

namespace XCore.Api.Migrations
{
    public partial class SeedRentalProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description" },
                values: new object[,]
                {
                    { 1, "Blu-Ray" },
                    { 2, "DVD" },
                    { 3, "Game" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "123 Fake Street", "Shaelyn", " Mayson" },
                    { 2, "337 Lost Street", " Byrne", "Harvey" },
                    { 3, "456 Fake Boulevard", "Benny", "Shana" },
                    { 4, "98 Main Street", " Xzavier", "Tawnie" },
                    { 5, "123 County Road", "Flo", "Sondra" },
                    { 6, "223 Fake Street", "Leatrice", "Paul" },
                    { 7, "456 Fake Boulevard", "Braeden", "Mayson" },
                    { 8, "98 Main Street", "Angela", "Callan" },
                    { 9, "123 County Road", " Lydia", "Gavin" },
                    { 10, "223 Fake Street", "Jess", "Autumn" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10);
        }
    }
}
