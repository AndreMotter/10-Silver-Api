using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_contaBancaria_cba_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropTable(
                name: "fin_contaBancaria");

            migrationBuilder.CreateTable(
                name: "fin_conta_bancaria",
                columns: table => new
                {
                    cba_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cba_descricao = table.Column<int>(type: "integer", nullable: false),
                    cba_numero = table.Column<string>(type: "text", nullable: true),
                    cba_agencia = table.Column<string>(type: "text", nullable: true),
                    cba_compe_banco = table.Column<string>(type: "text", nullable: true),
                    cba_saldo = table.Column<decimal>(type: "numeric", nullable: false),
                    cba_status = table.Column<bool>(type: "boolean", nullable: false),
                    pes_codigo = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fin_conta_bancaria", x => x.cba_codigo);
                    table.ForeignKey(
                        name: "FK_fin_conta_bancaria_fin_pessoa_pes_codigo",
                        column: x => x.pes_codigo,
                        principalTable: "fin_pessoa",
                        principalColumn: "pes_codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fin_conta_bancaria_pes_codigo",
                table: "fin_conta_bancaria",
                column: "pes_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_movimentacao_fin_conta_bancaria_cba_codigo",
                table: "fin_movimentacao",
                column: "cba_codigo",
                principalTable: "fin_conta_bancaria",
                principalColumn: "cba_codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_conta_bancaria_cba_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropTable(
                name: "fin_conta_bancaria");

            migrationBuilder.CreateTable(
                name: "fin_contaBancaria",
                columns: table => new
                {
                    cba_codigo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pes_codigo = table.Column<int>(type: "integer", nullable: true),
                    cba_agencia = table.Column<string>(type: "text", nullable: true),
                    cba_compe_banco = table.Column<string>(type: "text", nullable: true),
                    cba_descricao = table.Column<int>(type: "integer", nullable: false),
                    cba_numero = table.Column<string>(type: "text", nullable: true),
                    cba_saldo = table.Column<decimal>(type: "numeric", nullable: false),
                    cba_status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fin_contaBancaria", x => x.cba_codigo);
                    table.ForeignKey(
                        name: "FK_fin_contaBancaria_fin_pessoa_pes_codigo",
                        column: x => x.pes_codigo,
                        principalTable: "fin_pessoa",
                        principalColumn: "pes_codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fin_contaBancaria_pes_codigo",
                table: "fin_contaBancaria",
                column: "pes_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_movimentacao_fin_contaBancaria_cba_codigo",
                table: "fin_movimentacao",
                column: "cba_codigo",
                principalTable: "fin_contaBancaria",
                principalColumn: "cba_codigo");
        }
    }
}
