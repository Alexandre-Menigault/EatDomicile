using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatDomicile.Core.Migrations
{
    /// <inheritdoc />
    public partial class Burger_Product_Price : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Burgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Burgers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Burgers_Foods_Id",
                        column: x => x.Id,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Burgers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");
        }
    }
}
