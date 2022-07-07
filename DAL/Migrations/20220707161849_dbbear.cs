using System;
using System.Collections.Generic;
using DAL.ValueObject;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class dbbear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantId = table.Column<Guid>(type: "uuid", nullable: false),
                    Images = table.Column<ICollection<ImageValueObject>>(type: "jsonb", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    OptionID = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionName = table.Column<string>(type: "text", nullable: false),
                    IsOptionEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.OptionID);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    IsProductEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "rolesUsers",
                columns: table => new
                {
                    RolesID = table.Column<Guid>(type: "uuid", nullable: false),
                    RolesName = table.Column<string>(type: "text", nullable: false),
                    IsRolesUserEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolesUsers", x => x.RolesID);
                });

            migrationBuilder.CreateTable(
                name: "optionValues",
                columns: table => new
                {
                    ValuesID = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionID = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionValue = table.Column<string>(type: "text", nullable: false),
                    IsOptionValueEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_optionValues", x => x.ValuesID);
                    table.ForeignKey(
                        name: "FK_optionValues_options_OptionID",
                        column: x => x.OptionID,
                        principalTable: "options",
                        principalColumn: "OptionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productOptions",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionID = table.Column<Guid>(type: "uuid", nullable: false),
                    IsProductOptionEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productOptions", x => new { x.OptionID, x.ProductID });
                    table.ForeignKey(
                        name: "FK_productOptions_options_OptionID",
                        column: x => x.OptionID,
                        principalTable: "options",
                        principalColumn: "OptionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productOptions_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productVariants",
                columns: table => new
                {
                    VariantID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    SkuID = table.Column<string>(type: "text", nullable: false),
                    ImportPrice = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsProductVariantEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Images = table.Column<ICollection<ImageValueObject>>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productVariants", x => x.VariantID);
                    table.ForeignKey(
                        name: "FK_productVariants_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    RolesID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    Avatar = table.Column<ImageValueObject>(type: "jsonb", nullable: true),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Profile = table.Column<List<ProfilesUser>>(type: "jsonb", nullable: true),
                    IsUserEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_users_rolesUsers_RolesID",
                        column: x => x.RolesID,
                        principalTable: "rolesUsers",
                        principalColumn: "RolesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "variantValues",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantID = table.Column<Guid>(type: "uuid", nullable: false),
                    OptionID = table.Column<Guid>(type: "uuid", nullable: false),
                    ValuesID = table.Column<Guid>(type: "uuid", nullable: false),
                    IsVariantValueEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_variantValues", x => new { x.ProductID, x.VariantID, x.OptionID, x.ValuesID });
                    table.ForeignKey(
                        name: "FK_variantValues_optionValues_ValuesID",
                        column: x => x.ValuesID,
                        principalTable: "optionValues",
                        principalColumn: "ValuesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_variantValues_productVariants_VariantID",
                        column: x => x.VariantID,
                        principalTable: "productVariants",
                        principalColumn: "VariantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AmountPay = table.Column<long>(type: "bigint", nullable: false),
                    PayingCustomer = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Payments = table.Column<long>(type: "bigint", nullable: false),
                    StatusOrder = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    IsOrderEnabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdertDetails",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uuid", nullable: false),
                    VariantID = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    UnitPrice = table.Column<long>(type: "bigint", nullable: false),
                    IsOrderDetailEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdertDetails", x => new { x.OrderID, x.VariantID });
                    table.ForeignKey(
                        name: "FK_OrdertDetails_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdertDetails_productVariants_VariantID",
                        column: x => x.VariantID,
                        principalTable: "productVariants",
                        principalColumn: "VariantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_optionValues_OptionID",
                table: "optionValues",
                column: "OptionID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_OrdertDetails_VariantID",
                table: "OrdertDetails",
                column: "VariantID");

            migrationBuilder.CreateIndex(
                name: "IX_productOptions_ProductID",
                table: "productOptions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_productVariants_ProductID",
                table: "productVariants",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_users_RolesID",
                table: "users",
                column: "RolesID");

            migrationBuilder.CreateIndex(
                name: "IX_variantValues_ValuesID",
                table: "variantValues",
                column: "ValuesID");

            migrationBuilder.CreateIndex(
                name: "IX_variantValues_VariantID",
                table: "variantValues",
                column: "VariantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "OrdertDetails");

            migrationBuilder.DropTable(
                name: "productOptions");

            migrationBuilder.DropTable(
                name: "variantValues");

            migrationBuilder.DropTable(
                name: "Orders");

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
