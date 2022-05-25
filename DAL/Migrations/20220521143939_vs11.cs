using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class vs11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    optionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    optionName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isOptionEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.optionID);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    isProductEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "rolesUsers",
                columns: table => new
                {
                    rolesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rolesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isRolesUserEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolesUsers", x => x.rolesID);
                });

            migrationBuilder.CreateTable(
                name: "optionValues",
                columns: table => new
                {
                    valuesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    optionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    optionValues = table.Column<int>(type: "int", nullable: false),
                    isOptionValueEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_optionValues", x => x.valuesID);
                    table.ForeignKey(
                        name: "FK_optionValues_options_optionID",
                        column: x => x.optionID,
                        principalTable: "options",
                        principalColumn: "optionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productOptions",
                columns: table => new
                {
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    optionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isProductOptionEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productOptions", x => new { x.optionID, x.productID });
                    table.ForeignKey(
                        name: "FK_productOptions_options_optionID",
                        column: x => x.optionID,
                        principalTable: "options",
                        principalColumn: "optionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productOptions_products_productID",
                        column: x => x.productID,
                        principalTable: "products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productVariants",
                columns: table => new
                {
                    variantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    skuID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    importPrice = table.Column<float>(type: "real", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    qunatity = table.Column<int>(type: "int", nullable: false),
                    isProductVariantEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productVariants", x => x.variantID);
                    table.ForeignKey(
                        name: "FK_productVariants_products_productID",
                        column: x => x.productID,
                        principalTable: "products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    rolesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sex = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    birdDate = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<int>(type: "int", nullable: false),
                    numberPhone = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<int>(type: "int", nullable: false),
                    isUserEnabled = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_users_rolesUsers_rolesID",
                        column: x => x.rolesID,
                        principalTable: "rolesUsers",
                        principalColumn: "rolesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "variantValues",
                columns: table => new
                {
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    variantID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    optionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    valuesID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    isVariantValueEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variantValues", x => new { x.productID, x.variantID, x.optionID, x.valuesID });
                    table.ForeignKey(
                        name: "FK_variantValues_optionValues_valuesID",
                        column: x => x.valuesID,
                        principalTable: "optionValues",
                        principalColumn: "valuesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_variantValues_productVariants_variantID",
                        column: x => x.variantID,
                        principalTable: "productVariants",
                        principalColumn: "variantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    cartID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 5, 21, 21, 39, 38, 0, DateTimeKind.Unspecified)),
                    amountPlay = table.Column<float>(type: "real", nullable: false),
                    payingCustomer = table.Column<float>(type: "real", nullable: false),
                    refunds = table.Column<float>(type: "real", nullable: false),
                    payments = table.Column<float>(type: "real", nullable: false),
                    statusDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    isOrderEnabled = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
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
                    quantity = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    unitPrice = table.Column<float>(type: "real", nullable: false),
                    isOrderDetailEnabled = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_cartDetails_unitPrice",
                table: "cartDetails",
                column: "unitPrice",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cartDetails_variantID",
                table: "cartDetails",
                column: "variantID");

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
                name: "IX_options_optionName",
                table: "options",
                column: "optionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_optionValues_optionID",
                table: "optionValues",
                column: "optionID");

            migrationBuilder.CreateIndex(
                name: "IX_optionValues_optionValues",
                table: "optionValues",
                column: "optionValues",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productOptions_productID",
                table: "productOptions",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_products_productName",
                table: "products",
                column: "productName",
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
                name: "IX_productVariants_productID",
                table: "productVariants",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_qunatity",
                table: "productVariants",
                column: "qunatity",
                unique: true);

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
                name: "IX_variantValues_valuesID",
                table: "variantValues",
                column: "valuesID");

            migrationBuilder.CreateIndex(
                name: "IX_variantValues_variantID",
                table: "variantValues",
                column: "variantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cartDetails");

            migrationBuilder.DropTable(
                name: "productOptions");

            migrationBuilder.DropTable(
                name: "variantValues");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "optionValues");

            migrationBuilder.DropTable(
                name: "productVariants");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "rolesUsers");
        }
    }
}
