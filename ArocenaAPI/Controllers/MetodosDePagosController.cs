using ArocenaAPI.DTOS;
using ArocenaAPI.DTOS.Empresas;
using ArocenaAPI.DTOS.MetodosDePagos;
using ArocenaAPI.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArocenaAPI.Controllers
{
    [ApiController]
    [Route("api/metodosDePago")]
    public class MetodosDePagosController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public MetodosDePagosController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("obtenerTodos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<List<MetodoDePagoDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            try
            {
                return await Get<MetodoDePago, MetodoDePagoDTO>();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
         
        }

        [HttpGet("{id:int}", Name = "obtenerMetodoDePago")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<MetodoDePagoDTO>> Get(int id)
        {
            try
            {
                return await Get<MetodoDePago, MetodoDePagoDTO>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        
        }

        [HttpPost("ingresar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Rrhh")]
        public async Task<ActionResult> Post([FromBody] MetodoDePagoCreacionDTO metodoDePagoCreacionDTO)
        {
            try
            {                
                var metodoExiste = await context.MetodosDePagos.FirstOrDefaultAsync(mdp => mdp.Nombre.Trim() == metodoDePagoCreacionDTO.Nombre.Trim());

                if (metodoExiste != null) return BadRequest("Ya existe el metodo de pago que esta intentando ingresar");
                return await Post<MetodoDePagoCreacionDTO, MetodoDePago, MetodoDePagoDTO>(metodoDePagoCreacionDTO, "obtenerMetodoDePago");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
          
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Rrhh")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<MetodoDePagoCreacionDTO> patchDocument)
        {
            try
            {
                return await Patch<MetodoDePago, MetodoDePagoCreacionDTO>(id, patchDocument);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
 
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Rrhh")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return await Delete<MetodoDePago>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
     
        }
    }
}
