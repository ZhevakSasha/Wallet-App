using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WalletApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingIconToTrasaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "IconData",
                table: "Transactions",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconData",
                table: "Transactions");
        }
    }
}
