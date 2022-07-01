using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Core.Data.Migrations
{
    public partial class CorrecoesSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "91a4765c-d8d4-4867-a2da-2215b72adf07", "allie.spencer@manuel.us", "AQAAAAEAACcQAAAAEM6a6Hi93dqm7gpzihfUzEwfYlKMHJSFESzOTYaCrfNgYNwaG4W1GKRIIDggBEoa6w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "898dc420-5727-4b92-90a2-6bba40d259d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "4ad2d65c-dba4-4e71-9d45-71a9c4f6d426");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "69e25bdd-3260-4b0e-8a45-714e32da04c4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Email", "PasswordHash" },
                values: new object[] { "35d0c766-999b-4a92-8132-391194399510", "Allie.Spencer@manuel.us", "AQAAAAEAACcQAAAAEM074sIqWK2leBWiee7tBMUushnsLgEXEEiJYw3gMceWqB2KrYCY69asbuvZagRczA==" });
        }
    }
}
