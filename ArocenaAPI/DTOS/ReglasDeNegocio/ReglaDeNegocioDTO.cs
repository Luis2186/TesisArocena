using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.ReglasDeNegocio
{
    public class ReglaDeNegocioDTO
    {
        public DateTime FechaDeRegistro { get; set; }

        [Required(ErrorMessage = "El campo {0} es de caracter obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que 0.")]
        public int MinimoPedidoLts { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que 0.")]
        [Required(ErrorMessage = "El campo {0} es de caracter obligatorio")]
        public int DistanciaMaximaDePedidosKm { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que 0.")]
        [Required(ErrorMessage = "El campo {0} es de caracter obligatorio")]
        public double PrecioGasoil { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que 0.")]
        [Required(ErrorMessage = "El campo {0} es de caracter obligatorio")]
        public double PrecioQueroseno { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que 0.")]
        [Required(ErrorMessage = "El campo {0} es de caracter obligatorio")]
        public double PrecioFleteGasoilMayor500lts { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que 0.")]
        [Required(ErrorMessage = "El campo {0} es de caracter obligatorio")]
        public double PrecioFleteQuerosenoMayor500lts { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que 0.")]
        [Required(ErrorMessage = "El campo {0} es de caracter obligatorio")]
        public double PrecioFleteQuerosenoMenor500lts { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que 0.")]
        [Required(ErrorMessage = "El campo {0} es de caracter obligatorio")]
        public double PrecioFleteFueraDeZona { get; set; }
    }
}
