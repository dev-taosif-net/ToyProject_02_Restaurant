using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RollBack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "RId",
                table: "Dishes",
                newName: "RestaurantId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_RId",
                table: "Dishes",
                newName: "IX_Dishes_RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId",
                table: "Dishes",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Restaurants_RestaurantId",
                table: "Dishes");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Dishes",
                newName: "RId");

            migrationBuilder.RenameIndex(
                name: "IX_Dishes_RestaurantId",
                table: "Dishes",
                newName: "IX_Dishes_RId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Restaurants_RId",
                table: "Dishes",
                column: "RId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
