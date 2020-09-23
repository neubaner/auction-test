using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace totvs_test.Migrations
{
    public partial class AddTotvsUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97abbeca-c716-4eb0-b1da-d0e7287118b3"),
                column: "Password",
                value: "$2a$11$3d6RFjwQoG6Fww0CGZFRDOE1g2O09oP3RQKdT1cIzI2iW/2zY5/cG");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Enabled", "Name", "Password" },
                values: new object[] { new Guid("efe1f695-4048-4ef8-939e-017fe39cba01"), "admin@totvs.com.br", true, "TOTVS Admin", "$2a$11$.BURPJNoyvJVnR4McOrCgudndd2nxuVW2dFUMg.nLWQZXWoarQ4T." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("efe1f695-4048-4ef8-939e-017fe39cba01"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("97abbeca-c716-4eb0-b1da-d0e7287118b3"),
                column: "Password",
                value: "$2a$11$IM6.AUVo9GujnYP8uV10F.VaDujBzBkCkO9JIINZ.9uMU7DIOguzK");
        }
    }
}
