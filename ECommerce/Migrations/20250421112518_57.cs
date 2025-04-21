using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class _57 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_StockMaster_ColorId",
                table: "StockMaster",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMaster_Color_ColorId",
                table: "StockMaster",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMaster_Color_ColorId",
                table: "StockMaster");

            migrationBuilder.DropIndex(
                name: "IX_StockMaster_ColorId",
                table: "StockMaster");
        }
    }
}
