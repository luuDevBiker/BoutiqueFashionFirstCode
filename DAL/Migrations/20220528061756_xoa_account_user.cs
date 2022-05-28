using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class xoa_account_user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "account",
                table: "users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "orderTime",
                table: "carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 28, 13, 17, 55, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 28, 12, 24, 43, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "account",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "orderTime",
                table: "carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 28, 12, 24, 43, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 28, 13, 17, 55, 0, DateTimeKind.Unspecified));
        }
    }
}
