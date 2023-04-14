using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreBooks.Migrations
{
    /// <inheritdoc />
    public partial class RelationManyToManyFilmKind : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookKind",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    KindsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookKind", x => new { x.BooksId, x.KindsId });
                    table.ForeignKey(
                        name: "FK_BookKind_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookKind_Kinds_KindsId",
                        column: x => x.KindsId,
                        principalTable: "Kinds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_BookKind_KindsId",
                table: "BookKind",
                column: "KindsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookKind");
        }
    }
}
