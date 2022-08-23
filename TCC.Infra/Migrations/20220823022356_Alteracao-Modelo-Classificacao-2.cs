using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Infra.Migrations
{
    public partial class AlteracaoModeloClassificacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classificacoes_Colaboradores_ColaboradorId",
                table: "Classificacoes");

            migrationBuilder.DropColumn(
                name: "ClassificacaoId",
                table: "Classificacoes");

            migrationBuilder.AlterColumn<long>(
                name: "ColaboradorId",
                table: "Classificacoes",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Classificacoes_Colaboradores_ColaboradorId",
                table: "Classificacoes",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classificacoes_Colaboradores_ColaboradorId",
                table: "Classificacoes");

            migrationBuilder.AlterColumn<long>(
                name: "ColaboradorId",
                table: "Classificacoes",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "ClassificacaoId",
                table: "Classificacoes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Classificacoes_Colaboradores_ColaboradorId",
                table: "Classificacoes",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
