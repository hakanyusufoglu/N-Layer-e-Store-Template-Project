using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NLayereStoreTemplateProject.Data.Migrations
{
    public partial class userbrandproductreletionship_and_baseclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketProduct");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Basket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Basket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Basket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Basket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Basket_ProductId",
                table: "Basket",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Basket_UserId",
                table: "Basket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Products_ProductId",
                table: "Basket",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Basket_Users_UserId",
                table: "Basket",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Products_ProductId",
                table: "Basket");

            migrationBuilder.DropForeignKey(
                name: "FK_Basket_Users_UserId",
                table: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Basket_ProductId",
                table: "Basket");

            migrationBuilder.DropIndex(
                name: "IX_Basket_UserId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Basket");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Basket");

            migrationBuilder.CreateTable(
                name: "BasketProduct",
                columns: table => new
                {
                    BasketsBasketId = table.Column<int>(type: "int", nullable: false),
                    ProductsProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketProduct", x => new { x.BasketsBasketId, x.ProductsProductId });
                    table.ForeignKey(
                        name: "FK_BasketProduct_Basket_BasketsBasketId",
                        column: x => x.BasketsBasketId,
                        principalTable: "Basket",
                        principalColumn: "BasketId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketProduct_ProductsProductId",
                table: "BasketProduct",
                column: "ProductsProductId");
        }
    }
}
