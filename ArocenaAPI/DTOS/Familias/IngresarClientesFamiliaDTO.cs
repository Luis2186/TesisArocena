using ArocenaAPI.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace ArocenaAPI.DTOS.Familias
{
    public class IngresarClientesFamiliaDTO
    {
        public int FamiliaId { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public List<int> clientesId { get; set; }
       
    }
}
