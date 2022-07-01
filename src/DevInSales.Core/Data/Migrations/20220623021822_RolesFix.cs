using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Core.Data.Migrations
{
    public partial class RolesFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "ab2c5fbb-bb63-4976-9c9b-3dd46cd12e98", "administrador" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "edb04cbc-a249-4d43-a9ab-d73af1a9921f", "gerente" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "91f8d8b1-8399-4296-8655-7d0365b9f583", "usuario" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "892f2989-0dc1-4243-a345-346e8943b61a", "AQAAAAEAACcQAAAAEHqPHpKjH8DCvqjgdnGvGADJKphVnEHKbM8SkNZUdCJbx0/tcUyHFuIkoyMU2prNWQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "d1845327-f026-4f69-a424-cb1e5d4500b2", "Administrador" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "c70a42a2-fdf8-4850-9bcb-c47884b9ba83", "Gerente" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "Name" },
                values: new object[] { "0c19ed64-b1f6-4f9e-96e1-981801a1da98", "Usuario" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d906626f-8ecb-45b3-84b3-367ad1fa48be", "AQAAAAEAACcQAAAAEC1UAUceajQFydDEUNlcROoV3CG7Odbh8BbZ7bKkf5F5ZgOkku25HWIdWde+b3XQDQ==" });
        }
    }
}
