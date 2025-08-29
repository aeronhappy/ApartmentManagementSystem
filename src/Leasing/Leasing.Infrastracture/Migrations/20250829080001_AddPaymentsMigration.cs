using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentReceipts",
                schema: "Leasing",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmountPaid = table.Column<double>(type: "float", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentReceipts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices",
                column: "PaymentReceiptId",
                unique: true,
                filter: "[PaymentReceiptId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_PaymentReceipts_PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices",
                column: "PaymentReceiptId",
                principalSchema: "Leasing",
                principalTable: "PaymentReceipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_PaymentReceipts_PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices");

            migrationBuilder.DropTable(
                name: "PaymentReceipts",
                schema: "Leasing");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices");
        }
    }
}
