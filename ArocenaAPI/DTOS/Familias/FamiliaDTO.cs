using ArocenaAPI.Entidades;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.Familias
{
    public class FamiliaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo apellido es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El campo direccion es requerido")]
        [StringLength(maximumLength: 40, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo telefono fijo es requerido")]
        public string TelefonoFijo { get; set; }

    }
}
