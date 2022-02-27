using Microsoft.EntityFrameworkCore.Migrations;

namespace Blazor.FacileBudget.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spese",
                columns: table => new
                {
                    SpesaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descrizione = table.Column<string>(type: "TEXT", nullable: true),
                    Importo_Amount = table.Column<float>(type: "REAL", nullable: true),
                    Importo_Currency = table.Column<string>(type: "TEXT", nullable: true),
                    Mese = table.Column<string>(type: "TEXT", nullable: true),
                    Anno = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spese", x => x.SpesaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spese");
        }
    }
}
