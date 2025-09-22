using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class newerrrrr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_AppuserId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_jobs_JobsId",
                table: "Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_AppuserId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_JobsId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "JobsId",
                table: "Application");

            migrationBuilder.AlterColumn<string>(
                name: "AppuserId",
                table: "Application",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                columns: new[] { "AppuserId", "JobId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f26b76c7-c3b3-4a82-a934-a20cde00e4ae", "8305bfae-20ee-47bb-af2d-a370b7229406" });

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobId",
                table: "Application",
                column: "JobId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_AppuserId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_jobs_JobId",
                table: "Application");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_JobId",
                table: "Application");

            migrationBuilder.AlterColumn<string>(
                name: "AppuserId",
                table: "Application",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "JobsId",
                table: "Application",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8cbbc1d-41bd-44df-8521-5453ccf41d53", "b21a5e7f-60f4-4829-b3b8-1ea7f9907fd8" });

            migrationBuilder.CreateIndex(
                name: "IX_Application_AppuserId",
                table: "Application",
                column: "AppuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobsId",
                table: "Application",
                column: "JobsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_AppuserId",
                table: "Application",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
