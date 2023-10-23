using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.Usuarios
{
    public class CredencialesUsuario
    {
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
