using Microsoft.EntityFrameworkCore.Migrations;

namespace Ereceipt.Infrastructure.Data.Migrations
{
    public partial class NullBudgetCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_BudgetCategories_BudgetCategoryId",
                table: "Receipts");

            migrationBuilder.AlterColumn<long>(
                name: "BudgetCategoryId",
                table: "Receipts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_BudgetCategories_BudgetCategoryId",
                table: "Receipts",
                column: "BudgetCategoryId",
                principalTable: "BudgetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_BudgetCategories_BudgetCategoryId",
                table: "Receipts");

            migrationBuilder.AlterColumn<long>(
                name: "BudgetCategoryId",
                table: "Receipts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_BudgetCategories_BudgetCategoryId",
                table: "Receipts",
                column: "BudgetCategoryId",
                principalTable: "BudgetCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
