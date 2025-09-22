using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class newerrrrrrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_AspNetUsers_AppuserId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_jobs_JobId",
                table: "JobApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplication_JobSeekers_JobSeekerId",
                table: "JobApplication");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication");

            migrationBuilder.RenameTable(
                name: "JobApplication",
                newName: "Application");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_JobSeekerId",
                table: "Application",
                newName: "IX_Application_JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_JobApplication_JobId",
                table: "Application",
                newName: "IX_Application_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                columns: new[] { "AppuserId", "JobId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f1230f9e-54be-40ef-bb82-93e21620b0f4", "781e583d-20fb-4659-90da-6041cadfce0c" });

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_AppuserId",
                table: "Application",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_jobs_JobId",
                table: "Application",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_JobSeekers_JobSeekerId",
                table: "Application",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_AppuserId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_jobs_JobId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_JobSeekers_JobSeekerId",
                table: "Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "JobApplication");

            migrationBuilder.RenameIndex(
                name: "IX_Application_JobSeekerId",
                table: "JobApplication",
                newName: "IX_JobApplication_JobSeekerId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_JobId",
                table: "JobApplication",
                newName: "IX_JobApplication_JobId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobApplication",
                table: "JobApplication",
                columns: new[] { "AppuserId", "JobId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "92f60b8f-cad8-4e12-9dbf-a4a4d68a8936", "b54d6d8a-d679-4fc3-b300-e1844f6b3928" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_AspNetUsers_AppuserId",
                table: "JobApplication",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_jobs_JobId",
                table: "JobApplication",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplication_JobSeekers_JobSeekerId",
                table: "JobApplication",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
