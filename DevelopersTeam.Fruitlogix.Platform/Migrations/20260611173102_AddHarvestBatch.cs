using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevelopersTeam.Fruitlogix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddHarvestBatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "harvest_batches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    producer_id = table.Column<int>(type: "int", nullable: false),
                    fruit_type = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    quantity_kg = table.Column<double>(type: "double", nullable: false),
                    harvest_date = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "longtext", nullable: true),
                    updated_by = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_harvest_batches", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "harvest_batches");
        }
    }
}
