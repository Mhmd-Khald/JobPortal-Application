using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class nbbnbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_AppuserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_jobs_JobId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_AppuserId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_JobId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "AppuserId",
                table: "Offers");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Offers",
                newName: "OfferValue");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Offers",
                newName: "TimeToRecive");

            migrationBuilder.AddColumn<string>(
                name: "OrderDetails",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "freelanceJobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de7ff842-a40b-4551-8f85-dfd262fffd19", "ef8b07fc-6cdc-47e4-b74f-22a8c3c746e9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDetails",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "freelanceJobs");

            migrationBuilder.RenameColumn(
                name: "TimeToRecive",
                table: "Offers",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "OfferValue",
                table: "Offers",
                newName: "JobId");

            migrationBuilder.AddColumn<string>(
                name: "AppuserId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ed26dde4-2f01-43e8-9a63-4fdfae52ea09", "f1e32c23-3aa5-48c4-83e7-7d773f1d7177" });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AppuserId",
                table: "Offers",
                column: "AppuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_JobId",
                table: "Offers",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_AppuserId",
                table: "Offers",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_jobs_JobId",
                table: "Offers",
                column: "JobId",
                principalTable: "jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
