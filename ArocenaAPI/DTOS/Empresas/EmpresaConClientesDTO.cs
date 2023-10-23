using ArocenaAPI.Entidades;

namespace ArocenaAPI.DTOS.Empresas
{
    public class EmpresaConClientesDTO : EmpresaDTO
    {
        public List<Cliente> ClientesIntegrantes { get; set; }
    }
}
