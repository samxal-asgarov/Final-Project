using Microsoft.EntityFrameworkCore.Migrations;

namespace ToySolution.Migrations
{
    public partial class productshow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HomePageShow",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomePageShow",
                table: "Products");
        }
    }
}
