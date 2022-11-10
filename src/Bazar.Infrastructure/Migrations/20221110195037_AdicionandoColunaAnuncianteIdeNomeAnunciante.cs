using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazar.Infrastructure.Migrations
{
    public partial class AdicionandoColunaAnuncianteIdeNomeAnunciante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnuncianteId",
                table: "Anuncios",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeAnunciante",
                table: "Anuncios",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnuncianteId",
                table: "Anuncios");

            migrationBuilder.DropColumn(
                name: "NomeAnunciante",
                table: "Anuncios");
        }
    }
}
