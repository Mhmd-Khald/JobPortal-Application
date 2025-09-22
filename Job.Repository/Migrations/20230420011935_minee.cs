using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class minee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateApplied = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CvUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppuserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    JobsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Application", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Application_AspNetUsers_AppuserId",
                        column: x => x.AppuserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Application_jobs_JobsId",
                        column: x => x.JobsId,
                        principalTable: "jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6a974398-4e0d-45d7-b0bf-ff7f86da02f4", "f7429182-bd3b-477e-8cfb-787928caba6b" });

            migrationBuilder.CreateIndex(
                name: "IX_Application_AppuserId",
                table: "Application",
                column: "AppuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobsId",
                table: "Application",
                column: "JobsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Application");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "54eb957e-ddd9-4c5e-87b4-48c55b7c6010", "3c5009f9-0fbb-42ad-8efe-670b328091da" });
        }
    }
}
