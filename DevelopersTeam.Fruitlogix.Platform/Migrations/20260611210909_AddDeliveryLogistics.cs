using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevelopersTeam.Fruitlogix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliveryLogistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "deliveries",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    driver_name = table.Column<string>(type: "longtext", nullable: false),
                    driver_phone = table.Column<string>(type: "longtext", nullable: false),
                    vehicle_plate = table.Column<string>(type: "longtext", nullable: false),
                    vehicle_type = table.Column<string>(type: "longtext", nullable: false),
                    route_origin = table.Column<string>(type: "longtext", nullable: false),
                    route_destination = table.Column<string>(type: "longtext", nullable: false),
                    route_distance_km = table.Column<double>(type: "double", nullable: false),
                    estimated_time_of_arrival = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    current_status = table.Column<string>(type: "longtext", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_deliveries", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "deliveries");
        }
    }
}
