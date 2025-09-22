using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class nbbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkPlace",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "freelanceJobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectStatue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeToComplet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publised = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_freelanceJobs", x => x.id);
                    table.ForeignKey(
                        name: "FK_freelanceJobs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3a79aa00-ab45-4549-a84c-052683f1b30d", "50a70140-c20b-405b-9b95-10bc70736585" });

            migrationBuilder.CreateIndex(
                name: "IX_freelanceJobs_AppUserId",
                table: "freelanceJobs",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "freelanceJobs");

            migrationBuilder.DropColumn(
                name: "WorkPlace",
                table: "jobs");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ec519c27-55f3-4c61-842b-68f888c6ec36", "9d48bd94-dfc8-4b1d-bf05-4c3808da358a" });
        }
    }
}
