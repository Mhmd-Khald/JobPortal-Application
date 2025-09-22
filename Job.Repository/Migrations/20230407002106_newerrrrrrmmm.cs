using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class newerrrrrrmmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_JobSeekers_JobSeekerId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_JobSeekerId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "JobSeekerId",
                table: "Application");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3fa60956-796e-46f4-b85e-a0be7a66e865", "f19da7b4-08f8-476f-8115-919ba3d35523" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobSeekerId",
                table: "Application",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "40a42942-a033-424a-98b3-1c0834bfe56d", "15f49278-a954-4439-9246-cc84ba1c2ba4" });

            migrationBuilder.CreateIndex(
                name: "IX_Application_JobSeekerId",
                table: "Application",
                column: "JobSeekerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_JobSeekers_JobSeekerId",
                table: "Application",
                column: "JobSeekerId",
                principalTable: "JobSeekers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
