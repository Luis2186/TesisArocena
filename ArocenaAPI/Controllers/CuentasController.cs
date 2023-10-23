using ArocenaAPI.DTOS;
using ArocenaAPI.DTOS.Empresas;
using ArocenaAPI.DTOS.Usuarios;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ArocenaAPI.Controllers
{
    [ApiController]
    [Route("api/cuentas")]
    public class CuentasController : CustomBaseController
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext context;

        public CuentasController(UserManager<IdentityUser> userManager, IConfiguration configuration,
            SignInManager<IdentityUser> signInManager,ApplicationDbContext context, IMapper mapper) : base(context,mapper)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
            this.context = context;
        }


        [HttpPost("registrar")] //  api/cuentas/registrar
        public async Task<ActionResult<UsuarioToken>> Registrar(CredencialesUsuario credencialesUsuario)
        {
            try
            {
                var usuario = new IdentityUser { UserName = credencialesUsuario.UserName, Email = credencialesUsuario.Email };
                var resultado = await userManager.CreateAsync(usuario, credencialesUsuario.Password);

                if (resultado.Succeeded) return await ConstruirToken(credencialesUsuario);

                return BadRequest(resultado.Errors);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioToken>> Login(CredencialesUsuario credencialesUsuario)
        {
            try
            {
                var resultado = await signInManager.PasswordSignInAsync(credencialesUsuario.UserName,
                credencialesUsuario.Password, isPersistent: false, lockoutOnFailure: false);

                if (resultado.Succeeded) return await ConstruirToken(credencialesUsuario);

                return BadRequest("Login incorrecto");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost("asignarRol")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles ="Administrador")]
        public async Task<ActionResult> AsignarRol(EditarRolDTO editarRolDTO)
        {
            try
            {
                var user = await userManager.FindByIdAsync(editarRolDTO.UsuarioId);

                if (user == null) return NotFound();

                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editarRolDTO.NombreRol));
                return Ok("Rol agregado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpPost("removerRol")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult> RemoverRol(EditarRolDTO editarRolDTO)
        {
            try
            {
                var user = await userManager.FindByIdAsync(editarRolDTO.UsuarioId);

                if (user == null) return NotFound();

                await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editarRolDTO.NombreRol));
                return Ok("Rol removido");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("usuarios")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult<List<UsuarioDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO)
        {
            try
            {
                var queryable = context.Users.AsQueryable();
                queryable = queryable.OrderBy(usuario => usuario.UserName);
                return await Get<IdentityUser, UsuarioDTO>(paginacionDTO);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        [HttpGet("roles")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrador")]
        public async Task<ActionResult<List<string>>> GetRoles()
        {
            try
            {
                return await context.Roles.Select(roles => roles.Name).ToListAsync();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }


        [HttpGet("renovarToken")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<UsuarioToken>> RenovarToken()
        {
            try
            {
                var nombreClaim = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.Name).FirstOrDefault();
                var nombre = nombreClaim.Value;
                var emailClaim = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.Email).FirstOrDefault();
                var email = emailClaim.Value;

                var credencialesUsuario = new CredencialesUsuario
                {
                    UserName = nombre,
                    Email = email
                };
                return await ConstruirToken(credencialesUsuario);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor.");
            }
        }

        private async Task<UsuarioToken> ConstruirToken(CredencialesUsuario credencialesUsuario)
        {
            var claims = new List<Claim>() //Un claim es una informacion emitida por una fuente en la cual confiamos.
            {
                new Claim(ClaimTypes.Name, credencialesUsuario.UserName),
                new Claim(ClaimTypes.Email, credencialesUsuario.Email),
            };

            var usuario = await userManager.FindByNameAsync(credencialesUsuario.UserName);

            claims.Add(new Claim(ClaimTypes.NameIdentifier, usuario.Id));

            var claimsDb = await userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDb);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["llavejwt"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddDays(1);
            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: creds);

            return new UsuarioToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                Expiracion = expiracion
            };
        }

    }
}
