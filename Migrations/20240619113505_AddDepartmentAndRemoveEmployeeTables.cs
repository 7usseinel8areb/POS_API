using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointofSalesApi.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentAndRemoveEmployeeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_Employees_EmployeeId",
                table: "PurchaseInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_Employees_EmployeeId",
                table: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_EmployeeId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoices_EmployeeId",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PurchaseInvoices");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "SalesInvoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "PurchaseInvoices",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<int>(
                name: "DepartmerntId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "HireDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_AppUserId",
                table: "SalesInvoices",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_AppUserId",
                table: "PurchaseInvoices",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmerntId",
                table: "AspNetUsers",
                column: "DepartmerntId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmerntId",
                table: "AspNetUsers",
                column: "DepartmerntId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_AspNetUsers_AppUserId",
                table: "PurchaseInvoices",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_AspNetUsers_AppUserId",
                table: "SalesInvoices",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmerntId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_AspNetUsers_AppUserId",
                table: "PurchaseInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesInvoices_AspNetUsers_AppUserId",
                table: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_SalesInvoices_AppUserId",
                table: "SalesInvoices");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoices_AppUserId",
                table: "PurchaseInvoices");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmerntId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "SalesInvoices");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmerntId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HireDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "SalesInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_EmployeeId",
                table: "SalesInvoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_EmployeeId",
                table: "PurchaseInvoices",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_Employees_EmployeeId",
                table: "PurchaseInvoices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesInvoices_Employees_EmployeeId",
                table: "SalesInvoices",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
