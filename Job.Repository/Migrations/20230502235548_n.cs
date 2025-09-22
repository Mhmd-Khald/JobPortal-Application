using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3466f3a6-28d6-4c89-8df4-a1fa0f870381", "57fb6ba4-06c2-4449-8fe3-30156636c772" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ff343ebd-fcf1-43cb-98d0-0664618bb798", "1a01e768-c7cb-402c-a9af-cfe341fa1c38" });
        }
    }
}
