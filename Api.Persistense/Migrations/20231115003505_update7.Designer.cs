﻿// <auto-generated />
using System;
using Api.Persistense;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Persistense.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231115003505_update7")]
    partial class update7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.Domain.Entities.Fin_Movimentacao", b =>
                {
                    b.Property<int>("mov_codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("mov_codigo"));

                    b.Property<int>("cat_codigo")
                        .HasColumnType("integer");

                    b.Property<int?>("cba_codigo")
                        .HasColumnType("integer");

                    b.Property<DateTime>("mov_data")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("mov_tipo")
                        .HasColumnType("integer");

                    b.Property<decimal>("mov_valor")
                        .HasColumnType("numeric");

                    b.Property<int>("pes_codigo")
                        .HasColumnType("integer");

                    b.HasKey("mov_codigo");

                    b.HasIndex("cat_codigo");

                    b.HasIndex("cba_codigo");

                    b.HasIndex("pes_codigo");

                    b.ToTable("fin_movimentacao");
                });

            modelBuilder.Entity("App.Domain.Entities.Fin_Pessoa", b =>
                {
                    b.Property<int>("pes_codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("pes_codigo"));

                    b.Property<bool>("pes_ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("pes_cpf")
                        .HasColumnType("text");

                    b.Property<DateTime>("pes_data_nascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("pes_email")
                        .HasColumnType("text");

                    b.Property<string>("pes_login")
                        .HasColumnType("text");

                    b.Property<string>("pes_nome")
                        .HasColumnType("text");

                    b.Property<string>("pes_senha")
                        .HasColumnType("text");

                    b.HasKey("pes_codigo");

                    b.ToTable("fin_pessoa");
                });

            modelBuilder.Entity("App.Domain.Entities.Fin_categoria", b =>
                {
                    b.Property<int>("cat_codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cat_codigo"));

                    b.Property<string>("cat_descricao")
                        .HasColumnType("text");

                    b.Property<string>("cat_sigla")
                        .HasColumnType("text");

                    b.Property<int>("cat_tipo")
                        .HasColumnType("integer");

                    b.HasKey("cat_codigo");

                    b.ToTable("fin_categoria");
                });

            modelBuilder.Entity("App.Domain.Entities.Fin_conta_Bancaria", b =>
                {
                    b.Property<int>("cba_codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("cba_codigo"));

                    b.Property<string>("cba_agencia")
                        .HasColumnType("text");

                    b.Property<string>("cba_compe_banco")
                        .HasColumnType("text");

                    b.Property<string>("cba_descricao")
                        .HasColumnType("text");

                    b.Property<string>("cba_numero")
                        .HasColumnType("text");

                    b.Property<decimal>("cba_saldo")
                        .HasColumnType("numeric");

                    b.Property<bool>("cba_status")
                        .HasColumnType("boolean");

                    b.Property<int?>("pes_codigo")
                        .HasColumnType("integer");

                    b.HasKey("cba_codigo");

                    b.HasIndex("pes_codigo");

                    b.ToTable("fin_conta_bancaria");
                });

            modelBuilder.Entity("App.Domain.Entities.Fin_Movimentacao", b =>
                {
                    b.HasOne("App.Domain.Entities.Fin_categoria", "FinCategoria")
                        .WithMany()
                        .HasForeignKey("cat_codigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Domain.Entities.Fin_conta_Bancaria", "Fin_contaBancaria")
                        .WithMany()
                        .HasForeignKey("cba_codigo");

                    b.HasOne("App.Domain.Entities.Fin_Pessoa", "FinPessoa")
                        .WithMany()
                        .HasForeignKey("pes_codigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FinCategoria");

                    b.Navigation("FinPessoa");

                    b.Navigation("Fin_contaBancaria");
                });

            modelBuilder.Entity("App.Domain.Entities.Fin_conta_Bancaria", b =>
                {
                    b.HasOne("App.Domain.Entities.Fin_Pessoa", "FinPessoa")
                        .WithMany()
                        .HasForeignKey("pes_codigo");

                    b.Navigation("FinPessoa");
                });
#pragma warning restore 612, 618
        }
    }
}
