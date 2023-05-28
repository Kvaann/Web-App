using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projekt.Data.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Danie_Kategoria_KategoriaId",
                table: "Danie");

            migrationBuilder.DropIndex(
                name: "IX_Danie_KategoriaId",
                table: "Danie");

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzyAktywna = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stopka",
                columns: table => new
                {
                    IdStopka = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kontakt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokalizacja = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    NrTelefonu = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    AdresEmail = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    GodzinyOtwarcia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Godziny = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stopka", x => x.IdStopka);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "Stopka");

            migrationBuilder.CreateIndex(
                name: "IX_Danie_KategoriaId",
                table: "Danie",
                column: "KategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Danie_Kategoria_KategoriaId",
                table: "Danie",
                column: "KategoriaId",
                principalTable: "Kategoria",
                principalColumn: "IdKategorii",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
