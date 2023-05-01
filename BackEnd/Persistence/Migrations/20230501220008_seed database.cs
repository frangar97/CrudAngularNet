using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seeddatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedDate", "LastName", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 16, 0, 8, 694, DateTimeKind.Local).AddTicks(8908), "Garcia", "Francisco" },
                    { 2, new DateTime(2023, 5, 1, 16, 0, 8, 694, DateTimeKind.Local).AddTicks(8917), "Feldmann", "Laura" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
