using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EccomereceAPI.Migrations
{
    public partial class newupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "productQantityUnit",
                table: "Order_Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "productquantity",
                table: "Order_Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productQantityUnit",
                table: "Order_Product");

            migrationBuilder.DropColumn(
                name: "productquantity",
                table: "Order_Product");
        }
    }
}
