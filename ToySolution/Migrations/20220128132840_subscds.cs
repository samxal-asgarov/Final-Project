using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToySolution.Migrations
{
    public partial class subscds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Subscribes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AnswerByUserID",
                table: "Subscribes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnswerDate",
                table: "Subscribes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Subscribes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "AnswerByUserID",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "AnswerDate",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Subscribes");
        }
    }
}
