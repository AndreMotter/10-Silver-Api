using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class update3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_categoria_fin_categoriacat_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_pessoa_fin_pessoapes_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_fin_movimentacao_fin_categoriacat_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_fin_movimentacao_fin_pessoapes_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropColumn(
                name: "fin_categoriacat_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropColumn(
                name: "fin_pessoapes_codigo",
                table: "fin_movimentacao");

            migrationBuilder.CreateIndex(
                name: "IX_fin_movimentacao_cat_codigo",
                table: "fin_movimentacao",
                column: "cat_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_fin_movimentacao_pes_codigo",
                table: "fin_movimentacao",
                column: "pes_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_movimentacao_fin_categoria_cat_codigo",
                table: "fin_movimentacao",
                column: "cat_codigo",
                principalTable: "fin_categoria",
                principalColumn: "cat_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fin_movimentacao_fin_pessoa_pes_codigo",
                table: "fin_movimentacao",
                column: "pes_codigo",
                principalTable: "fin_pessoa",
                principalColumn: "pes_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_categoria_cat_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_pessoa_pes_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_fin_movimentacao_cat_codigo",
                table: "fin_movimentacao");

            migrationBuilder.DropIndex(
                name: "IX_fin_movimentacao_pes_codigo",
                table: "fin_movimentacao");

            migrationBuilder.AddColumn<int>(
                name: "fin_categoriacat_codigo",
                table: "fin_movimentacao",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fin_pessoapes_codigo",
                table: "fin_movimentacao",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fin_movimentacao_fin_categoriacat_codigo",
                table: "fin_movimentacao",
                column: "fin_categoriacat_codigo");

            migrationBuilder.CreateIndex(
                name: "IX_fin_movimentacao_fin_pessoapes_codigo",
                table: "fin_movimentacao",
                column: "fin_pessoapes_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_movimentacao_fin_categoria_fin_categoriacat_codigo",
                table: "fin_movimentacao",
                column: "fin_categoriacat_codigo",
                principalTable: "fin_categoria",
                principalColumn: "cat_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_movimentacao_fin_pessoa_fin_pessoapes_codigo",
                table: "fin_movimentacao",
                column: "fin_pessoapes_codigo",
                principalTable: "fin_pessoa",
                principalColumn: "pes_codigo");
        }
    }
}
