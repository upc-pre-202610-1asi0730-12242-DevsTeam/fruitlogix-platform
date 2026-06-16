using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevelopersTeam.Fruitlogix.Platform.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fruit_type",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "total_volume",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "fruit_name",
                table: "order_items");

            migrationBuilder.AddColumn<string>(
                name: "delivery_address",
                table: "orders",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "order_items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "product_name",
                table: "order_items",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "subtotal",
                table: "order_items",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "delivery_address",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "product_id",
                table: "order_items");

            migrationBuilder.DropColumn(
                name: "product_name",
                table: "order_items");

            migrationBuilder.DropColumn(
                name: "subtotal",
                table: "order_items");

            migrationBuilder.AddColumn<string>(
                name: "fruit_type",
                table: "orders",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<double>(
                name: "total_volume",
                table: "orders",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "fruit_name",
                table: "order_items",
                type: "longtext",
                nullable: false);
        }
    }
}
