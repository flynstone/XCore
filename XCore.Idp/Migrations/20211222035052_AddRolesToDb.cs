using Microsoft.EntityFrameworkCore.Migrations;

namespace XCore.Idp.Migrations
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5373a5f-4e1c-448d-af9c-1e150930a7ec",
                column: "ConcurrencyStamp",
                value: "6cd0275d-3fed-40ac-9aa1-79cb9adee27e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6027a9a-8321-403d-93a4-29b8d37e0665",
                column: "ConcurrencyStamp",
                value: "ccd15d2e-8ad3-4340-bda8-8559cc28a4d8");
        }
    }
}
