using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class Editt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_Companies_CompanyId",
                table: "jobs");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2bd97175-9f20-410e-afd2-e0f9c62e0562", "4ec782ea-887a-4da3-b7f9-e52f77ba5d05" });

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_Companies_CompanyId",
                table: "jobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobs_Companies_CompanyId",
                table: "jobs");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f3de224f-fa95-45f2-89b4-4cf43be9a969", "33b540de-7cd6-414f-866e-a0e5a82d90f0" });

            migrationBuilder.AddForeignKey(
                name: "FK_jobs_Companies_CompanyId",
                table: "jobs",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
