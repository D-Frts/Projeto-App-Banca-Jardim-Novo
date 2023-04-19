using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancaJN.Api.Migrations
{
    public partial class AlteracaoEntidadeProduto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Produtos",
                type: "VARCHAR(50) UNIQUE",
                precision: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50)",
                oldPrecision: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Codigo",
                table: "Produtos",
                type: "VARCHAR(50)",
                precision: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(50) UNIQUE",
                oldPrecision: 50);
        }
    }
}
