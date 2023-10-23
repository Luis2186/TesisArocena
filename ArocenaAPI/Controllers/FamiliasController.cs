using ArocenaAPI.DTOS.Empresas;
using ArocenaAPI.DTOS;
using ArocenaAPI.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArocenaAPI.DTOS.Familias;
using ArocenaAPI.DTOS.Clientes;
using ArocenaAPI.Helpers;

namespace ArocenaAPI.Controllers
{
    [ApiController]
    [Route("api/familias")]
    public class FamiliasController :CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FamiliasController(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("ingresar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult> Post([FromBody] FamiliaCreacionDTO familiaCreacionDTO)
        {
            try
            {
                var familiaExiste = await context.Familia.FirstOrDefaultAsync(familia => familia.Apellido.Trim() == familiaCreacionDTO.Apellido.Trim());

                if (familiaExiste != null) return BadRequest("Ya existe la familia que esta intentando ingresar");

                if (familiaCreacionDTO.ClientesIds == null) return BadRequest("Necesita ingresar un integrante como minimo");

                var clientes = await context.Clientes.Where(clienteBD => familiaCreacionDTO.ClientesIds.Contains(clienteBD.Id))
                    .Select(x => x.Id).ToListAsync();

                if (familiaCreacionDTO.ClientesIds.Count != clientes.Count) return BadRequest("No existe uno de los integrantes enviados");

                return await Post<FamiliaCreacionDTO, Familia, FamiliaDTO>(familiaCreacionDTO, "obtenerFamilia");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("obtenerTodas")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<List<FamiliaDetalleDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            try
            {
                var familia = context.Familia.Include(cli => cli.Integrantes).AsQueryable();

                await HttpContext.InsertarParametrosPaginacion(familia, paginacionDTO.CantidadRegistrosPorPagina);
                var cliPag = await familia.Paginar(paginacionDTO).ToListAsync();

                return mapper.Map<List<FamiliaDetalleDTO>>(cliPag);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id:int}", Name = "obtenerFamilia")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<FamiliaDetalleDTO>> Get(int id)
        {
            try
            {
                var familia = await context.Familia.Include(x=>x.Integrantes).FirstOrDefaultAsync(x => x.Id == id);

                if (familia == null) return BadRequest("No existe la familia que esta buscando");

                return mapper.Map<FamiliaDetalleDTO>(familia);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Rrhh")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<FamiliaPatchDTO> patchDocument)
        {
            try
            {
                return await Patch<Familia, FamiliaPatchDTO>(id, patchDocument);
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
                return await Delete<Familia>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut("ingresarClientes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult> IngresarCliente([FromBody] IngresarClientesFamiliaDTO ingresarClientesFamiliaDTO)
        {
            try
            {
                if (ingresarClientesFamiliaDTO.clientesId == null) return BadRequest("Necesita ingresar un integrante como minimo");

                var clientes = await context.Clientes.Where(clienteBD => ingresarClientesFamiliaDTO.clientesId.Contains(clienteBD.Id))
                    .Select(x => x).ToListAsync();

                if (ingresarClientesFamiliaDTO.clientesId.Count != clientes.Count) return BadRequest("No existe uno de los integrantes enviados");

                var familiaDB= await context.Familia
                    .Include(x => x.Integrantes)
                    .FirstOrDefaultAsync(x=>x.Id == ingresarClientesFamiliaDTO.FamiliaId);

                if (familiaDB == null) return NotFound();

                if(ingresarClientesFamiliaDTO.clientesId == null) return BadRequest("No existen integrantes para ingresar");

                foreach (var cli in clientes)
                {                  
                    familiaDB.Integrantes.Add(cli);
                }
                context.Update(familiaDB);
                await context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPut("eliminarClientes")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult> EliminarCliente([FromBody] IngresarClientesFamiliaDTO ingresarClientesFamiliaDTO)
        {
            try
            {
                if (ingresarClientesFamiliaDTO.clientesId == null) return BadRequest("Necesita ingresar un integrante como minimo");

                var clientes = await context.Clientes.Where(clienteBD => ingresarClientesFamiliaDTO.clientesId.Contains(clienteBD.Id))
                    .Select(x => x).ToListAsync();

                if (ingresarClientesFamiliaDTO.clientesId.Count != clientes.Count) return BadRequest("No existe uno de los integrantes enviados");

                var familiaDB = await context.Familia
                    .Include(x => x.Integrantes)
                    .FirstOrDefaultAsync(x => x.Id == ingresarClientesFamiliaDTO.FamiliaId);

                if (familiaDB == null) return NotFound();

                if (ingresarClientesFamiliaDTO.clientesId == null) return BadRequest("No existen integrantes para eliminar");

                foreach (var cli in clientes)
                {
                    familiaDB.Integrantes.Remove(cli);
                }
                context.Update(familiaDB);
                await context.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }


    }
}
