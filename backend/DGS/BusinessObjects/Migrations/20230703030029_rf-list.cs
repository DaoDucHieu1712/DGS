using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGS.BusinessObjects.Migrations
{
    public partial class rflist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IssuedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "69307895-d85c-4cb3-baa0-7a12a7ffe579", "5fc753ab-baf6-45a5-8c8b-9a3be34c58de", "Admin", "ApplicationRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "85f88382-0107-401d-88c2-6f0085572413", "320da933-9efa-4172-937e-264d73d0f40d", "Customer", "ApplicationRole", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "a822b32e-16d4-4e5c-9444-5e4ee761a02d", "5a3e9271-c40c-47dd-a856-01ec4ba58e08", "Staff", "ApplicationRole", "Staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69307895-d85c-4cb3-baa0-7a12a7ffe579");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f88382-0107-401d-88c2-6f0085572413");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a822b32e-16d4-4e5c-9444-5e4ee761a02d");

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
    }
}
