using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostgreDB.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class glindexdetail1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefId",
                schema: "demo_webapi1",
                table: "GLIndexDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefId",
                schema: "demo_webapi1",
                table: "GLIndexDetails");
        }
    }
}
