using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PointofSalesApi.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd430138-57ca-4f03-b7a8-81a36a30534a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d38241c7-fdc4-4950-9030-bef106edc70b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54536ec8-014c-4f31-bd50-1357131db2aa", "2", "Cashier", "Cashier" },
                    { "c4885cc6-feec-4ef6-8aca-9323b0dfb6b3", "1", "Admin", "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "54536ec8-014c-4f31-bd50-1357131db2aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c4885cc6-feec-4ef6-8aca-9323b0dfb6b3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cd430138-57ca-4f03-b7a8-81a36a30534a", "1", "Admin", "Admin" },
                    { "d38241c7-fdc4-4950-9030-bef106edc70b", "2", "Cashier", "Cashier" }
                });
        }
    }
}
