using ArocenaAPI.Entidades;
using ArocenaAPI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.DTOS.Familias
{
    public class FamiliaCreacionDTO : FamiliaPatchDTO
    {
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public List<int> ClientesIds { get; set; }
    }
}
