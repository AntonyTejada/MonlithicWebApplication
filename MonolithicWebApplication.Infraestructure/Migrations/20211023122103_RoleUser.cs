using Microsoft.EntityFrameworkCore.Migrations;

namespace MonolithicWebApplication.Infraestructure.Migrations
{
    public partial class RoleUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "3a89a87a-df2e-4bc6-a763-d488167ad36e");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e60d3e88-ff7e-4f41-8956-73509eecd8ed", "AQAAAAEAACcQAAAAEEBtQDdHrtIi9W+N/6kMA2MgK6yJhmcdqmKJhcKXPRmJGR7tnwBD5aV7YdPjg5SEnA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f-9eab-4bb9-9fca-30b01540f445", "a18be9c0-aa65-4af8-bd17-00bd9344e575" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f-9eab-4bb9-9fca-30b01540f445",
                column: "ConcurrencyStamp",
                value: "012230de-4126-4897-841b-1424c147e72c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d639a1e0-b30d-484b-895b-a973356cf9a3", "AQAAAAEAACcQAAAAEBE1SwT6C+E3gDOUHccoyyHtj1uHyMVzM30RSFiX4jNF84ePInWiZ9S2dElhEbLPFg==" });
        }
    }
}
