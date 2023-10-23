using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArocenaAPI.Migrations
{
    public partial class ingresoReglaNegocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeRegistro",
                table: "ReglasDeNegocios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "ReglasDeNegocios",
                columns: new[] { "Id", "DistanciaMaximaDePedidosKm", "FechaDeRegistro", "MinimoPedidoLts", "PrecioFleteFueraDeZona", "PrecioFleteGasoilMayor500lts", "PrecioFleteQuerosenoMayor500lts", "PrecioFleteQuerosenoMenor500lts", "PrecioGasoil", "PrecioQueroseno" },
                values: new object[] { 1, 15, new DateTime(2023, 10, 23, 18, 34, 9, 604, DateTimeKind.Local).AddTicks(8648), 200, 1500.0, 500.0, 1000.0, 500.0, 59.390000000000001, 59.5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReglasDeNegocios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "FechaDeRegistro",
                table: "ReglasDeNegocios");
        }
    }
}
