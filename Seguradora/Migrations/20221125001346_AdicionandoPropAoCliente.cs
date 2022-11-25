using Microsoft.EntityFrameworkCore.Migrations;

namespace Seguradora.Migrations
{
    public partial class AdicionandoPropAoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CpfCnpj",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CpfCnpj",
                table: "Cliente");
        }
    }
}
