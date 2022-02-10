using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Reference = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CodeAuthor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CodePublisher = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Reference);
                    table.ForeignKey(
                        name: "FK_Books_Authors_CodeAuthor",
                        column: x => x.CodeAuthor,
                        principalTable: "Authors",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_CodePublisher",
                        column: x => x.CodePublisher,
                        principalTable: "Publishers",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "1", "Robi Shama" },
                    { "2", "Stephen W Hawking" },
                    { "3", "Robert T. Kiyosaki" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Reference", "CodeAuthor", "CodePublisher", "Genre", "Price", "Title" },
                values: new object[,]
                {
                    { "0000", null, null, "Fiction", 141.0, "The Monk Who Sold His Ferrari" },
                    { "0001", null, null, "Engineering & Technology", 149.0, "The Theory Of Everything" },
                    { "0002", null, null, "Personal Finance", 288.0, "Rich Dad Poor Dad" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Code", "Name" },
                values: new object[,]
                {
                    { "1", "Jaiko Publishing House" },
                    { "2", "Jaiko Publishing House" },
                    { "3", "Plata Publishing" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CodeAuthor",
                table: "Books",
                column: "CodeAuthor");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CodePublisher",
                table: "Books",
                column: "CodePublisher");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
