using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Repository.Migrations
{
    public partial class SeeduserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.InsertData(
        //         table: "AspNetUsers",
        //         columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "Country", "DateOfBirth", "DisplayName", "Email", "EmailConfirmed", "Experience", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "Qualification", "SecurityStamp", "TwoFactorEnabled", "UserName", "firstName", "lastName" },
        //         values: new object[] { "b74ddd14-6340-4840-95c2-db12554843e5", 0, "Cairo", "8a7b953d-dc4e-4586-80af-b9de609f30d6", "Egypt", "1-1-2001", null, "admin@gmail.com", false, null, false, null, null, null, null, "1234567890", false, null, null, "75c211be-3ea0-4206-9d68-f844677ab836", false, "Admin", "Mohamed", "Khaled" });

        //    migrationBuilder.InsertData(
        //        table: "AspNetUserRoles",
        //        columns: new[] { "RoleId", "UserId" },
        //        values: new object[] { "59274726-3a20-4b3a-80e5-7e8b06981d2a", "b74ddd14-6340-4840-95c2-db12554843e5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            //migrationBuilder.DeleteData(
            //    table: "AspNetUserRoles",
            //    keyColumns: new[] { "RoleId", "UserId" },
            //    keyValues: new object[] { "59274726-3a20-4b3a-80e5-7e8b06981d2a", "b74ddd14-6340-4840-95c2-db12554843e5" });

            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "b74ddd14-6340-4840-95c2-db12554843e5");
        }
    }
    }

