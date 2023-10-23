using ArocenaAPI.DTOS.MetodosDePagos;
using ArocenaAPI.DTOS;
using ArocenaAPI.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArocenaAPI.DTOS.ReglasDeNegocio;

namespace ArocenaAPI.Controllers
{
    [ApiController]
    [Route("api/reglasDeNegocio")]
    public class ReglasDeNegocioController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
 
        public ReglasDeNegocioController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("obtenerTodas")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult<List<ReglaDeNegocioDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            try
            {
                return await Get<ReglaDeNegocio, ReglaDeNegocioDTO>();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }

        }

        [HttpGet("{id:int}", Name = "obtenerReglaDeNegocio")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult<ReglaDeNegocioDTO>> Get(int id)
        {
            try
            {
                var regla = await context.ReglasDeNegocios.FirstOrDefaultAsync(x => x.Id == id);
                if (regla == null) return BadRequest("No existe la regla de negocio que esta buscando");

                return await Get<ReglaDeNegocio, ReglaDeNegocioDTO>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }

        }

        [HttpPost("ingresar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult> Post([FromBody] ReglaDeNegocioCreacionDTO reglaDeNegocioCreacionDTO)
        {
            try
            {
                return await Post<ReglaDeNegocioCreacionDTO, ReglaDeNegocio, ReglaDeNegocioDTO>(reglaDeNegocioCreacionDTO, "obtenerReglaDeNegocio");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }

        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<ReglaDeNegocioCreacionDTO> patchDocument)
        {
            try
            {
                var regla = await context.ReglasDeNegocios.FirstOrDefaultAsync(x => x.Id == id);
                if (regla == null) return BadRequest("No existe la regla de negocio que intenta actualizar");

                return await Patch<ReglaDeNegocio, ReglaDeNegocioCreacionDTO>(id, patchDocument);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }

        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                return await Delete<ReglaDeNegocio>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }

        }


    }
}
