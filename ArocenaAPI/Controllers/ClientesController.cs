using ArocenaAPI.DTOS.Empresas;
using ArocenaAPI.DTOS;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArocenaAPI.Entidades;
using ArocenaAPI.DTOS.Clientes;
using ArocenaAPI.Helpers;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace ArocenaAPI.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : CustomBaseController
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly ILogger<ClientesController> logger;
        public ClientesController(ApplicationDbContext context, IMapper mapper, ILogger<ClientesController> logger) : base(context, mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost("ingresar")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacionDTO)
        {
            try
            {
                var clienteExiste = await context.Clientes
                    .FirstOrDefaultAsync(cli => cli.Nombres.Trim() == clienteCreacionDTO.Nombres.Trim() 
                    && cli.Apellidos.Trim() == clienteCreacionDTO.Apellidos.Trim());

                if (clienteExiste != null) return BadRequest("Ya existe el cliente que esta intentando ingresar");

                return await Post<ClienteCreacionDTO, Cliente, ClienteDTO>(clienteCreacionDTO, "obtenerCliente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor." + ex.Message);
            }
        }

        [HttpGet("obtenerTodos")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<List<ClienteDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            try
            {
                var clientes = context.Clientes.Include(cli => cli.Familia)
                    .Include(cli=> cli.Empresa)
                    .Include(cli=>cli.MetodoDePagoSugerido).AsQueryable();
               
                await HttpContext.InsertarParametrosPaginacion(clientes, paginacionDTO.CantidadRegistrosPorPagina);
                var cliPag = await clientes.Paginar(paginacionDTO).ToListAsync();

                return mapper.Map<List<ClienteDTO>>(cliPag);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("{id:int}", Name = "obtenerCliente")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<ClienteDTO>> Get(int id)
        {
            try
            {
                return await Get<Cliente, ClienteDTO>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPatch("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Rrhh")]
        public async Task<ActionResult> Patch(int id, [FromBody] JsonPatchDocument<ClienteCreacionDTO> patchDocument)
        {
            try
            {
                return await Patch<Cliente, ClienteCreacionDTO>(id, patchDocument);
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
                return await Delete<Cliente>(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("filtro")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador,Cajero,Rrhh")]
        public async Task<ActionResult<List<ClienteDTO>>> Filtrar([FromQuery] FiltroClientesDTO filtroClienteDTO)
        {
            var clientesQueryable = context.Clientes.AsQueryable();
       
            if (!string.IsNullOrEmpty(filtroClienteDTO.Nombres))
            {
                clientesQueryable = clientesQueryable.Where(x => x.Nombres.Contains(filtroClienteDTO.Nombres));
            }

            if (!string.IsNullOrEmpty(filtroClienteDTO.Apellidos))
            {
                clientesQueryable = clientesQueryable.Where(x => x.Apellidos.Contains(filtroClienteDTO.Apellidos));
            }

            if (!string.IsNullOrEmpty(filtroClienteDTO.Direccion))
            {
                clientesQueryable = clientesQueryable.Where(x => x.Direccion.Contains(filtroClienteDTO.Direccion));
            }

            if (!string.IsNullOrEmpty(filtroClienteDTO.TelefonoFijo))
            {
                clientesQueryable = clientesQueryable.Where(x => x.TelefonoFijo.Contains(filtroClienteDTO.TelefonoFijo));
            }

            if (!string.IsNullOrEmpty(filtroClienteDTO.Celular))
            {
                clientesQueryable = clientesQueryable.Where(x => x.Celular.Contains(filtroClienteDTO.Celular));
            }
             
            if (!string.IsNullOrEmpty(filtroClienteDTO.FamiliaApellido))
            {
                clientesQueryable = clientesQueryable.Where(x => x.Familia != null & x.Familia.Apellido == filtroClienteDTO.FamiliaApellido);
            }

            if (!string.IsNullOrEmpty(filtroClienteDTO.NombreMetodoDePagoSugerido))
            {
                clientesQueryable = clientesQueryable.Where(x => x.MetodoDePagoSugerido!= null & x.MetodoDePagoSugerido.Nombre == filtroClienteDTO.NombreMetodoDePagoSugerido);
            }

            if (!string.IsNullOrEmpty(filtroClienteDTO.RutEmpresa))
            {
                clientesQueryable = clientesQueryable.Where(x => x.Empresa != null && x.Empresa.Rut == filtroClienteDTO.RutEmpresa);
            }

            //if (!string.IsNullOrEmpty(filtroClienteDTO.CampoOrdenar))
            //{
            //    var tipoOrden = filtroClienteDTO.OrdenAscendente ? "ascending" : "descending";

            //    try
            //    {
            //        clientesQueryable = clientesQueryable.OrderBy($"{filtroClienteDTO.CampoOrdenar} {tipoOrden}");

            //    }
            //    catch (Exception ex)
            //    {
            //        logger.LogError(ex.Message, ex);
            //    }
            //}

            await HttpContext.InsertarParametrosPaginacion(clientesQueryable,
                filtroClienteDTO.CantidadRegistrosPorPagina);

            var clientes = await clientesQueryable.Paginar(filtroClienteDTO.Paginacion).ToListAsync();

            return mapper.Map<List<ClienteDTO>>(clientes);
        }


    }
}
