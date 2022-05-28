using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Sua_IsUserEnable_thanh_bool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "isUserEnabled",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "orderTime",
                table: "carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 26, 21, 53, 16, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 26, 17, 27, 31, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "isUserEnabled",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "orderTime",
                table: "carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 26, 17, 27, 31, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 26, 21, 53, 16, 0, DateTimeKind.Unspecified));
        }
    }
}
