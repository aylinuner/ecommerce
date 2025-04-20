using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class _40 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockMaster_Color_ColorId1",
                table: "StockMaster");

            migrationBuilder.DropIndex(
                name: "IX_StockMaster_ColorId1",
                table: "StockMaster");

            migrationBuilder.DropColumn(
                name: "ColorId1",
                table: "StockMaster");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId1",
                table: "StockMaster",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_StockMaster_ColorId1",
                table: "StockMaster",
                column: "ColorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StockMaster_Color_ColorId1",
                table: "StockMaster",
                column: "ColorId1",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
