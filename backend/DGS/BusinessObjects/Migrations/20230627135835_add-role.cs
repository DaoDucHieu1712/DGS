using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGS.BusinessObjects.Migrations
{
    public partial class addrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "792c3361-0a6a-4f73-b528-039feeaaf491", "edc02a37-812f-4e1b-bb7b-362afa2a4f48", "Staff", "ApplicationRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "7a1a0133-ae07-4d05-b368-2fe0c02f3b97", "1edcb972-be82-4567-b85a-029c58f08d5d", "Admin", "ApplicationRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "fac69cfc-706a-4924-b799-de1f6c7edfea", "401ed696-348a-4462-ac3b-a015bc241752", "Customer", "ApplicationRole", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "792c3361-0a6a-4f73-b528-039feeaaf491");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a1a0133-ae07-4d05-b368-2fe0c02f3b97");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fac69cfc-706a-4924-b799-de1f6c7edfea");
        }
    }
}
