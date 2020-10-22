using Microsoft.EntityFrameworkCore.Migrations;

namespace Tickets.Migrations
{
    public partial class Retirada_Role_De_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                nullable: true);
        }
    }
}
