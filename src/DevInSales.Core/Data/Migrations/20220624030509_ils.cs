using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Core.Data.Migrations
{
    public partial class ils : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "20c5da6a-2bcf-4c63-8429-69826114ab91");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2ba5622b-1922-479a-9f88-5cbb8152b2b0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2cf1934a-f4da-43f8-8348-a4ffb075647c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "888bd89f-fa0d-4f5d-b0a6-04673aad3f26", "AQAAAAEAACcQAAAAEE4bBSAh13cie7Eo7nhRx0N806Vg1FxnV+RngtdsyLBZj+zIHZvrsIiO28utQCVorA==", "340ac537-ac16-4bae-91c8-bd015ac48bf5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "96101b19-0574-4371-867f-1073b6362f3a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0238bb32-6627-4f3c-8b88-42bcf70fc40a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "ee01415c-ef7f-47e2-a748-772617606d25");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e4c3a1d-fcac-4b4f-b663-4e21daa14cd0", "AQAAAAEAACcQAAAAEBxCDnB/AWJd+GuSlTt1dkrXcvf/iTqEuZqhr5zf+b9OH6OcPR8O9k0EUMAXui+88Q==", null });
        }
    }
}
