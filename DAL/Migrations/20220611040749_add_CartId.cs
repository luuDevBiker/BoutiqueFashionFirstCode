﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class add_CartId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 11, 11, 7, 48, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 10, 15, 34, 32, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartId",
                table: "CartItem");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 10, 15, 34, 32, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 11, 11, 7, 48, 0, DateTimeKind.Unspecified));
        }
    }
}
