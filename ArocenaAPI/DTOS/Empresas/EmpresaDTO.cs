using ArocenaAPI.Entidades;
using ArocenaAPI.ValidacionesDataAnnotation;
using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.Empresas
{
    public class EmpresaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Rut es requerido")]
        [Rut(ErrorMessage = "Rut en formato invalido o incorrecto")]
        [StringLength(maximumLength: 12, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Rut { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Direccion { get; set; }

        [RegularExpression(@"^[2|4|5|6|7|8|9]\d{7}$", ErrorMessage = "Por favor ingresa un numero de telefono valido.")]
        [StringLength(maximumLength: 9, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Telefono { get; set; }

    }
}
