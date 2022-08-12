﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using TCC.Infra.DataProviders;

namespace TCC.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220811011707_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TCC.Domain.Entities.Atendimento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("ColaboradorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CriandoEm")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Classificacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("AtendimentoId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CriandoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Emocao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Probabilidade")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("AtendimentoId");

                    b.ToTable("Classificacoes");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Cpf")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriandoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Colaborador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CriandoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Funcional")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("OrganizacaoId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Setor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizacaoId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Organizacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Cnpj")
                        .HasColumnType("int");

                    b.Property<DateTime>("CriandoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Organizacoes");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Atendimento", b =>
                {
                    b.HasOne("TCC.Domain.Entities.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("TCC.Domain.Entities.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Classificacao", b =>
                {
                    b.HasOne("TCC.Domain.Entities.Atendimento", "Atendimento")
                        .WithMany("Classificacao")
                        .HasForeignKey("AtendimentoId");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Colaborador", b =>
                {
                    b.HasOne("TCC.Domain.Entities.Organizacao", "Organizacao")
                        .WithMany("Colaboradores")
                        .HasForeignKey("OrganizacaoId");
                });
#pragma warning restore 612, 618
        }
    }
}
