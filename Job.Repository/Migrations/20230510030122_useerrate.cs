using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class useerrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RateUser_AspNetUsers_rateeId",
                table: "RateUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RateUser_AspNetUsers_RaterId",
                table: "RateUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RateUser",
                table: "RateUser");

            migrationBuilder.RenameTable(
                name: "RateUser",
                newName: "rateUsers");

            migrationBuilder.RenameIndex(
                name: "IX_RateUser_RaterId",
                table: "rateUsers",
                newName: "IX_rateUsers_RaterId");

            migrationBuilder.RenameIndex(
                name: "IX_RateUser_rateeId",
                table: "rateUsers",
                newName: "IX_rateUsers_rateeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rateUsers",
                table: "rateUsers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "9c049155-8cd3-4804-a9f5-f8a28f540a54", "994f72c0-9c02-47ea-8620-6923d9ecebdf" });

            migrationBuilder.AddForeignKey(
                name: "FK_rateUsers_AspNetUsers_rateeId",
                table: "rateUsers",
                column: "rateeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rateUsers_AspNetUsers_RaterId",
                table: "rateUsers",
                column: "RaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rateUsers_AspNetUsers_rateeId",
                table: "rateUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_rateUsers_AspNetUsers_RaterId",
                table: "rateUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rateUsers",
                table: "rateUsers");

            migrationBuilder.RenameTable(
                name: "rateUsers",
                newName: "RateUser");

            migrationBuilder.RenameIndex(
                name: "IX_rateUsers_RaterId",
                table: "RateUser",
                newName: "IX_RateUser_RaterId");

            migrationBuilder.RenameIndex(
                name: "IX_rateUsers_rateeId",
                table: "RateUser",
                newName: "IX_RateUser_rateeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RateUser",
                table: "RateUser",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b61305a0-f0fd-45b1-aa3d-c00ccbc81274", "35cee6ae-2799-4267-aebf-eb89c78a9895" });

            migrationBuilder.AddForeignKey(
                name: "FK_RateUser_AspNetUsers_rateeId",
                table: "RateUser",
                column: "rateeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RateUser_AspNetUsers_RaterId",
                table: "RateUser",
                column: "RaterId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
