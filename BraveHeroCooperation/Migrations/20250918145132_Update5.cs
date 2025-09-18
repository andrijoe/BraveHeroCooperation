using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BraveHeroCooperation.Migrations
{
    /// <inheritdoc />
    public partial class Update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "totalAmount",
                table: "Loans",
                newName: "TotalAmount");

            migrationBuilder.RenameColumn(
                name: "tenorLeft",
                table: "Loans",
                newName: "TenorLeft");

            migrationBuilder.RenameColumn(
                name: "outstanding",
                table: "Loans",
                newName: "Outstanding");

            migrationBuilder.RenameColumn(
                name: "fine",
                table: "Loans",
                newName: "Fine");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Loans",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Loans",
                newName: "CreatedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "Loans",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Loans",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Loans");

            migrationBuilder.RenameColumn(
                name: "TotalAmount",
                table: "Loans",
                newName: "totalAmount");

            migrationBuilder.RenameColumn(
                name: "TenorLeft",
                table: "Loans",
                newName: "tenorLeft");

            migrationBuilder.RenameColumn(
                name: "Outstanding",
                table: "Loans",
                newName: "outstanding");

            migrationBuilder.RenameColumn(
                name: "Fine",
                table: "Loans",
                newName: "fine");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Loans",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "Loans",
                newName: "CreatedAt");
        }
    }
}
