using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class nbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_DisabledJobs_DisabledId",
                table: "Application");

            migrationBuilder.DropTable(
                name: "DisabledJobs");

            migrationBuilder.DropIndex(
                name: "IX_Application_DisabledId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "DisabledId",
                table: "Application");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ec519c27-55f3-4c61-842b-68f888c6ec36", "9d48bd94-dfc8-4b1d-bf05-4c3808da358a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisabledId",
                table: "Application",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DisabledJobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisabledType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requirement = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisabledJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisabledJobs_AspNetUsers_AppUserId",
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
                values: new object[] { "3466f3a6-28d6-4c89-8df4-a1fa0f870381", "57fb6ba4-06c2-4449-8fe3-30156636c772" });

            migrationBuilder.CreateIndex(
                name: "IX_Application_DisabledId",
                table: "Application",
                column: "DisabledId");

            migrationBuilder.CreateIndex(
                name: "IX_DisabledJobs_AppUserId",
                table: "DisabledJobs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_DisabledJobs_DisabledId",
                table: "Application",
                column: "DisabledId",
                principalTable: "DisabledJobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
