using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGS.BusinessObjects.Migrations
{
    public partial class ordercustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "4262d1d3-5d20-4cba-8898-60e0bcbbd3ab", "55f1c780-ae26-40bf-aa84-57ceac0bcc0a", "Admin", "ApplicationRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "7c267efa-8975-47c9-bd21-dc8c714b8f12", "e044d34f-b3ae-4659-a6e5-10ef5da58d05", "Customer", "ApplicationRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "8466368b-df10-43e1-8411-e4fd4e679ab8", "b89d2cc4-87e8-42cd-9627-eb4558439eef", "Staff", "ApplicationRole", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4262d1d3-5d20-4cba-8898-60e0bcbbd3ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c267efa-8975-47c9-bd21-dc8c714b8f12");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8466368b-df10-43e1-8411-e4fd4e679ab8");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Order");

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
    }
}
