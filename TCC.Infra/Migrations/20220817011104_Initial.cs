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
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<Guid>(nullable: false),
                    CriandoEm = table.Column<DateTime>(nullable: false),
                    AlteradoPor = table.Column<Guid>(nullable: false),
                    AlteradoEm = table.Column<DateTime>(nullable: false),
                    Cpf = table.Column<long>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

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
                    Funcional = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Setor = table.Column<int>(nullable: false),
                    OrganizacaoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Organizacoes_OrganizacaoId",
                        column: x => x.OrganizacaoId,
                        principalTable: "Organizacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atendimentos",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CriadoPor = table.Column<Guid>(nullable: false),
                    CriandoEm = table.Column<DateTime>(nullable: false),
                    AlteradoPor = table.Column<Guid>(nullable: false),
                    AlteradoEm = table.Column<DateTime>(nullable: false),
                    ColaboradorId = table.Column<long>(nullable: true),
                    ClienteId = table.Column<long>(nullable: true),
                    InicioAtendimento = table.Column<DateTime>(nullable: false),
                    FimAtendimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atendimentos_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Probabilidade = table.Column<double>(nullable: false),
                    Emocao = table.Column<string>(nullable: true),
                    AtendimentoId = table.Column<long>(nullable: true),
                    Horario = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classificacoes_Atendimentos_AtendimentoId",
                        column: x => x.AtendimentoId,
                        principalTable: "Atendimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ClienteId",
                table: "Atendimentos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Atendimentos_ColaboradorId",
                table: "Atendimentos",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Classificacoes_AtendimentoId",
                table: "Classificacoes",
                column: "AtendimentoId");

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
                name: "Atendimentos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Organizacoes");
        }
    }
}
