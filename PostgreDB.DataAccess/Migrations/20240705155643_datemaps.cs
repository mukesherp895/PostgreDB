using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostgreDB.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class datemaps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateMaps",
                schema: "demo_webapi1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BsFiscalYear = table.Column<string>(type: "varchar(9)", nullable: false),
                    BsYear = table.Column<string>(type: "varchar(4)", nullable: false),
                    BsMonth = table.Column<string>(type: "varchar(2)", nullable: false),
                    BsStartDate = table.Column<string>(type: "varchar(10)", nullable: false),
                    BsEndDate = table.Column<string>(type: "varchar(10)", nullable: false),
                    EngStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EngEndDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateMaps", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DateMaps",
                schema: "demo_webapi1");
        }
    }
}
