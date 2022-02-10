using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Reference",
                keyValue: "0000",
                columns: new[] { "CodeAuthor", "CodePublisher" },
                values: new object[] { "1", "1" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Reference",
                keyValue: "0001",
                columns: new[] { "CodeAuthor", "CodePublisher" },
                values: new object[] { "2", "2" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Reference",
                keyValue: "0002",
                columns: new[] { "CodeAuthor", "CodePublisher" },
                values: new object[] { "3", "3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Reference",
                keyValue: "0000",
                columns: new[] { "CodeAuthor", "CodePublisher" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Reference",
                keyValue: "0001",
                columns: new[] { "CodeAuthor", "CodePublisher" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Reference",
                keyValue: "0002",
                columns: new[] { "CodeAuthor", "CodePublisher" },
                values: new object[] { null, null });
        }
    }
}
