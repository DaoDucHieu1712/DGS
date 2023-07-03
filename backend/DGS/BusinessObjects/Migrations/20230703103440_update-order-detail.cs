using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGS.BusinessObjects.Migrations
{
    public partial class updateorderdetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a261a42-5027-4557-9a96-33ce7dc3929f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78ada912-692a-431c-9ef6-3a0cf7207848");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "816a74c4-d1e2-4034-8b8c-015337028201");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "OrderDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "35500caf-5b50-4577-b829-206b53c7e1ea", "8fff783f-1655-4451-9307-1f55421ece9a", "Staff", "ApplicationRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "3a936d63-5f09-4b59-b888-af2e4dd4180e", "d97aa97a-944e-4971-af7d-6b83e157d3b9", "Admin", "ApplicationRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "9969ca02-d2ec-4eb4-b872-ad3f003e03d0", "3f8f0cb8-2352-4671-99d9-76f7baa6abea", "Customer", "ApplicationRole", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35500caf-5b50-4577-b829-206b53c7e1ea");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a936d63-5f09-4b59-b888-af2e4dd4180e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9969ca02-d2ec-4eb4-b872-ad3f003e03d0");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "1a261a42-5027-4557-9a96-33ce7dc3929f", "0dc1f79a-0e27-4b39-a613-c8fde0055704", "Staff", "ApplicationRole", "Staff", "STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "78ada912-692a-431c-9ef6-3a0cf7207848", "3dfdeaaf-85a2-494c-8333-86f5cb5de43f", "Customer", "ApplicationRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "816a74c4-d1e2-4034-8b8c-015337028201", "918adc7c-8d2e-4e0f-b559-0bd3fdd032a6", "Admin", "ApplicationRole", "Admin", "ADMIN" });
        }
    }
}
