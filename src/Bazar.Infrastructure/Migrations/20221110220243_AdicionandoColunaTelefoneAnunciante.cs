using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bazar.Infrastructure.Migrations
{
    public partial class AdicionandoColunaTelefoneAnunciante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelefoneAnunciante",
                table: "Anuncios",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefoneAnunciante",
                table: "Anuncios");
        }
    }
}
