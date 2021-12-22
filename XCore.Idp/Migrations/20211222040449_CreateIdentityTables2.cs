using Microsoft.EntityFrameworkCore.Migrations;

namespace XCore.Idp.Migrations
{
    public partial class CreateIdentityTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5373a5f-4e1c-448d-af9c-1e150930a7ec",
                column: "ConcurrencyStamp",
                value: "0fb7b2cd-484e-406e-a50d-fd140c1f8489");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6027a9a-8321-403d-93a4-29b8d37e0665",
                column: "ConcurrencyStamp",
                value: "2f734e3a-c7fe-4421-af80-1e1274f6caac");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5373a5f-4e1c-448d-af9c-1e150930a7ec",
                column: "ConcurrencyStamp",
                value: "b4bba82c-1240-430c-8a83-2955884eeda2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6027a9a-8321-403d-93a4-29b8d37e0665",
                column: "ConcurrencyStamp",
                value: "1ca61a90-4484-49fc-8ad8-58bb4fd4b2e6");
        }
    }
}
