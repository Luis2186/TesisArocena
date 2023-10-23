using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArocenaAPI.Migrations
{
    public partial class ReglaDeNegocio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MetodoDePagoSugeridoId",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FamiliaId",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ReglasDeNegocios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimoPedidoLts = table.Column<int>(type: "int", nullable: false),
                    DistanciaMaximaDePedidosKm = table.Column<int>(type: "int", nullable: false),
                    PrecioGasoil = table.Column<double>(type: "float", nullable: false),
                    PrecioQueroseno = table.Column<double>(type: "float", nullable: false),
                    PrecioFleteGasoilMayor500lts = table.Column<double>(type: "float", nullable: false),
                    PrecioFleteQuerosenoMayor500lts = table.Column<double>(type: "float", nullable: false),
                    PrecioFleteQuerosenoMenor500lts = table.Column<double>(type: "float", nullable: false),
                    PrecioFleteFueraDeZona = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReglasDeNegocios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReglasDeNegocios");

            migrationBuilder.AlterColumn<int>(
                name: "MetodoDePagoSugeridoId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FamiliaId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
