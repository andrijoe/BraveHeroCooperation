using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BraveHeroCooperation.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    terminologi1 = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    terminologi2 = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    terminologi3 = table.Column<string>(type: "character varying(4000)", maxLength: 4000, nullable: false),
                    exchangeRate = table.Column<decimal>(type: "numeric", nullable: false),
                    transferAcrossFee = table.Column<decimal>(type: "numeric", nullable: false),
                    transferInhouseFee = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configurations");
        }
    }
}
