using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_stock_StockID",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stock",
                table: "stock");

            migrationBuilder.RenameTable(
                name: "stock",
                newName: "Stocks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Stocks_StockID",
                table: "comments",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Stocks_StockID",
                table: "comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "stock");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stock",
                table: "stock",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_stock_StockID",
                table: "comments",
                column: "StockID",
                principalTable: "stock",
                principalColumn: "Id");
        }
    }
}
