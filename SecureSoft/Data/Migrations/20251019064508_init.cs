using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecureSoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employee_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    title_of_courtesy = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    birth_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    hire_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    postal_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    home_phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    extension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    reports_to = table.Column<int>(type: "int", nullable: true),
                    photo_path = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employee_id);
                    table.ForeignKey(
                        name: "FK_employees_employees_reports_to",
                        column: x => x.reports_to,
                        principalTable: "employees",
                        principalColumn: "employee_id");
                });

            migrationBuilder.CreateTable(
                name: "shippers",
                columns: table => new
                {
                    shipper_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    company_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippers", x => x.shipper_id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    employee_id = table.Column<int>(type: "int", nullable: true),
                    order_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    required_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    shipped_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    ship_via = table.Column<int>(type: "int", nullable: true),
                    freight = table.Column<decimal>(type: "money", nullable: true),
                    ship_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ship_address = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    ship_city = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ship_region = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    ship_postal_code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ship_country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_orders_employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "employees",
                        principalColumn: "employee_id");
                    table.ForeignKey(
                        name: "FK_orders_shippers_ship_via",
                        column: x => x.ship_via,
                        principalTable: "shippers",
                        principalColumn: "shipper_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_employees_reports_to",
                table: "employees",
                column: "reports_to");

            migrationBuilder.CreateIndex(
                name: "last_name",
                table: "employees",
                column: "last_name");

            migrationBuilder.CreateIndex(
                name: "postal_code",
                table: "employees",
                column: "postal_code");

            migrationBuilder.CreateIndex(
                name: "customer_id",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "customers_orders",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "employee_id",
                table: "orders",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "employees_orders",
                table: "orders",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "order_date",
                table: "orders",
                column: "order_date");

            migrationBuilder.CreateIndex(
                name: "ship_postal_code",
                table: "orders",
                column: "ship_postal_code");

            migrationBuilder.CreateIndex(
                name: "shipped_date",
                table: "orders",
                column: "shipped_date");

            migrationBuilder.CreateIndex(
                name: "shippers_orders",
                table: "orders",
                column: "ship_via");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "shippers");
        }
    }
}
