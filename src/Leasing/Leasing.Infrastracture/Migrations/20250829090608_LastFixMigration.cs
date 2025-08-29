using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leasing.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class LastFixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_PaymentReceipts_PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentReceipts_InvoiceId",
                schema: "Leasing",
                table: "PaymentReceipts",
                column: "InvoiceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentReceipts_Invoices_InvoiceId",
                schema: "Leasing",
                table: "PaymentReceipts",
                column: "InvoiceId",
                principalSchema: "Leasing",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentReceipts_Invoices_InvoiceId",
                schema: "Leasing",
                table: "PaymentReceipts");

            migrationBuilder.DropIndex(
                name: "IX_PaymentReceipts_InvoiceId",
                schema: "Leasing",
                table: "PaymentReceipts");

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentReceiptId",
                schema: "Leasing",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: true);

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
    }
}
