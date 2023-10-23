using ArocenaAPI.DTOS.Empresas;
using ArocenaAPI.DTOS.Familias;
using ArocenaAPI.DTOS.MetodosDePagos;
using ArocenaAPI.Entidades;
using ArocenaAPI.ValidacionesDataAnnotation;
using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.Clientes
{
    public class ClienteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El campo apellidos es requerido")]
        [StringLength(maximumLength: 30, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El campo direccion es requerido")]
        [StringLength(maximumLength: 100, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Direccion { get; set; }

        [RegularExpression(@"^[2|4|5|6|7|8|9]\d{7}$", ErrorMessage = "Por favor ingresa un numero de telefono valido.")]
        [StringLength(maximumLength: 8, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string TelefonoFijo { get; set; }

        [RegularExpression(@"^[09]\d{8}$", ErrorMessage = "Por favor ingresa un numero de celular valido.")]
        [RequiredIf("TelefonoFijo", null, ErrorMessage = "El número de celular es requerido si el número de telefono fijo está vacío.")]
        [StringLength(maximumLength: 9, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        public string Celular { get; set; }

        public FamiliaDTO Familia { get; set; }
        public MetodoDePagoDTO MetodoDePagoSugerido { get; set; }
        public EmpresaDTO Empresa { get; set; }
    }
}
