using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class Edittt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_Companies_CompanyId",
                table: "jobs");

            migrationBuilder.DropIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "jobs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2c3c89e6-5cda-4d93-be27-0a2f3555a832", "71fbfc27-67a1-48cd-aa0f-5fe9cb0b923f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "jobs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2bd97175-9f20-410e-afd2-e0f9c62e0562", "4ec782ea-887a-4da3-b7f9-e52f77ba5d05" });

            migrationBuilder.CreateIndex(
                name: "IX_jobs_CompanyId",
                table: "jobs",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_Companies_CompanyId",
                table: "jobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
