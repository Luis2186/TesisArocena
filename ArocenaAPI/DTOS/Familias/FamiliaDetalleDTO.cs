using ArocenaAPI.DTOS.Clientes;
using ArocenaAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ArocenaAPI.DTOS.Familias
{
    public class FamiliaDetalleDTO :FamiliaDTO
    {
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public List<ClienteDTO> clientes { get; set; }
    }
}
