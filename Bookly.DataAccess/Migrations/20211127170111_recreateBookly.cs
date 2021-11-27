using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooklyWeb.Migrations
{
    public partial class recreateBookly : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComapnyId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComapnyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);
        }
    }
}
