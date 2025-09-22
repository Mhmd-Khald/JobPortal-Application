using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class Bio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CVURl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "49e4c74e-8c02-42a1-b7c3-9b46179a3369", "41f52461-d3e0-47fc-b1df-dc8ec43a6e23" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CVURl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "62ba27bc-244e-4cf4-a7db-24e5566c198c", "f0035412-abac-4589-8c3f-319846601be3" });
        }
    }
}
