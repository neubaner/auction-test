using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace totvs_test.Migrations
{
    public partial class AddSeedDataToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Enabled", "Name", "Password" },
                values: new object[] { new Guid("97abbeca-c716-4eb0-b1da-d0e7287118b3"), "guilherme.neubaner@gmail.com", true, "Guilherme Neubaner", "$2a$11$IM6.AUVo9GujnYP8uV10F.VaDujBzBkCkO9JIINZ.9uMU7DIOguzK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97abbeca-c716-4eb0-b1da-d0e7287118b3"));
        }
    }
}
