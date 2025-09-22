using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class userrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RateUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RaterId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    rateeId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RateUser_AspNetUsers_rateeId",
                        column: x => x.rateeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RateUser_AspNetUsers_RaterId",
                        column: x => x.RaterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b61305a0-f0fd-45b1-aa3d-c00ccbc81274", "35cee6ae-2799-4267-aebf-eb89c78a9895" });

            migrationBuilder.CreateIndex(
                name: "IX_RateUser_rateeId",
                table: "RateUser",
                column: "rateeId");

            migrationBuilder.CreateIndex(
                name: "IX_RateUser_RaterId",
                table: "RateUser",
                column: "RaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RateUser");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "113d33b1-6b0f-4100-a234-1bcc2d580063", "426a4e91-1eee-4dbc-aa58-d989011bc3c1" });
        }
    }
}
