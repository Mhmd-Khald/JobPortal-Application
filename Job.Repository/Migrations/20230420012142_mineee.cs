using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class mineee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_jobs_JobsId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_JobsId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "JobsId",
                table: "Application");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "deefe4d1-d285-4a2e-b875-3d886aeacc1d", "6375914b-30ca-4dc5-ac0f-e81de14855b8" });

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobId",
                table: "Application",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_jobs_JobId",
                table: "Application",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_jobs_JobId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_JobId",
                table: "Application");

            migrationBuilder.AddColumn<int>(
                name: "JobsId",
                table: "Application",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a974398-4e0d-45d7-b0bf-ff7f86da02f4", "f7429182-bd3b-477e-8cfb-787928caba6b" });

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobsId",
                table: "Application",
                column: "JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_jobs_JobsId",
                table: "Application",
                column: "JobsId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
