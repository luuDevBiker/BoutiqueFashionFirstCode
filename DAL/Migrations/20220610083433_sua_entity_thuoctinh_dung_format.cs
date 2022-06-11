using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class sua_entity_thuoctinh_dung_format : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_optionValues_options_optionID",
                table: "optionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_users_userID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdertDetails_Order_orderID",
                table: "OrdertDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdertDetails_productVariants_variantID",
                table: "OrdertDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_productOptions_options_optionID",
                table: "productOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_productOptions_products_productID",
                table: "productOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_productVariants_products_productID",
                table: "productVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_users_rolesUsers_rolesID",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_variantValues_optionValues_valuesID",
                table: "variantValues");

            migrationBuilder.DropForeignKey(
                name: "FK_variantValues_productVariants_variantID",
                table: "variantValues");

            migrationBuilder.DropColumn(
                name: "userID",
                table: "CartItem");

            migrationBuilder.RenameColumn(
                name: "isVariantValueEnabled",
                table: "variantValues",
                newName: "IsVariantValueEnabled");

            migrationBuilder.RenameColumn(
                name: "valuesID",
                table: "variantValues",
                newName: "ValuesID");

            migrationBuilder.RenameColumn(
                name: "optionID",
                table: "variantValues",
                newName: "OptionID");

            migrationBuilder.RenameColumn(
                name: "variantID",
                table: "variantValues",
                newName: "VariantID");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "variantValues",
                newName: "ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_variantValues_variantID",
                table: "variantValues",
                newName: "IX_variantValues_VariantID");

            migrationBuilder.RenameIndex(
                name: "IX_variantValues_valuesID",
                table: "variantValues",
                newName: "IX_variantValues_ValuesID");

            migrationBuilder.RenameColumn(
                name: "userName",
                table: "users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "rolesID",
                table: "users",
                newName: "RolesID");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "isUserEnabled",
                table: "users",
                newName: "IsUserEnabled");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "users",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "numberPhone",
                table: "users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "birdDate",
                table: "users",
                newName: "DOB");

            migrationBuilder.RenameIndex(
                name: "IX_users_rolesID",
                table: "users",
                newName: "IX_users_RolesID");

            migrationBuilder.RenameColumn(
                name: "rolesName",
                table: "rolesUsers",
                newName: "RolesName");

            migrationBuilder.RenameColumn(
                name: "isRolesUserEnabled",
                table: "rolesUsers",
                newName: "IsRolesUserEnabled");

            migrationBuilder.RenameColumn(
                name: "rolesID",
                table: "rolesUsers",
                newName: "RolesID");

            migrationBuilder.RenameColumn(
                name: "skuID",
                table: "productVariants",
                newName: "SkuID");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "productVariants",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "productVariants",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "productVariants",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "isProductVariantEnabled",
                table: "productVariants",
                newName: "IsProductVariantEnabled");

            migrationBuilder.RenameColumn(
                name: "importPrice",
                table: "productVariants",
                newName: "ImportPrice");

            migrationBuilder.RenameColumn(
                name: "variantID",
                table: "productVariants",
                newName: "VariantID");

            migrationBuilder.RenameIndex(
                name: "IX_productVariants_productID",
                table: "productVariants",
                newName: "IX_productVariants_ProductID");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "products",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "isProductEnabled",
                table: "products",
                newName: "IsProductEnabled");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "products",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "isProductOptionEnabled",
                table: "productOptions",
                newName: "IsProductOptionEnabled");

            migrationBuilder.RenameColumn(
                name: "productID",
                table: "productOptions",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "optionID",
                table: "productOptions",
                newName: "OptionID");

            migrationBuilder.RenameIndex(
                name: "IX_productOptions_productID",
                table: "productOptions",
                newName: "IX_productOptions_ProductID");

            migrationBuilder.RenameColumn(
                name: "unitPrice",
                table: "OrdertDetails",
                newName: "UnitPrice");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "OrdertDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "isOrderDetailEnabled",
                table: "OrdertDetails",
                newName: "IsOrderDetailEnabled");

            migrationBuilder.RenameColumn(
                name: "variantID",
                table: "OrdertDetails",
                newName: "VariantID");

            migrationBuilder.RenameColumn(
                name: "orderID",
                table: "OrdertDetails",
                newName: "OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrdertDetails_variantID",
                table: "OrdertDetails",
                newName: "IX_OrdertDetails_VariantID");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Order",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "statusDelete",
                table: "Order",
                newName: "StatusDelete");

            migrationBuilder.RenameColumn(
                name: "refunds",
                table: "Order",
                newName: "Refunds");

            migrationBuilder.RenameColumn(
                name: "payments",
                table: "Order",
                newName: "Payments");

            migrationBuilder.RenameColumn(
                name: "payingCustomer",
                table: "Order",
                newName: "PayingCustomer");

            migrationBuilder.RenameColumn(
                name: "orderTime",
                table: "Order",
                newName: "OrderTime");

            migrationBuilder.RenameColumn(
                name: "isOrderEnabled",
                table: "Order",
                newName: "IsOrderEnabled");

            migrationBuilder.RenameColumn(
                name: "amountPlay",
                table: "Order",
                newName: "AmountPlay");

            migrationBuilder.RenameColumn(
                name: "cartID",
                table: "Order",
                newName: "CartID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_userID",
                table: "Order",
                newName: "IX_Order_UserID");

            migrationBuilder.RenameColumn(
                name: "optionID",
                table: "optionValues",
                newName: "OptionID");

            migrationBuilder.RenameColumn(
                name: "isOptionValueEnabled",
                table: "optionValues",
                newName: "IsOptionValueEnabled");

            migrationBuilder.RenameColumn(
                name: "valuesID",
                table: "optionValues",
                newName: "ValuesID");

            migrationBuilder.RenameColumn(
                name: "optionValues",
                table: "optionValues",
                newName: "OptionValue");

            migrationBuilder.RenameIndex(
                name: "IX_optionValues_optionID",
                table: "optionValues",
                newName: "IX_optionValues_OptionID");

            migrationBuilder.RenameColumn(
                name: "optionName",
                table: "options",
                newName: "OptionName");

            migrationBuilder.RenameColumn(
                name: "isOptionEnabled",
                table: "options",
                newName: "IsOptionEnabled");

            migrationBuilder.RenameColumn(
                name: "optionID",
                table: "options",
                newName: "OptionID");

            migrationBuilder.RenameColumn(
                name: "quantity",
                table: "CartItem",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "productName",
                table: "CartItem",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "CartItem",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "productId",
                table: "CartItem",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_productId",
                table: "CartItem",
                newName: "IX_CartItem_ProductId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 10, 15, 34, 32, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 10, 0, 6, 2, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_optionValues_options_OptionID",
                table: "optionValues",
                column: "OptionID",
                principalTable: "options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_users_UserID",
                table: "Order",
                column: "UserID",
                principalTable: "users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdertDetails_Order_OrderID",
                table: "OrdertDetails",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdertDetails_productVariants_VariantID",
                table: "OrdertDetails",
                column: "VariantID",
                principalTable: "productVariants",
                principalColumn: "VariantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productOptions_options_OptionID",
                table: "productOptions",
                column: "OptionID",
                principalTable: "options",
                principalColumn: "OptionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productOptions_products_ProductID",
                table: "productOptions",
                column: "ProductID",
                principalTable: "products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productVariants_products_ProductID",
                table: "productVariants",
                column: "ProductID",
                principalTable: "products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_rolesUsers_RolesID",
                table: "users",
                column: "RolesID",
                principalTable: "rolesUsers",
                principalColumn: "RolesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_variantValues_optionValues_ValuesID",
                table: "variantValues",
                column: "ValuesID",
                principalTable: "optionValues",
                principalColumn: "ValuesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_variantValues_productVariants_VariantID",
                table: "variantValues",
                column: "VariantID",
                principalTable: "productVariants",
                principalColumn: "VariantID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_optionValues_options_OptionID",
                table: "optionValues");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_users_UserID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdertDetails_Order_OrderID",
                table: "OrdertDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdertDetails_productVariants_VariantID",
                table: "OrdertDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_productOptions_options_OptionID",
                table: "productOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_productOptions_products_ProductID",
                table: "productOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_productVariants_products_ProductID",
                table: "productVariants");

            migrationBuilder.DropForeignKey(
                name: "FK_users_rolesUsers_RolesID",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_variantValues_optionValues_ValuesID",
                table: "variantValues");

            migrationBuilder.DropForeignKey(
                name: "FK_variantValues_productVariants_VariantID",
                table: "variantValues");

            migrationBuilder.RenameColumn(
                name: "IsVariantValueEnabled",
                table: "variantValues",
                newName: "isVariantValueEnabled");

            migrationBuilder.RenameColumn(
                name: "ValuesID",
                table: "variantValues",
                newName: "valuesID");

            migrationBuilder.RenameColumn(
                name: "OptionID",
                table: "variantValues",
                newName: "optionID");

            migrationBuilder.RenameColumn(
                name: "VariantID",
                table: "variantValues",
                newName: "variantID");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "variantValues",
                newName: "productID");

            migrationBuilder.RenameIndex(
                name: "IX_variantValues_VariantID",
                table: "variantValues",
                newName: "IX_variantValues_variantID");

            migrationBuilder.RenameIndex(
                name: "IX_variantValues_ValuesID",
                table: "variantValues",
                newName: "IX_variantValues_valuesID");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "users",
                newName: "userName");

            migrationBuilder.RenameColumn(
                name: "RolesID",
                table: "users",
                newName: "rolesID");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "IsUserEnabled",
                table: "users",
                newName: "isUserEnabled");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "users",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "users",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "users",
                newName: "numberPhone");

            migrationBuilder.RenameColumn(
                name: "DOB",
                table: "users",
                newName: "birdDate");

            migrationBuilder.RenameIndex(
                name: "IX_users_RolesID",
                table: "users",
                newName: "IX_users_rolesID");

            migrationBuilder.RenameColumn(
                name: "RolesName",
                table: "rolesUsers",
                newName: "rolesName");

            migrationBuilder.RenameColumn(
                name: "IsRolesUserEnabled",
                table: "rolesUsers",
                newName: "isRolesUserEnabled");

            migrationBuilder.RenameColumn(
                name: "RolesID",
                table: "rolesUsers",
                newName: "rolesID");

            migrationBuilder.RenameColumn(
                name: "SkuID",
                table: "productVariants",
                newName: "skuID");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "productVariants",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "productVariants",
                newName: "productID");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "productVariants",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "IsProductVariantEnabled",
                table: "productVariants",
                newName: "isProductVariantEnabled");

            migrationBuilder.RenameColumn(
                name: "ImportPrice",
                table: "productVariants",
                newName: "importPrice");

            migrationBuilder.RenameColumn(
                name: "VariantID",
                table: "productVariants",
                newName: "variantID");

            migrationBuilder.RenameIndex(
                name: "IX_productVariants_ProductID",
                table: "productVariants",
                newName: "IX_productVariants_productID");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "products",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "IsProductEnabled",
                table: "products",
                newName: "isProductEnabled");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "products",
                newName: "productID");

            migrationBuilder.RenameColumn(
                name: "IsProductOptionEnabled",
                table: "productOptions",
                newName: "isProductOptionEnabled");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "productOptions",
                newName: "productID");

            migrationBuilder.RenameColumn(
                name: "OptionID",
                table: "productOptions",
                newName: "optionID");

            migrationBuilder.RenameIndex(
                name: "IX_productOptions_ProductID",
                table: "productOptions",
                newName: "IX_productOptions_productID");

            migrationBuilder.RenameColumn(
                name: "UnitPrice",
                table: "OrdertDetails",
                newName: "unitPrice");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "OrdertDetails",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "IsOrderDetailEnabled",
                table: "OrdertDetails",
                newName: "isOrderDetailEnabled");

            migrationBuilder.RenameColumn(
                name: "VariantID",
                table: "OrdertDetails",
                newName: "variantID");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "OrdertDetails",
                newName: "orderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrdertDetails_VariantID",
                table: "OrdertDetails",
                newName: "IX_OrdertDetails_variantID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Order",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "StatusDelete",
                table: "Order",
                newName: "statusDelete");

            migrationBuilder.RenameColumn(
                name: "Refunds",
                table: "Order",
                newName: "refunds");

            migrationBuilder.RenameColumn(
                name: "Payments",
                table: "Order",
                newName: "payments");

            migrationBuilder.RenameColumn(
                name: "PayingCustomer",
                table: "Order",
                newName: "payingCustomer");

            migrationBuilder.RenameColumn(
                name: "OrderTime",
                table: "Order",
                newName: "orderTime");

            migrationBuilder.RenameColumn(
                name: "IsOrderEnabled",
                table: "Order",
                newName: "isOrderEnabled");

            migrationBuilder.RenameColumn(
                name: "AmountPlay",
                table: "Order",
                newName: "amountPlay");

            migrationBuilder.RenameColumn(
                name: "CartID",
                table: "Order",
                newName: "cartID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserID",
                table: "Order",
                newName: "IX_Order_userID");

            migrationBuilder.RenameColumn(
                name: "OptionID",
                table: "optionValues",
                newName: "optionID");

            migrationBuilder.RenameColumn(
                name: "IsOptionValueEnabled",
                table: "optionValues",
                newName: "isOptionValueEnabled");

            migrationBuilder.RenameColumn(
                name: "ValuesID",
                table: "optionValues",
                newName: "valuesID");

            migrationBuilder.RenameColumn(
                name: "OptionValue",
                table: "optionValues",
                newName: "optionValues");

            migrationBuilder.RenameIndex(
                name: "IX_optionValues_OptionID",
                table: "optionValues",
                newName: "IX_optionValues_optionID");

            migrationBuilder.RenameColumn(
                name: "OptionName",
                table: "options",
                newName: "optionName");

            migrationBuilder.RenameColumn(
                name: "IsOptionEnabled",
                table: "options",
                newName: "isOptionEnabled");

            migrationBuilder.RenameColumn(
                name: "OptionID",
                table: "options",
                newName: "optionID");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "CartItem",
                newName: "quantity");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "CartItem",
                newName: "productName");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "CartItem",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "CartItem",
                newName: "productId");

            migrationBuilder.RenameIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                newName: "IX_CartItem_productId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "orderTime",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 10, 0, 6, 2, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 6, 10, 15, 34, 32, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "userID",
                table: "CartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_optionValues_options_optionID",
                table: "optionValues",
                column: "optionID",
                principalTable: "options",
                principalColumn: "optionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_users_userID",
                table: "Order",
                column: "userID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdertDetails_Order_orderID",
                table: "OrdertDetails",
                column: "orderID",
                principalTable: "Order",
                principalColumn: "cartID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdertDetails_productVariants_variantID",
                table: "OrdertDetails",
                column: "variantID",
                principalTable: "productVariants",
                principalColumn: "variantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productOptions_options_optionID",
                table: "productOptions",
                column: "optionID",
                principalTable: "options",
                principalColumn: "optionID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productOptions_products_productID",
                table: "productOptions",
                column: "productID",
                principalTable: "products",
                principalColumn: "productID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productVariants_products_productID",
                table: "productVariants",
                column: "productID",
                principalTable: "products",
                principalColumn: "productID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_rolesUsers_rolesID",
                table: "users",
                column: "rolesID",
                principalTable: "rolesUsers",
                principalColumn: "rolesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_variantValues_optionValues_valuesID",
                table: "variantValues",
                column: "valuesID",
                principalTable: "optionValues",
                principalColumn: "valuesID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_variantValues_productVariants_variantID",
                table: "variantValues",
                column: "variantID",
                principalTable: "productVariants",
                principalColumn: "variantID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
