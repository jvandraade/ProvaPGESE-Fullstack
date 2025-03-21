using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioPGESEAPI.API.Migrations
{
    /// <inheritdoc />
    public partial class updateprocesso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessosJuridicos_Usuarios_ProcuradorId",
                table: "ProcessosJuridicos");

            migrationBuilder.DropIndex(
                name: "IX_ProcessosJuridicos_ProcuradorId",
                table: "ProcessosJuridicos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProcessosJuridicos_ProcuradorId",
                table: "ProcessosJuridicos",
                column: "ProcuradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessosJuridicos_Usuarios_ProcuradorId",
                table: "ProcessosJuridicos",
                column: "ProcuradorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
