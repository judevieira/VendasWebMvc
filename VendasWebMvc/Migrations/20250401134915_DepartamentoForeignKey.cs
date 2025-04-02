using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendasWebMvc.Migrations
{
    /// <inheritdoc />
    public partial class DepartamentoForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_departamentoId",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "departamentoId",
                table: "Vendedor",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_departamentoId",
                table: "Vendedor",
                newName: "IX_Vendedor_DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor",
                column: "DepartamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendedor_Departamento_DepartamentoId",
                table: "Vendedor");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Vendedor",
                newName: "departamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vendedor_DepartamentoId",
                table: "Vendedor",
                newName: "IX_Vendedor_departamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendedor_Departamento_departamentoId",
                table: "Vendedor",
                column: "departamentoId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
