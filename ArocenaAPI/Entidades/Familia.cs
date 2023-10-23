using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.Entidades
{
    public class Familia : IId
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo direccion es requerido")]
        [StringLength(maximumLength: 40, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Direccion  { get; set; }

        [Required(ErrorMessage = "El campo telefono fijo es requerido")]
        public string TelefonoFijo  { get; set; }

        public List<Cliente> Integrantes { get; set; }
    }
}
