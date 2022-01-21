using Microsoft.EntityFrameworkCore.Migrations;

namespace ToySolution.Migrations
{
    public partial class Sort : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SortId",
                table: "Products",
                column: "SortId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sort_SortId",
                table: "Products",
                column: "SortId",
                principalTable: "Sort",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sort_SortId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SortId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SortId",
                table: "Products");
        }
    }
}
