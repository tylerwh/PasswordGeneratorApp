using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PasswordGeneratorApp.Migrations
{
    public partial class AddPasswordField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SitePassword",
                table: "Passwords",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordId",
                keyValue: 1L,
                columns: new[] { "ExpireDate", "SitePassword" },
                values: new object[] { new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "t3stPassword!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SitePassword",
                table: "Passwords");

            migrationBuilder.UpdateData(
                table: "Passwords",
                keyColumn: "PasswordId",
                keyValue: 1L,
                column: "ExpireDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
