using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatDomicile.Core.Migrations
{
    /// <inheritdoc />
    public partial class Drink_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Foods_Id",
                table: "Drinks");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Products_Id",
                table: "Drinks",
                column: "Id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Products_Id",
                table: "Drinks");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Foods_Id",
                table: "Drinks",
                column: "Id",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
