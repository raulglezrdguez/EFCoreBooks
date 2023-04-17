using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreBooks.Migrations
{
    /// <inheritdoc />
    public partial class DataSeedingGeneral : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autors",
                columns: new[] { "Id", "BirthDate", "Fortune", "Name" },
                values: new object[] { 2, new DateTime(1967, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123m, "Another author" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "OnSale", "PremiereDate", "Price", "Title" },
                values: new object[] { 5, true, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 123.45, "Book five" });

            migrationBuilder.InsertData(
                table: "BookKind",
                columns: new[] { "BooksId", "KindsId" },
                values: new object[] { 5, 2 });

            migrationBuilder.InsertData(
                table: "BooksAuthors",
                columns: new[] { "AuthorId", "BookId", "Character", "Order" },
                values: new object[] { 2, 5, "Character one", 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "Content", "ThumbUp" },
                values: new object[] { 3, 5, "Comment three", true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookKind",
                keyColumns: new[] { "BooksId", "KindsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "BooksAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
