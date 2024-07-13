using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgreDB.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "demo_webapi1");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "demo_webapi",
                newName: "AspNetUserTokens",
                newSchema: "demo_webapi1");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "demo_webapi",
                newName: "AspNetUsers",
                newSchema: "demo_webapi1");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "demo_webapi",
                newName: "AspNetUserRoles",
                newSchema: "demo_webapi1");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "demo_webapi",
                newName: "AspNetUserLogins",
                newSchema: "demo_webapi1");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "demo_webapi",
                newName: "AspNetUserClaims",
                newSchema: "demo_webapi1");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "demo_webapi",
                newName: "AspNetRoles",
                newSchema: "demo_webapi1");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "demo_webapi",
                newName: "AspNetRoleClaims",
                newSchema: "demo_webapi1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "demo_webapi");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "demo_webapi1",
                newName: "AspNetUserTokens",
                newSchema: "demo_webapi");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "demo_webapi1",
                newName: "AspNetUsers",
                newSchema: "demo_webapi");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "demo_webapi1",
                newName: "AspNetUserRoles",
                newSchema: "demo_webapi");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "demo_webapi1",
                newName: "AspNetUserLogins",
                newSchema: "demo_webapi");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "demo_webapi1",
                newName: "AspNetUserClaims",
                newSchema: "demo_webapi");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "demo_webapi1",
                newName: "AspNetRoles",
                newSchema: "demo_webapi");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "demo_webapi1",
                newName: "AspNetRoleClaims",
                newSchema: "demo_webapi");
        }
    }
}
