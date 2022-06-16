using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class update_skuId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 16, 3, 14, 28, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 15, 16, 34, 39, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 15, 16, 34, 39, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 16, 3, 14, 28, 0, DateTimeKind.Unspecified));
        }
    }
}
