using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class offereed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCompany_AspNetUsers_UserId",
                table: "OfferCompany");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "OfferCompany",
                newName: "SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferCompany_UserId",
                table: "OfferCompany",
                newName: "IX_OfferCompany_SenderId");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "OfferCompany",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecipientId",
                table: "OfferCompany",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "098ea7f4-fc9e-4341-81d3-aaf1cf7a7c28", "37a8f813-9280-4f38-9248-f4c26464e744" });

            migrationBuilder.CreateIndex(
                name: "IX_OfferCompany_AppUserId",
                table: "OfferCompany",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfferCompany_RecipientId",
                table: "OfferCompany",
                column: "RecipientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCompany_AspNetUsers_AppUserId",
                table: "OfferCompany",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCompany_AspNetUsers_RecipientId",
                table: "OfferCompany",
                column: "RecipientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCompany_AspNetUsers_SenderId",
                table: "OfferCompany",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfferCompany_AspNetUsers_AppUserId",
                table: "OfferCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferCompany_AspNetUsers_RecipientId",
                table: "OfferCompany");

            migrationBuilder.DropForeignKey(
                name: "FK_OfferCompany_AspNetUsers_SenderId",
                table: "OfferCompany");

            migrationBuilder.DropIndex(
                name: "IX_OfferCompany_AppUserId",
                table: "OfferCompany");

            migrationBuilder.DropIndex(
                name: "IX_OfferCompany_RecipientId",
                table: "OfferCompany");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "OfferCompany");

            migrationBuilder.DropColumn(
                name: "RecipientId",
                table: "OfferCompany");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "OfferCompany",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_OfferCompany_SenderId",
                table: "OfferCompany",
                newName: "IX_OfferCompany_UserId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d4d279da-384c-4370-bc6f-fb1f46c15a7d", "c3ad4765-071e-4c79-bdee-bc9e95f973b2" });

            migrationBuilder.AddForeignKey(
                name: "FK_OfferCompany_AspNetUsers_UserId",
                table: "OfferCompany",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
