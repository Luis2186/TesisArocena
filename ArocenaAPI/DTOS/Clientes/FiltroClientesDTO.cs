using ArocenaAPI.DTOS.Empresas;
using ArocenaAPI.DTOS.Familias;
using ArocenaAPI.DTOS.MetodosDePagos;
using ArocenaAPI.ValidacionesDataAnnotation;
using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.Clientes
{
    public class FiltroClientesDTO
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistrosPorPagina { get; set; } = 10;
        public PaginacionDTO Paginacion
        {
            get { return new PaginacionDTO() { Pagina = Pagina, CantidadRegistrosPorPagina = CantidadRegistrosPorPagina }; }
        }

        public string CampoOrdenar { get; set; }
        public bool OrdenAscendente { get; set; } = true;
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string Celular { get; set; }
        public string FamiliaApellido { get; set; }
        public string NombreMetodoDePagoSugerido { get; set; }
        public string RutEmpresa { get; set; }    
    }
}
