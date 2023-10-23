using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.MetodosDePagos
{
    public class MetodoDePagoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Nombre { get; set; }
    }
}
