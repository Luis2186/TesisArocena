using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArocenaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ConfigNulleablesCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Familia_FamiliaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_MetodosDePagos_MetodoDePagoSugeridoId",
                table: "Clientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Familia_FamiliaId",
                table: "Clientes",
                column: "FamiliaId",
                principalTable: "Familia",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_MetodosDePagos_MetodoDePagoSugeridoId",
                table: "Clientes",
                column: "MetodoDePagoSugeridoId",
                principalTable: "MetodosDePagos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Familia_FamiliaId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_MetodosDePagos_MetodoDePagoSugeridoId",
                table: "Clientes");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Empresas_EmpresaId",
                table: "Clientes",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Familia_FamiliaId",
                table: "Clientes",
                column: "FamiliaId",
                principalTable: "Familia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_MetodosDePagos_MetodoDePagoSugeridoId",
                table: "Clientes",
                column: "MetodoDePagoSugeridoId",
                principalTable: "MetodosDePagos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
