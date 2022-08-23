using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Infra.Migrations
{
    public partial class AlteracaoModeloClassificacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ClassificacaoId",
                table: "Classificacoes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ColaboradorId",
                table: "Classificacoes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_ColaboradorId",
                table: "Classificacoes",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Classificacoes_Colaboradores_ColaboradorId",
                table: "Classificacoes",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classificacoes_Colaboradores_ColaboradorId",
                table: "Classificacoes");

            migrationBuilder.DropIndex(
                name: "IX_Classificacoes_ColaboradorId",
                table: "Classificacoes");

            migrationBuilder.DropColumn(
                name: "ClassificacaoId",
                table: "Classificacoes");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Classificacoes");
        }
    }
}
