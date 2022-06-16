using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class add_image_productvariant_and_add_Description_order_and_add_Profile_user_add_images_cartitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Profile",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "productVariants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 17, 0, 29, 33, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 16, 3, 14, 28, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "CartItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profile",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "productVariants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "CartItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 16, 3, 14, 28, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 17, 0, 29, 33, 0, DateTimeKind.Unspecified));
        }
    }
}
