using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pes_permissao",
                table: "fin_pessoa",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pes_codigo",
                table: "fin_categoria",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_fin_categoria_pes_codigo",
                table: "fin_categoria",
                column: "pes_codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_fin_categoria_fin_pessoa_pes_codigo",
                table: "fin_categoria",
                column: "pes_codigo",
                principalTable: "fin_pessoa",
                principalColumn: "pes_codigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_fin_categoria_fin_pessoa_pes_codigo",
                table: "fin_categoria");

            migrationBuilder.DropIndex(
                name: "IX_fin_categoria_pes_codigo",
                table: "fin_categoria");

            migrationBuilder.DropColumn(
                name: "pes_permissao",
                table: "fin_pessoa");

            migrationBuilder.DropColumn(
                name: "pes_codigo",
                table: "fin_categoria");
        }
    }
}
