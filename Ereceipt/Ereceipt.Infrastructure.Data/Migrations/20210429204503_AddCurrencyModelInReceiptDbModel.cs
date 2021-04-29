using Microsoft.EntityFrameworkCore.Migrations;

namespace Ereceipt.Infrastructure.Data.Migrations
{
    public partial class AddCurrencyModelInReceiptDbModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Receipts");
        }
    }
}
