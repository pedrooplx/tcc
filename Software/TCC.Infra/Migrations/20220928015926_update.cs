using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Infra.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Emocao",
                table: "Classificacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Emocao",
                table: "Classificacoes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
