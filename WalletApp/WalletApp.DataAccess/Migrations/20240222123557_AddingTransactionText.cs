using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingTransactionText : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionText",
                table: "Transactions",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionText",
                table: "Transactions");
        }
    }
}
