using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class xoa_ref_order_and_add_StatusOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDelete",
                table: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 1, 41, 24, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 0, 34, 29, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StatusOrder",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusOrder",
                table: "Order");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 0, 34, 29, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 1, 41, 24, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "StatusDelete",
                table: "Order",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }
    }
}
