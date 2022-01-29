using Microsoft.EntityFrameworkCore.Migrations;

namespace ToySolution.Migrations
{
    public partial class davadvabvadb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_AspNetRoles_RoleId",
                schema: "Membership",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AspNetRoles_RoleId",
                schema: "Membership",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "StoreRole",
                newSchema: "Membership");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreRole",
                schema: "Membership",
                table: "StoreRole",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_StoreRole_RoleId",
                schema: "Membership",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "Membership",
                principalTable: "StoreRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_StoreRole_RoleId",
                schema: "Membership",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "Membership",
                principalTable: "StoreRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_StoreRole_RoleId",
                schema: "Membership",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_StoreRole_RoleId",
                schema: "Membership",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreRole",
                schema: "Membership",
                table: "StoreRole");

            migrationBuilder.RenameTable(
                name: "StoreRole",
                schema: "Membership",
                newName: "AspNetRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_AspNetRoles_RoleId",
                schema: "Membership",
                table: "RoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AspNetRoles_RoleId",
                schema: "Membership",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
