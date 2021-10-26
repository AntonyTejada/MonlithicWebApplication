using Microsoft.EntityFrameworkCore.Migrations;

namespace MonolithicWebApplication.Infraestructure.Migrations
{
    public partial class InitialAdminUserCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "012230de-4126-4897-841b-1424c147e72c", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a18be9c0-aa65-4af8-bd17-00bd9344e575", 0, "d639a1e0-b30d-484b-895b-a973356cf9a3", "IdentityUser", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin@gmail.com", "AQAAAAEAACcQAAAAEBE1SwT6C+E3gDOUHccoyyHtj1uHyMVzM30RSFiX4jNF84ePInWiZ9S2dElhEbLPFg==", null, false, "", false, "admin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575");
        }
    }
}
