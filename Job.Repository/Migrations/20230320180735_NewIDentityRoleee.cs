using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class NewIDentityRoleee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DeleteData(
        //        table: "AspNetUserRoles",
        //        keyColumns: new[] { "RoleId", "UserId" },
        //        keyValues: new object[] { "59274726-3a20-4b3a-80e5-7e8b06981d2a", "b74ddd14-6340-4840-95c2-db12554843e5" });

        //    migrationBuilder.DeleteData(
        //        table: "AspNetUsers",
        //        keyColumn: "Id",
        //        keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");

        //    migrationBuilder.InsertData(
        //        table: "AspNetUsers",
        //        columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "DisplayName", "Email", "EmailConfirmed", "Experience", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "Qualification", "SecurityStamp", "TwoFactorEnabled", "UserName" },
        //        values: new object[] { "52C70279-B3A4-4DE6-A612-F1F32875743F", 0, "Cairo", "2eff05db-51de-4a6e-984c-e674c199f749", "Egypt", "1-1-2001", "Admin", "admin@gmail.com", false, null, false, null, null, null, null, "1234567890", false, null, null, "860564f8-2531-4c9b-8b88-1053aaec416a", false, "Admin" });

        //    migrationBuilder.InsertData(
        //        table: "AspNetUserRoles",
        //        columns: new[] { "RoleId", "UserId" },
        //        values: new object[] { "59274726-3a20-4b3a-80e5-7e8b06981d2a", "52C70279-B3A4-4DE6-A612-F1F32875743F" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "59274726-3a20-4b3a-80e5-7e8b06981d2a", "52C70279-B3A4-4DE6-A612-F1F32875743F" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "52C70279-B3A4-4DE6-A612-F1F32875743F");

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "DisplayName", "Email", "EmailConfirmed", "Experience", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "Qualification", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "Cairo", "a86bb272-defe-42b2-8404-001be0e149d7", "Egypt", "1-1-2001", "Admin", "admin@gmail.com", false, null, false, null, null, null, null, "1234567890", false, null, null, "e939ab3f-ce65-41d0-9fcc-095e90304454", false, "Admin" });

            //migrationBuilder.InsertData(
            //    table: "AspNetUserRoles",
            //    columns: new[] { "RoleId", "UserId" },
            //    values: new object[] { "59274726-3a20-4b3a-80e5-7e8b06981d2a", "b74ddd14-6340-4840-95c2-db12554843e5" });
        }
    }
}
