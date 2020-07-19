using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactInventorySystem.Data.Migrations
{
    public partial class correctDataTypeOfProductName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductName",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
