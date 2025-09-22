using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class nr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59274726-3a20-4b3a-80e5-7e8b06981d2a", "52C70279-B3A4-4DE6-A612-F1F32875743F" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "93b7348f-3fc3-4f0b-8db0-535f26fb1e22", "Admin", "ADMIN" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7211", "74c489e6-1aa9-4e54-ad68-b870e8c39483", "company", "COMPANY" },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7212", "a1815055-dc52-491d-a940-246970fd478e", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "CVURl", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "DisplayName", "Email", "EmailConfirmed", "Experience", "JobType", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "Position", "Qualification", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerficationCode" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, null, "Cairo", "9c5da8c5-cae2-4c29-88b5-15c0c1d66825", "Egypt", null, null, "Admin123@gmail.com", true, null, null, true, null, "ADMIN123@GMAIL.COM", "ADMIN123@GMAIL.COM", "AQAAAAEAACcQAAAAEPEdwx+4Gh7707QFG5xirsypn9NynWATXVuEXdPYTwIPwVGG1DKhqHEFeDrCJZ712g==", null, true, null, null, null, "f9c7479e-6224-460a-969d-8e291eab7fb6", false, "Admin123@gmail.com", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7211");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7212");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "CVURl", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "DisplayName", "Email", "EmailConfirmed", "Experience", "JobType", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "Position", "Qualification", "SecurityStamp", "TwoFactorEnabled", "UserName", "VerficationCode" },
                values: new object[] { "52C70279-B3A4-4DE6-A612-F1F32875743F", 0, null, null, "Cairo", "3d49001e-1304-49fe-a4fe-72666773bbf4", "Egypt", "1-1-2001", "Admin", "admin@gmail.com", false, null, null, false, null, null, null, null, "1234567890", false, null, null, null, "132e0f18-2550-4adc-9817-c1086c31e2f9", false, "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59274726-3a20-4b3a-80e5-7e8b06981d2a", "52C70279-B3A4-4DE6-A612-F1F32875743F" });
        }
    }
}
