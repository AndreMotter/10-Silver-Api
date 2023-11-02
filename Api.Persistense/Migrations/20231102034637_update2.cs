using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.CreateTable(
                name: "fin_categoria",
                columns: table => new
                {
                    cat_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cat_descricao = table.Column<string>(type: "text", nullable: true),
                    cat_sigla = table.Column<string>(type: "text", nullable: true),
                    cat_tipo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fin_categoria", x => x.cat_codigo);
                });

            migrationBuilder.CreateTable(
                name: "fin_pessoa",
                columns: table => new
                {
                    pes_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pes_nome = table.Column<string>(type: "text", nullable: true),
                    pes_login = table.Column<string>(type: "text", nullable: true),
                    pes_senha = table.Column<string>(type: "text", nullable: true),
                    pes_cpf = table.Column<string>(type: "text", nullable: true),
                    pes_email = table.Column<string>(type: "text", nullable: true),
                    pes_ativo = table.Column<bool>(type: "boolean", nullable: false),
                    pes_data_nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fin_pessoa", x => x.pes_codigo);
                });

            migrationBuilder.CreateTable(
                name: "fin_movimentacao",
                columns: table => new
                {
                    mov_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mov_valor = table.Column<decimal>(type: "numeric", nullable: false),
                    mov_tipo = table.Column<int>(type: "integer", nullable: false),
                    mov_data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    pes_codigo = table.Column<int>(type: "integer", nullable: false),
                    fin_pessoapes_codigo = table.Column<int>(type: "integer", nullable: true),
                    cat_codigo = table.Column<int>(type: "integer", nullable: false),
                    fin_categoriacat_codigo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fin_movimentacao", x => x.mov_codigo);
                    table.ForeignKey(
                        name: "FK_fin_movimentacao_fin_categoria_fin_categoriacat_codigo",
                        column: x => x.fin_categoriacat_codigo,
                        principalTable: "fin_categoria",
                        principalColumn: "cat_codigo");
                    table.ForeignKey(
                        name: "FK_fin_movimentacao_fin_pessoa_fin_pessoapes_codigo",
                        column: x => x.fin_pessoapes_codigo,
                        principalTable: "fin_pessoa",
                        principalColumn: "pes_codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fin_movimentacao_fin_categoriacat_codigo",
                table: "fin_movimentacao",
                column: "fin_categoriacat_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_fin_movimentacao_fin_pessoapes_codigo",
                table: "fin_movimentacao",
                column: "fin_pessoapes_codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fin_movimentacao");

            migrationBuilder.DropTable(
                name: "fin_categoria");

            migrationBuilder.DropTable(
                name: "fin_pessoa");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Permissao = table.Column<int>(type: "integer", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }
    }
}
