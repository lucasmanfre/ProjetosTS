﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ProjetoTs.Migrations
{
    [DbContext(typeof(BancoDeDados))]
    [Migration("20240410154041_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AvaliacaoFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<float>("Altura")
                        .HasColumnType("float");

                    b.Property<float>("CircunferenciaCintura")
                        .HasColumnType("float");

                    b.Property<string>("Data")
                        .HasColumnType("longtext");

                    b.Property<int>("FrequenciaCardiaca")
                        .HasColumnType("int");

                    b.Property<float>("MassaMuscular")
                        .HasColumnType("float");

                    b.Property<float>("PercentualGordura")
                        .HasColumnType("float");

                    b.Property<float>("Peso")
                        .HasColumnType("float");

                    b.Property<float>("PressaoArterial")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Avaliacaos");
                });

            modelBuilder.Entity("Dieta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Calorias")
                        .HasColumnType("int");

                    b.Property<int>("Carboidratos")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<int>("Gorduras")
                        .HasColumnType("int");

                    b.Property<string>("HistoricoDietas")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("Proteinas")
                        .HasColumnType("int");

                    b.Property<string>("RestricoesAlimentares")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Dietas");
                });

            modelBuilder.Entity("Nutricionista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Crm")
                        .HasColumnType("longtext");

                    b.Property<string>("Dietas")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Especialidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Pacientes")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Nutris");
                });

            modelBuilder.Entity("Personal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alunos")
                        .HasColumnType("longtext");

                    b.Property<string>("Cref")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Especialidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Treinos")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Personais");
                });

            modelBuilder.Entity("PlanoAlimentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Lanches")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("Objetivo")
                        .HasColumnType("longtext");

                    b.Property<string>("Receitas")
                        .HasColumnType("longtext");

                    b.Property<string>("Refeicoes")
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Planos");
                });

            modelBuilder.Entity("Treino", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("longtext");

                    b.Property<string>("Exercicios")
                        .HasColumnType("longtext");

                    b.Property<string>("HistoricoTreinos")
                        .HasColumnType("longtext");

                    b.Property<string>("Intensidade")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<int>("Repeticoes")
                        .HasColumnType("int");

                    b.Property<int>("Series")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Treinos");
                });

            modelBuilder.Entity("Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("HistoricoMedico")
                        .HasColumnType("longtext");

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("NivelAtividadeFisica")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .HasColumnType("longtext");

                    b.Property<string>("ObjetivoSaude")
                        .HasColumnType("longtext");

                    b.Property<float>("Peso")
                        .HasColumnType("float");

                    b.Property<string>("PlanoAlimentar")
                        .HasColumnType("longtext");

                    b.Property<string>("PlanoTreino")
                        .HasColumnType("longtext");

                    b.Property<string>("Sexo")
                        .HasColumnType("varchar(1)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
