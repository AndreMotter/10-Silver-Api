using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_categoria_fin_pessoa_pes_codigo",
                table: "fin_categoria");

            migrationBuilder.DropIndex(
                name: "IX_fin_categoria_pes_codigo",
                table: "fin_categoria");

            migrationBuilder.DropColumn(
                name: "pes_codigo",
                table: "fin_categoria");

            migrationBuilder.AddColumn<int>(
                name: "cba_codigo",
                table: "fin_movimentacao",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "fin_contaBancaria",
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
                    table.PrimaryKey("PK_fin_contaBancaria", x => x.cba_codigo);
                    table.ForeignKey(
                        name: "FK_fin_contaBancaria_fin_pessoa_pes_codigo",
                        column: x => x.pes_codigo,
                        principalTable: "fin_pessoa",
                        principalColumn: "pes_codigo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_fin_movimentacao_cba_codigo",
                table: "fin_movimentacao",
                column: "cba_codigo");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_contaBancaria_cba_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropTable(
                name: "fin_contaBancaria");

            migrationBuilder.DropIndex(
                name: "IX_fin_movimentacao_cba_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropColumn(
                name: "cba_codigo",
                table: "fin_movimentacao");

            migrationBuilder.AddColumn<int>(
                name: "pes_codigo",
                table: "fin_categoria",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_fin_categoria_pes_codigo",
                table: "fin_categoria",
                column: "pes_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_categoria_fin_pessoa_pes_codigo",
                table: "fin_categoria",
                column: "pes_codigo",
                principalTable: "fin_pessoa",
                principalColumn: "pes_codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
