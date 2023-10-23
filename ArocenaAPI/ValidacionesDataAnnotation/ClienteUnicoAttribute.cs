using ArocenaAPI.Entidades;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.ValidacionesDataAnnotation
{

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ClienteUnicoAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (DbContext)validationContext.GetService(typeof(DbContext));
            var cliente = (Cliente)value;

            if (dbContext.Set<Cliente>().Any(c => c.Nombres == cliente.Nombres && c.Apellidos == cliente.Apellidos && c.Id != cliente.Id))
            {
                return new ValidationResult("El cliente ya existe.");
            }

            return ValidationResult.Success;
        }
    }
}
