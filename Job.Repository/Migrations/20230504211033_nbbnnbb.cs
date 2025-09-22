using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class nbbnnbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppuserId",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FreelanceJobId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ed8bdc5d-33c7-4da1-9df8-4c43f43f8021", "7ef045fc-d337-4dbb-a274-bde5c10292f5" });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AppuserId",
                table: "Offers",
                column: "AppuserId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_FreelanceJobId",
                table: "Offers",
                column: "FreelanceJobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_AppuserId",
                table: "Offers",
                column: "AppuserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_freelanceJobs_FreelanceJobId",
                table: "Offers",
                column: "FreelanceJobId",
                principalTable: "freelanceJobs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_AppuserId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_freelanceJobs_FreelanceJobId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_AppuserId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_FreelanceJobId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "AppuserId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "FreelanceJobId",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de7ff842-a40b-4551-8f85-dfd262fffd19", "ef8b07fc-6cdc-47e4-b74f-22a8c3c746e9" });
        }
    }
}
