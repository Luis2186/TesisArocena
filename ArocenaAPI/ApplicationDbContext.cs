using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite;
using System.Security.Claims;
using ArocenaAPI.Entidades;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace ArocenaAPI
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MetodoDePago>().HasIndex(metodo => metodo.Nombre).IsUnique();
            builder.Entity<Empresa>().HasIndex(empresa => empresa.Rut).IsUnique();
            builder.Entity<Cliente>().HasIndex(c => new { c.Nombres, c.Apellidos }).IsUnique();

            //builder.Entity<TipoDeIluminacion>().HasIndex(tipoIlu => tipoIlu.Nombre).IsUnique();
            //builder.Entity<Tasas>().HasIndex(tasa => tasa.Nombre).IsUnique();

            builder.Entity<Cliente>()
                   .Property(c => c.Celular)
                   .IsRequired(false); // Esto indica que la propiedad Edad puede ser nula

            builder.Entity<Cliente>()
                .HasOne(c => c.Empresa)
                .WithMany(e => e.ClientesIntegrantes)
                .HasForeignKey(c => c.EmpresaId)
                .IsRequired(false); // Hacer que la clave foránea sea nullable

            builder.Entity<Cliente>()
                .HasOne(c => c.Familia)
                .WithMany(e => e.Integrantes)
                .HasForeignKey(c => c.FamiliaId)
                .IsRequired(false); // Hacer que la clave foránea sea nullable

            builder.Entity<Cliente>()
                .HasOne(c => c.MetodoDePagoSugerido)
                .WithMany()
                .HasForeignKey(c => c.MetodoDePagoSugeridoId)
                .IsRequired(false); // Hacer que la clave foránea sea nullable



            SeedData(builder);
            base.OnModelCreating(builder);  
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var usuarioAdminId = "5673b8cf-12de-44f6-92ad-fae4a77932ad";
            var usuarioRrhhId = "2cd9e94a-7944-40eb-9f98-5b321efa57b9";
            var usuarioCajeroId = "6205ee89-d078-4940-9c3e-38f71eec8d1a";
            var rolAdminId = "9aae0b6d-d50c-4d0a-9b90-2a6873e3845d";
            var rolRrhhId = "152fbd65-8f57-4c13-b8d1-80978d032ba8";
            var rolCajeroId = "d8a09bde-44fa-4874-8f8f-6182fa935123";

            var prueba="prueba";

            var rolAdmin = new IdentityRole()
            {
                Id = rolAdminId,
                Name = "Administrador",
                NormalizedName = "Administrador"
            };

            var rolRrhh = new IdentityRole()
            {
                Id = rolRrhhId,
                Name = "Recursos humanos",
                NormalizedName = "Recursos humanos"
            };

            var rolCajero = new IdentityRole()
            {
                Id = rolCajeroId,
                Name = "Cajero",
                NormalizedName = "Cajero"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();

            var usernameAdmin = "Administrador";
            var usernameRrhh = "Rrhh";
            var usernameCajero = "Cajero";

            var usuarioAdmin = new IdentityUser()
            {
                Id = usuarioAdminId,
                UserName = usernameAdmin,
                NormalizedUserName = usernameAdmin,
                Email = usernameAdmin,
                NormalizedEmail = usernameAdmin,
                PasswordHash = passwordHasher.HashPassword(null, "Admin123456!")
            };

            var usuarioCajero = new IdentityUser()
            {
                Id = usuarioCajeroId,
                UserName = usernameCajero,
                NormalizedUserName = usernameCajero,
                Email = usernameCajero,
                NormalizedEmail = usernameCajero,
                PasswordHash = passwordHasher.HashPassword(null, "Cajero123456!")
            };

            var usuariorrhh = new IdentityUser()
            {
                Id = usuarioRrhhId,
                UserName = usernameRrhh,
                NormalizedUserName = usernameRrhh,
                Email = usernameRrhh,
                NormalizedEmail = usernameRrhh,
                PasswordHash = passwordHasher.HashPassword(null, "Rrhh123456!")
            };

            //modelBuilder.Entity<IdentityUser>()
            //    .HasData(usuarioAdmin);
            //modelBuilder.Entity<IdentityUser>()
            //    .HasData(usuarioCajero);
            //modelBuilder.Entity<IdentityUser>()
            //    .HasData(usuariorrhh);

            //modelBuilder.Entity<IdentityRole>()
            //    .HasData(rolAdmin);
            //modelBuilder.Entity<IdentityRole>()
            //    .HasData(rolRrhh);
            //modelBuilder.Entity<IdentityRole>()
            //    .HasData(rolCajero);

            //modelBuilder.Entity<IdentityUserClaim<string>>()
            //    .HasData(new IdentityUserClaim<string>()
            //    {
            //        Id = 1,
            //        ClaimType = ClaimTypes.Role,
            //        UserId = usuarioAdminId,
            //        ClaimValue = "Administrador"
            //    });

            //modelBuilder.Entity<IdentityUserClaim<string>>()
            //    .HasData(new IdentityUserClaim<string>()
            //    {
            //        Id = 2,
            //        ClaimType = ClaimTypes.Role,
            //        UserId = usuarioRrhhId,
            //        ClaimValue = "Rrhh"
            //    });

            //modelBuilder.Entity<IdentityUserClaim<string>>()
            //    .HasData(new IdentityUserClaim<string>()
            //    {
            //        Id = 3,
            //        ClaimType = ClaimTypes.Role,
            //        UserId = usuarioCajeroId,
            //        ClaimValue = "Cajero"
            //    });

            //var mdp1 = new MetodoDePago() { Id = 1, Nombre = "Efectivo" };
            //var mdp2 = new MetodoDePago() { Id = 2, Nombre = "Tarjeta" };
            //var mdp3 = new MetodoDePago() { Id = 3, Nombre = "Cheque" };
            //var mdp4 = new MetodoDePago() { Id = 4, Nombre = "Transferencia" };
            //var mdp5 = new MetodoDePago() { Id = 5, Nombre = "Pendiente" };
            //var mdp6 = new MetodoDePago() { Id = 6, Nombre = "Vales" };

            //modelBuilder.Entity<MetodoDePago>().HasData(new List<MetodoDePago>
            //{
            //    mdp1,mdp2,mdp3,mdp4,mdp5
            //});

            //var familia1 = new Familia() { Id = 1, Apellido = "Stan", TelefonoFijo = "26012565", Direccion = "Dir2" };
            //var familia2 = new Familia() { Id = 2, Apellido = "Casanova", TelefonoFijo = "26002255", Direccion = "Dir3" };
            //var familia3 = new Familia() { Id = 3, Apellido = "Etcheveria", TelefonoFijo = "26001478", Direccion = "Dir4" };

            //modelBuilder.Entity<Familia>().HasData(new List<Familia>
            //{
            //    familia1,familia2,familia3
            //});

            //var empresa1 = new Empresa() { Id = 1, Nombre = "Stiler", Direccion = "Misiones 1466", Rut = "210129280011", Telefono = "29162616" };
            //var empresa2 = new Empresa() { Id = 2, Nombre = "Banifox", Direccion = "Juan Paullier 2378", Rut = "215441590013", Telefono = "22002610" };
            //var empresa3 = new Empresa() { Id = 3, Nombre = "Tienda Inglesa", Direccion = "Dr. Alejandro Schroeder 6436", Rut = "210094030014", Telefono = "26061111" };
            //var empresa4 = new Empresa() { Id = 4, Nombre = "Devoto", Direccion = "Av.Italia 6958", Rut = "210297450018", Telefono = "26010443" };

            //modelBuilder.Entity<Empresa>().HasData(new List<Empresa>
            //{
            //    empresa1,empresa2,empresa3,empresa4
            //});

            //var cli1 = new Cliente() { Id = 1, Nombres = "Federico", Apellidos = "Gonzales", Celular = "099555666", Direccion = "Dir1", EmpresaId = empresa1.Id };
            //var cli2 = new Cliente() { Id = 2, Nombres = "Manuel", Apellidos = "Stan", Celular = "099665455", Direccion = "Dir2", FamiliaId = familia1.Id };
            //var cli3 = new Cliente() { Id = 3, Nombres = "Agustin", Apellidos = "Casanova", Celular = "091547355", Direccion = "Dir3", EmpresaId = empresa1.Id, FamiliaId = familia2.Id };
            //var cli4 = new Cliente() { Id = 4, Nombres = "Marcia", Apellidos = "Etcheveria", Celular = "098223555", Direccion = "Dir4", EmpresaId = empresa2.Id, FamiliaId = familia3.Id };
            //var cli5 = new Cliente() { Id = 5, Nombres = "Florencia", Apellidos = "Perez", Celular = "098566871", Direccion = "Dir5", EmpresaId = empresa3.Id };
            //var cli6 = new Cliente() { Id = 6, Nombres = "Agustina", Apellidos = "Villanueva", Celular = "099357159", Direccion = "Dir6", EmpresaId = empresa4.Id };
            //var cli7 = new Cliente() { Id = 7, Nombres = "Juan", Apellidos = "Casanova", Celular = "099356136", Direccion = "Dir3", EmpresaId = empresa4.Id, FamiliaId = familia2.Id };
            //var cli8 = new Cliente() { Id = 8, Nombres = "Carolina", Apellidos = "Casanova", Celular = "099654123", Direccion = "Dir3", EmpresaId = empresa4.Id, FamiliaId = familia2.Id };
            //var cli9 = new Cliente() { Id = 9, Nombres = "Horacio", Apellidos = "Etcheveria", Celular = "099357159", Direccion = "Dir4", FamiliaId = familia3.Id };
            //var cli10 = new Cliente() { Id = 10, Nombres = "Andrea", Apellidos = "Perez", Celular = "099497159", Direccion = "Dir10" };
            //var cli11 = new Cliente() { Id = 11, Nombres = "Maximiliano", Apellidos = "Etcheveria", Celular = "099397159", Direccion = "Dir4", FamiliaId = familia3.Id };
            //var cli12 = new Cliente() { Id = 12, Nombres = "Raul", Apellidos = "Stan", Celular = "099677159", Direccion = "Dir2", FamiliaId = familia1.Id };

            //modelBuilder.Entity<Cliente>().HasData(new List<Cliente>
            //{
            //    cli1,cli2,cli3,cli4,cli5,cli6,cli7,cli8,cli9,cli10,cli11,cli12
            //});



            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
         
        }

        public DbSet<Familia> Familia { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<MetodoDePago> MetodosDePagos { get; set; }

        //public DbSet<PeliculasGeneros> PeliculasGeneros { get; set; }
        //public DbSet<SalaDeCine> SalasDeCine { get; set; }
        //public DbSet<PeliculasSalasDeCine> PeliculasSalasDeCines { get; set; }
        //public DbSet<Review> Reviews { get; set; }
    


    }
}
