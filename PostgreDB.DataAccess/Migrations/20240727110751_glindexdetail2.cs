using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostgreDB.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class glindexdetail2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GLIndexPost",
                schema: "demo_webapi1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GLIndexId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLIndexPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GLIndexPost_GLIndexs_GLIndexId",
                        column: x => x.GLIndexId,
                        principalSchema: "demo_webapi1",
                        principalTable: "GLIndexs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GLIndexPost_GLIndexId",
                schema: "demo_webapi1",
                table: "GLIndexPost",
                column: "GLIndexId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GLIndexPost",
                schema: "demo_webapi1");
        }
    }
}
