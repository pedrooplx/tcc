using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizacoes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<Guid>(nullable: false),
                    CriandoEm = table.Column<DateTime>(nullable: false),
                    AlteradoPor = table.Column<Guid>(nullable: false),
                    AlteradoEm = table.Column<DateTime>(nullable: false),
                    RazaoSocial = table.Column<string>(nullable: true),
                    Cnpj = table.Column<int>(nullable: false),
                    Patrimonio = table.Column<double>(nullable: false),
                    Area = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<Guid>(nullable: false),
                    CriandoEm = table.Column<DateTime>(nullable: false),
                    AlteradoPor = table.Column<Guid>(nullable: false),
                    AlteradoEm = table.Column<DateTime>(nullable: false),
                    OrganizacaoId = table.Column<long>(nullable: false),
                    Funcional = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Setor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Organizacoes_OrganizacaoId",
                        column: x => x.OrganizacaoId,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classificacoes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<Guid>(nullable: false),
                    CriandoEm = table.Column<DateTime>(nullable: false),
                    AlteradoPor = table.Column<Guid>(nullable: false),
                    AlteradoEm = table.Column<DateTime>(nullable: false),
                    ColaboradorId = table.Column<long>(nullable: false),
                    Probabilidade = table.Column<double>(nullable: false),
                    Emocao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classificacoes_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_ColaboradorId",
                table: "Classificacoes",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_OrganizacaoId",
                table: "Colaboradores",
                column: "OrganizacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classificacoes");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Organizacoes");
        }
    }
}
