using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreBooks.Migrations
{
    /// <inheritdoc />
    public partial class DataKind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kinds",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Animation" },
                    { 6, "Fantastic" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kinds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kinds",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
