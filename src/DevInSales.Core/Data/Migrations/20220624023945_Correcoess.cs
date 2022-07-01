using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Core.Data.Migrations
{
    public partial class Correcoess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "64c32bbb-6ab9-41ed-ba4a-da6b6768ad9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4d7ed6e8-7bcf-4871-9971-00d12da60fdf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "befc92d5-2a97-4772-b192-3bd370de2d96");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "fa964666-e230-4a8c-9d4e-4e50d354f15b", "ALLIE.SPENCER@MANUEL.US", "AQAAAAEAACcQAAAAEAHdAV0dq1nZru2JqaJ3dNxRCYXUxESS0F4jYl2RKQzdG+9+oG3xSsQN14EPFaKDng==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6a8a84a0-d2d1-45c3-97ed-d750b9c8c266");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "985b7cae-81ef-4784-9dc7-fd0c81ede28f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "23d3e57f-6cd7-40b2-8883-af190a652b00");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "91a4765c-d8d4-4867-a2da-2215b72adf07", null, "AQAAAAEAACcQAAAAEM6a6Hi93dqm7gpzihfUzEwfYlKMHJSFESzOTYaCrfNgYNwaG4W1GKRIIDggBEoa6w==" });
        }
    }
}
