using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BraveHeroCooperation.Migrations
{
    /// <inheritdoc />
    public partial class Update11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BalanceHistories",
                columns: table => new
                {
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BalanceHistories");
        }
    }
}
