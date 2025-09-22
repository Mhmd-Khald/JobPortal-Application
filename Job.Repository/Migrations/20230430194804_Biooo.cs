using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class Biooo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4fa73982-c7bb-4ad4-b245-2cf0cc10161f", "eb0010f2-d3e6-4124-b9f1-d615ce96e13c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "637c2344-6841-406d-a7e3-f9f6c1425914", "c0f896eb-6c9b-41a5-a735-eb30d07f2f07" });
        }
    }
}
