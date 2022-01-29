using Microsoft.EntityFrameworkCore.Migrations;

namespace ToySolution.Migrations
{
    public partial class InstaPage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HomePageShow",
                table: "InstagramPhotos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomePageShow",
                table: "InstagramPhotos");
        }
    }
}
