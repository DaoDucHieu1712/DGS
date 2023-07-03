using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGS.BusinessObjects.Migrations
{
    public partial class refreshtoken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "343c147e-01aa-4836-a0ad-17e2cbe017cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "424b8836-276c-4568-9999-8aa6e09d96ba");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d17c68ce-fc34-494d-bcc6-edf38c0b3158");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "57996e2c-988b-4d11-bbbf-7cc9bbe8f70e", "394953af-c8d9-4427-9238-05c31f5ab93d", "Customer", "ApplicationRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "9a8fd843-02f1-40ab-b2c4-862cbf4ad0ce", "90d4638b-1582-4590-855e-1202f7e9b3ac", "Admin", "ApplicationRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "ae03d9d2-ce17-4895-b0c6-f4f5f3ab1585", "7014f19e-44be-4789-9c0f-e490d437d269", "Staff", "ApplicationRole", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57996e2c-988b-4d11-bbbf-7cc9bbe8f70e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a8fd843-02f1-40ab-b2c4-862cbf4ad0ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae03d9d2-ce17-4895-b0c6-f4f5f3ab1585");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "343c147e-01aa-4836-a0ad-17e2cbe017cc", "edacf249-5aea-4931-a2c7-61bbc5c96885", "Admin", "ApplicationRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "424b8836-276c-4568-9999-8aa6e09d96ba", "49ae97c1-7e5a-4b88-a2d2-eb85193ff603", "Staff", "ApplicationRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "d17c68ce-fc34-494d-bcc6-edf38c0b3158", "c577778f-2bf9-469b-a50a-3b961738af01", "Customer", "ApplicationRole", "Customer", "CUSTOMER" });
        }
    }
}
