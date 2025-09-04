using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatDomicile.Core.Migrations
{
    /// <inheritdoc />
    public partial class ingredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kcal = table.Column<int>(type: "int", nullable: false),
                    BurgerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Burgers_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burgers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_BurgerId",
                table: "Ingredients",
                column: "BurgerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}
