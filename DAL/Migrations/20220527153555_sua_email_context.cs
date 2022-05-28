using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class sua_email_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_rolesID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_userName",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_productVariants_importPrice",
                table: "productVariants");

            migrationBuilder.DropIndex(
                name: "IX_productVariants_price",
                table: "productVariants");

            migrationBuilder.DropIndex(
                name: "IX_productVariants_qunatity",
                table: "productVariants");

            migrationBuilder.DropIndex(
                name: "IX_products_productName",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_optionValues_optionValues",
                table: "optionValues");

            migrationBuilder.DropIndex(
                name: "IX_options_optionName",
                table: "options");

            migrationBuilder.DropIndex(
                name: "IX_carts_payingCustomer",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_payments",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_userID",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_cartDetails_unitPrice",
                table: "cartDetails");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "optionName",
                table: "options",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "orderTime",
                table: "carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 27, 22, 35, 54, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 26, 21, 53, 16, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_users_rolesID",
                table: "users",
                column: "rolesID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_userID",
                table: "carts",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_rolesID",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_carts_userID",
                table: "carts");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "email",
                table: "users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "productName",
                table: "products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "optionName",
                table: "options",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "orderTime",
                table: "carts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 26, 21, 53, 16, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 5, 27, 22, 35, 54, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_users_rolesID",
                table: "users",
                column: "rolesID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_userName",
                table: "users",
                column: "userName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_importPrice",
                table: "productVariants",
                column: "importPrice",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_price",
                table: "productVariants",
                column: "price",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_qunatity",
                table: "productVariants",
                column: "qunatity",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_productName",
                table: "products",
                column: "productName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_optionValues_optionValues",
                table: "optionValues",
                column: "optionValues",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_options_optionName",
                table: "options",
                column: "optionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_carts_payingCustomer",
                table: "carts",
                column: "payingCustomer",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_carts_payments",
                table: "carts",
                column: "payments",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_carts_userID",
                table: "carts",
                column: "userID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cartDetails_unitPrice",
                table: "cartDetails",
                column: "unitPrice",
                unique: true);
        }
    }
}
