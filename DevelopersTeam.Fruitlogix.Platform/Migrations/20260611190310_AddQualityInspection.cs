using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevelopersTeam.Fruitlogix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddQualityInspection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "quality_inspections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    batch_id = table.Column<int>(type: "int", nullable: false),
                    notes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "longtext", nullable: true),
                    updated_by = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_quality_inspections", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "preparation_checklists",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    quality_inspection_id = table.Column<int>(type: "int", nullable: false),
                    dry_cleaning_done = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    caliber_sorting_confirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    packaging_material_inspected = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    final_box_sealing = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "longtext", nullable: true),
                    updated_by = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_preparation_checklists", x => x.id);
                    table.ForeignKey(
                        name: "fk_quality_inspections_preparation",
                        column: x => x.quality_inspection_id,
                        principalTable: "quality_inspections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "technical_parameters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    quality_inspection_id = table.Column<int>(type: "int", nullable: false),
                    temperature_celsius = table.Column<double>(type: "double", nullable: false),
                    humidity_percent = table.Column<double>(type: "double", nullable: false),
                    ph = table.Column<double>(type: "double", nullable: false),
                    brix_degrees = table.Column<double>(type: "double", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "longtext", nullable: true),
                    updated_by = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_technical_parameters", x => x.id);
                    table.ForeignKey(
                        name: "fk_quality_inspections_technical",
                        column: x => x.quality_inspection_id,
                        principalTable: "quality_inspections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "visual_inspections",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    quality_inspection_id = table.Column<int>(type: "int", nullable: false),
                    appearance_rating = table.Column<int>(type: "int", nullable: false),
                    has_stains = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    has_bruises = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    has_deformations = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    has_rot = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    waste_percentage = table.Column<double>(type: "double", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    created_by = table.Column<string>(type: "longtext", nullable: true),
                    updated_by = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_visual_inspections", x => x.id);
                    table.ForeignKey(
                        name: "fk_quality_inspections_visual",
                        column: x => x.quality_inspection_id,
                        principalTable: "quality_inspections",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "i_x_preparation_checklists_quality_inspection_id",
                table: "preparation_checklists",
                column: "quality_inspection_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_technical_parameters_quality_inspection_id",
                table: "technical_parameters",
                column: "quality_inspection_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_x_visual_inspections_quality_inspection_id",
                table: "visual_inspections",
                column: "quality_inspection_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "preparation_checklists");

            migrationBuilder.DropTable(
                name: "technical_parameters");

            migrationBuilder.DropTable(
                name: "visual_inspections");

            migrationBuilder.DropTable(
                name: "quality_inspections");
        }
    }
}
