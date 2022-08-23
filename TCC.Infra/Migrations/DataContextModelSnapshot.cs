﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCC.Infra.DataProviders;

namespace TCC.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TCC.Domain.Entities.Classificacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("AlteradoPor")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CriadoPor")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CriandoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Emocao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Probabilidade")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Classificacoes");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Colaborador", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("AlteradoPor")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CriadoPor")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CriandoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Funcional")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long?>("OrganizacaoId")
                        .HasColumnType("bigint");

                    b.Property<int>("Setor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrganizacaoId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("TCC.Domain.Entities.Organizacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<DateTime>("AlteradoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("AlteradoPor")
                        .HasColumnType("char(36)");

                    b.Property<string>("Area")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Cnpj")
                        .HasColumnType("int");

                    b.Property<Guid>("CriadoPor")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CriandoEm")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Patrimonio")
                        .HasColumnType("double");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Organizacoes");
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
