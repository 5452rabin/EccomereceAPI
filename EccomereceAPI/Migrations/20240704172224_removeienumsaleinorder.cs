using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EccomereceAPI.Migrations
{
    public partial class removeienumsaleinorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Order_OrderId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Product_ProductId",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sales");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_ProductId",
                table: "Sales",
                newName: "IX_Sales_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_OrderId",
                table: "Sales",
                newName: "IX_Sales_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sales",
                table: "Sales",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Order_OrderId",
                table: "Sales",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Product_ProductId",
                table: "Sales",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Order_OrderId",
                table: "Sales");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Product_ProductId",
                table: "Sales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sales",
                table: "Sales");

            migrationBuilder.RenameTable(
                name: "Sales",
                newName: "Sale");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_ProductId",
                table: "Sale",
                newName: "IX_Sale_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Sales_OrderId",
                table: "Sale",
                newName: "IX_Sale_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "SaleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Order_OrderId",
                table: "Sale",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Product_ProductId",
                table: "Sale",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
