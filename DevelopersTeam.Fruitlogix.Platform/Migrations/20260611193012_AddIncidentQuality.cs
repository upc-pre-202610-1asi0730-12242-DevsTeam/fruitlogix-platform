using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevelopersTeam.Fruitlogix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddIncidentQuality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "incidents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    batch_id = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    evidence_urls = table.Column<string>(type: "longtext", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    resolved_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "longtext", nullable: true),
                    updated_by = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_incidents", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "incidents");
        }
    }
}
