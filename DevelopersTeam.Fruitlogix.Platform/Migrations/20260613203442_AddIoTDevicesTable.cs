using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevelopersTeam.Fruitlogix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddIoTDevicesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "io_t_devices",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    device_code = table.Column<string>(type: "longtext", nullable: false),
                    device_type = table.Column<string>(type: "longtext", nullable: false),
                    location = table.Column<string>(type: "longtext", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    last_reading_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_io_t_devices", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "io_t_devices");
        }
    }
}
