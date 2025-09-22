using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Job.Repository.Migrations
{
    public partial class IntialCreateee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.InsertData(
        //      table: "AspNetRoles",
        //      columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        //      values: new object[] { Guid.NewGuid().ToString(), "company", "company".ToUpper(), Guid.NewGuid().ToString() }
        //   );
        //    migrationBuilder.UpdateData(
        //        table: "AspNetUsers",
        //        keyColumn: "Id",
        //        keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
        //        columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
        //        values: new object[] { "cee7eab2-528a-4dd8-a21a-9a3f7991e939", "e93e649e-e24a-47f8-8844-ea8af2ae14bf" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.UpdateData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
            //    columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
            //    values: new object[] { "978aadf2-6ca1-47a6-a147-fc8ea3893a64", "fdff6548-6b4c-43d5-8478-be7ca70bc809" });
        }
    }
}
