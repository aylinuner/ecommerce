using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class _71 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMaster_Color_ColorId",
                table: "StockMaster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockMaster",
                table: "StockMaster");

            migrationBuilder.RenameTable(
                name: "StockMaster",
                newName: "Stock");

            migrationBuilder.RenameIndex(
                name: "IX_StockMaster_ColorId",
                table: "Stock",
                newName: "IX_Stock_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stock",
                table: "Stock",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Color_ColorId",
                table: "Stock",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Color_ColorId",
                table: "Stock");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stock",
                table: "Stock");

            migrationBuilder.RenameTable(
                name: "Stock",
                newName: "StockMaster");

            migrationBuilder.RenameIndex(
                name: "IX_Stock_ColorId",
                table: "StockMaster",
                newName: "IX_StockMaster_ColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockMaster",
                table: "StockMaster",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMaster_Color_ColorId",
                table: "StockMaster",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
