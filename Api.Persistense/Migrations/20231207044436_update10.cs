using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class update10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mov_observacao",
                table: "fin_movimentacao",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mov_observacao",
                table: "fin_movimentacao");
        }
    }
}
