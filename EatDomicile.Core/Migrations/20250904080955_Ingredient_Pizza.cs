using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatDomicile.Core.Migrations
{
    /// <inheritdoc />
    public partial class Ingredient_Pizza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_PizzaId",
                table: "Ingredients",
                column: "PizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Pizzas_PizzaId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_PizzaId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "PizzaId",
                table: "Ingredients");
        }
    }
}
