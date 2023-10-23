using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.Usuarios
{
    public class EditarAdminDTO
    {
        [Required]
        public string UserName { get; set; }
    }
}
