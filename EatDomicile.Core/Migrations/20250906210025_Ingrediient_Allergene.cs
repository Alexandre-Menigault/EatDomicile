using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatDomicile.Core.Migrations
{
    /// <inheritdoc />
    public partial class Ingrediient_Allergene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Allergene",
                table: "Ingredients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Allergene",
                table: "Ingredients");
        }
    }
}
