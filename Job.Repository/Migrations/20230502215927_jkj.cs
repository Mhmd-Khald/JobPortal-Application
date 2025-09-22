using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class jkj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contents");

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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisabledType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    requirement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                values: new object[] { "ff343ebd-fcf1-43cb-98d0-0664618bb798", "1a01e768-c7cb-402c-a9af-cfe341fa1c38" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Paragrph = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_AspNetUsers_AppUserId",
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
                values: new object[] { "098ea7f4-fc9e-4341-81d3-aaf1cf7a7c28", "37a8f813-9280-4f38-9248-f4c26464e744" });

            migrationBuilder.CreateIndex(
                name: "IX_Contents_AppUserId",
                table: "Contents",
                column: "AppUserId");
        }
    }
}
