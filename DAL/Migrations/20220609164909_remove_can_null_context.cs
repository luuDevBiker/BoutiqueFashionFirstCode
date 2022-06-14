using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class remove_can_null_context : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartDetails");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    productId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VariantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.productId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    cartID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 9, 23, 49, 8, 0, DateTimeKind.Unspecified)),
                    amountPlay = table.Column<float>(type: "real", nullable: false),
                    payingCustomer = table.Column<float>(type: "real", nullable: false),
                    refunds = table.Column<float>(type: "real", nullable: false),
                    payments = table.Column<float>(type: "real", nullable: false),
                    statusDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    isOrderEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.cartID);
                    table.ForeignKey(
                        name: "FK_Order_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdertDetails",
                columns: table => new
                {
                    orderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    variantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    unitPrice = table.Column<float>(type: "real", nullable: false),
                    isOrderDetailEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdertDetails", x => new { x.orderID, x.variantID });
                    table.ForeignKey(
                        name: "FK_OrdertDetails_Order_orderID",
                        column: x => x.orderID,
                        principalTable: "Order",
                        principalColumn: "cartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdertDetails_productVariants_variantID",
                        column: x => x.variantID,
                        principalTable: "productVariants",
                        principalColumn: "variantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_productId",
                table: "CartItem",
                column: "productId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userID",
                table: "Order",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdertDetails_variantID",
                table: "OrdertDetails",
                column: "variantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "OrdertDetails");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    cartID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    amountPlay = table.Column<float>(type: "real", nullable: false),
                    isOrderEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    orderTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 6, 9, 23, 35, 36, 0, DateTimeKind.Unspecified)),
                    payingCustomer = table.Column<float>(type: "real", nullable: false),
                    payments = table.Column<float>(type: "real", nullable: false),
                    refunds = table.Column<float>(type: "real", nullable: false),
                    statusDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.cartID);
                    table.ForeignKey(
                        name: "FK_carts_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cartDetails",
                columns: table => new
                {
                    orderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    variantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isOrderDetailEnabled = table.Column<bool>(type: "bit", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    unitPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartDetails", x => new { x.orderID, x.variantID });
                    table.ForeignKey(
                        name: "FK_cartDetails_carts_orderID",
                        column: x => x.orderID,
                        principalTable: "carts",
                        principalColumn: "cartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cartDetails_productVariants_variantID",
                        column: x => x.variantID,
                        principalTable: "productVariants",
                        principalColumn: "variantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cartDetails_variantID",
                table: "cartDetails",
                column: "variantID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_userID",
                table: "carts",
                column: "userID");
        }
    }
}
