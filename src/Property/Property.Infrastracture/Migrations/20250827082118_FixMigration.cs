using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Property.Infrastracture.Migrations
{
    /// <inheritdoc />
    public partial class FixMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_LeaseAgreements_LeaseAgreementId",
                schema: "Property",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_LeaseAgreementId",
                schema: "Property",
                table: "Apartments");

            migrationBuilder.AddColumn<Guid>(
                name: "ApartmentId",
                schema: "Property",
                table: "LeaseAgreements",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_LeaseAgreementId",
                schema: "Property",
                table: "Apartments",
                column: "LeaseAgreementId",
                unique: true,
                filter: "[LeaseAgreementId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_LeaseAgreements_LeaseAgreementId",
                schema: "Property",
                table: "Apartments",
                column: "LeaseAgreementId",
                principalSchema: "Property",
                principalTable: "LeaseAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_LeaseAgreements_LeaseAgreementId",
                schema: "Property",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_LeaseAgreementId",
                schema: "Property",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                schema: "Property",
                table: "LeaseAgreements");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_LeaseAgreementId",
                schema: "Property",
                table: "Apartments",
                column: "LeaseAgreementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_LeaseAgreements_LeaseAgreementId",
                schema: "Property",
                table: "Apartments",
                column: "LeaseAgreementId",
                principalSchema: "Property",
                principalTable: "LeaseAgreements",
                principalColumn: "Id");
        }
    }
}
