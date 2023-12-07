using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class update9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_categoria_fin_pessoa_pes_codigo",
                table: "fin_categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_fin_conta_bancaria_fin_pessoa_pes_codigo",
                table: "fin_conta_bancaria");

            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_conta_bancaria_cba_codigo",
                table: "fin_movimentacao");

            migrationBuilder.AlterColumn<int>(
                name: "cba_codigo",
                table: "fin_movimentacao",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pes_codigo",
                table: "fin_conta_bancaria",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "pes_codigo",
                table: "fin_categoria",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_fin_categoria_fin_pessoa_pes_codigo",
                table: "fin_categoria",
                column: "pes_codigo",
                principalTable: "fin_pessoa",
                principalColumn: "pes_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fin_conta_bancaria_fin_pessoa_pes_codigo",
                table: "fin_conta_bancaria",
                column: "pes_codigo",
                principalTable: "fin_pessoa",
                principalColumn: "pes_codigo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_fin_movimentacao_fin_conta_bancaria_cba_codigo",
                table: "fin_movimentacao",
                column: "cba_codigo",
                principalTable: "fin_conta_bancaria",
                principalColumn: "cba_codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_categoria_fin_pessoa_pes_codigo",
                table: "fin_categoria");

            migrationBuilder.DropForeignKey(
                name: "FK_fin_conta_bancaria_fin_pessoa_pes_codigo",
                table: "fin_conta_bancaria");

            migrationBuilder.DropForeignKey(
                name: "FK_fin_movimentacao_fin_conta_bancaria_cba_codigo",
                table: "fin_movimentacao");

            migrationBuilder.AlterColumn<int>(
                name: "cba_codigo",
                table: "fin_movimentacao",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "pes_codigo",
                table: "fin_conta_bancaria",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "pes_codigo",
                table: "fin_categoria",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_categoria_fin_pessoa_pes_codigo",
                table: "fin_categoria",
                column: "pes_codigo",
                principalTable: "fin_pessoa",
                principalColumn: "pes_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_conta_bancaria_fin_pessoa_pes_codigo",
                table: "fin_conta_bancaria",
                column: "pes_codigo",
                principalTable: "fin_pessoa",
                principalColumn: "pes_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_movimentacao_fin_conta_bancaria_cba_codigo",
                table: "fin_movimentacao",
                column: "cba_codigo",
                principalTable: "fin_conta_bancaria",
                principalColumn: "cba_codigo");
        }
    }
}
