using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RCA.Core.Migrations
{
    /// <inheritdoc />
    public partial class FirstInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Türkiye" },
                    { 2, true, "İngiltere" },
                    { 3, true, "İtalya" },
                    { 4, true, "Fransa" },
                    { 5, true, "Almanya" },
                    { 6, true, "Hollanda" },
                    { 7, true, "Belçika" },
                    { 8, true, "Finlandiya" },
                    { 9, true, "Yunanistan" },
                    { 10, true, "İsveç" },
                    { 11, true, "İsviçre" },
                    { 12, true, "Rusya" },
                    { 13, true, "Bulgaristan" },
                    { 14, true, "Norveç" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Name",
                table: "Countries",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
