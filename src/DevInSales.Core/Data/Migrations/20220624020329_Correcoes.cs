using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Core.Data.Migrations
{
    public partial class Correcoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "35d0c766-999b-4a92-8132-391194399510", "AQAAAAEAACcQAAAAEM074sIqWK2leBWiee7tBMUushnsLgEXEEiJYw3gMceWqB2KrYCY69asbuvZagRczA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ab2c5fbb-bb63-4976-9c9b-3dd46cd12e98");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "edb04cbc-a249-4d43-a9ab-d73af1a9921f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "91f8d8b1-8399-4296-8655-7d0365b9f583");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "892f2989-0dc1-4243-a345-346e8943b61a", "AQAAAAEAACcQAAAAEHqPHpKjH8DCvqjgdnGvGADJKphVnEHKbM8SkNZUdCJbx0/tcUyHFuIkoyMU2prNWQ==" });
        }
    }
}
