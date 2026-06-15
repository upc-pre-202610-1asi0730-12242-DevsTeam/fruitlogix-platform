using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DevelopersTeam.Fruitlogix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    commercial_client_id = table.Column<int>(type: "int", nullable: false),
                    producer_id = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    delivery_due_date = table.Column<DateOnly>(type: "date", nullable: false),
                    fruit_type = table.Column<string>(type: "longtext", nullable: false),
                    total_volume = table.Column<double>(type: "double", nullable: false),
                    total_amount = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    notes = table.Column<string>(type: "longtext", nullable: true),
                    cancellation_reason = table.Column<string>(type: "longtext", nullable: true),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_orders", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "order_items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    fruit_name = table.Column<string>(type: "longtext", nullable: false),
                    quantity_kg = table.Column<double>(type: "double", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    order_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("p_k_order_items", x => x.id);
                    table.ForeignKey(
                        name: "f_k_order_items_orders_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "i_x_order_items_order_id",
                table: "order_items",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_items");

            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
