using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UsuarioChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TarefaHistorico_Usuario_UsuarioIdUsuario",
                table: "TarefaHistorico");

            migrationBuilder.DropIndex(
                name: "IX_TarefaHistorico_UsuarioIdUsuario",
                table: "TarefaHistorico");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "TarefaHistorico");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UsuarioIdUsuario",
                table: "TarefaHistorico",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_TarefaHistorico_UsuarioIdUsuario",
                table: "TarefaHistorico",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_TarefaHistorico_Usuario_UsuarioIdUsuario",
                table: "TarefaHistorico",
                column: "UsuarioIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
