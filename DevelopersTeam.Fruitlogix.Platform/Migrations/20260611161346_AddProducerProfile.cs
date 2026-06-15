using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevelopersTeam.Fruitlogix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddProducerProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "producers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    producer_type = table.Column<string>(type: "longtext", nullable: false),
                    full_name = table.Column<string>(type: "longtext", nullable: false),
                    tax_id = table.Column<string>(type: "longtext", nullable: false),
                    legal_name = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: false),
                    phone = table.Column<string>(type: "longtext", nullable: false),
                    country = table.Column<string>(type: "longtext", nullable: false),
                    region = table.Column<string>(type: "longtext", nullable: false),
                    city = table.Column<string>(type: "longtext", nullable: false),
                    address = table.Column<string>(type: "longtext", nullable: false),
                    crop = table.Column<string>(type: "longtext", nullable: false),
                    cultivated_hectares = table.Column<double>(type: "double", nullable: false),
                    monthly_production = table.Column<string>(type: "longtext", nullable: false),
                    operations_start_date = table.Column<DateOnly>(type: "date", nullable: true),
                    rating = table.Column<double>(type: "double", nullable: false),
                    certifications = table.Column<string>(type: "longtext", nullable: false),
                    photo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_producers", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "producers");
        }
    }
}
