using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactInventorySystem.Data.Migrations
{
    public partial class BooleanValueAddedToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isAccept",
                table: "Requests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAccept",
                table: "Requests");
        }
    }
}
