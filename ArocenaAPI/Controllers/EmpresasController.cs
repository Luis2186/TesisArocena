using ArocenaAPI.DTOS.MetodosDePagos;
using ArocenaAPI.DTOS;
using ArocenaAPI.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ArocenaAPI.DTOS.Empresas;
using Microsoft.EntityFrameworkCore;

namespace ArocenaAPI.Controllers
{
    [ApiController]
    [Route("api/empresas")]
    public class EmpresasController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        public EmpresasController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("ingresar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult> Post([FromBody] EmpresaCreacionDTO empresaCreacionDTO)
        {
            try
            {
                var empresaExiste = await context.Empresas.FirstOrDefaultAsync(empresa => empresa.Rut.Trim() == empresaCreacionDTO.Rut.Trim());

                if (empresaExiste != null) return BadRequest("Ya existe la empresa que esta intentando ingresar");

                return await Post<EmpresaCreacionDTO, Empresa, EmpresaDTO>(empresaCreacionDTO, "obtenerEmpresa");
            }
            catch (Exception)
            {                
                return StatusCode(500, "Error interno del servidor.");
            }          
        }

        [HttpGet("obtenerTodas")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<List<EmpresaDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            try
            {
                return await Get<Empresa, EmpresaDTO>(paginacionDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }  
        }

        [HttpGet("{id:int}", Name = "obtenerEmpresa")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<EmpresaDTO>> Get(int id)
        {
            try
            {
                var existeEmpresa = context.Empresas.FirstOrDefaultAsync(x => x.Id == id);
                if (existeEmpresa == null) return BadRequest("La empresa que busca no existe");

                return await Get<Empresa, EmpresaDTO>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }         
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Rrhh")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<EmpresaCreacionDTO> patchDocument)
        {
            try
            {
                var existeEmpresa = context.Empresas.FirstOrDefaultAsync(x => x.Id == id);
                if (existeEmpresa == null) return BadRequest("La empresa que quiere actualizar no existe");

                return await Patch<Empresa, EmpresaCreacionDTO>(id, patchDocument);
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
                return await Delete<Empresa>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }     
        }
    }
}
