using ArocenaAPI.DTOS.Clientes;
using ArocenaAPI.DTOS.Empresas;
using ArocenaAPI.DTOS.Familias;
using ArocenaAPI.DTOS.MetodosDePagos;
using ArocenaAPI.DTOS.ReglasDeNegocio;
using ArocenaAPI.DTOS.Usuarios;
using ArocenaAPI.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite;
using NetTopologySuite.Geometries;

namespace ArocenaAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles(GeometryFactory geometryFactory)
        {
            CreateMap<IdentityUser, UsuarioDTO>();

            CreateMap<MetodoDePago, MetodoDePagoDTO>().ReverseMap();
            CreateMap<MetodoDePagoCreacionDTO, MetodoDePago>();

            CreateMap<Empresa, EmpresaDTO>().ReverseMap();
            CreateMap<EmpresaCreacionDTO, Empresa>();

            CreateMap<Familia, FamiliaDTO>().ReverseMap();
            CreateMap<Familia, FamiliaDetalleDTO>()
                 .ForMember(x => x.clientes, options => options.MapFrom(MapFamiliaClientes)); ;
            CreateMap<FamiliaCreacionDTO, Familia>()
                .ForMember(x => x.Integrantes, options => options.MapFrom(MapFamiliaClientes));
            CreateMap<Familia, FamiliaPatchDTO>().ReverseMap();

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<ClienteCreacionDTO, Cliente>();

            CreateMap<ReglaDeNegocio, ReglaDeNegocioDTO>().ReverseMap();
            CreateMap<ReglaDeNegocioCreacionDTO, ReglaDeNegocio>().ReverseMap();


            //CreateMap<Genero, GeneroDTO>().ReverseMap();
            //CreateMap<GeneroCreacionDTO, Genero>();

            //CreateMap<Review, ReviewDTO>()
            //    .ForMember(x => x.NombreUsuario, x => x.MapFrom(y => y.Usuario.UserName));

            //CreateMap<ReviewDTO, Review>();
            //CreateMap<ReviewCreacionDTO, Review>();



            //CreateMap<SalaDeCine, SalaDeCineDTO>()
            //    .ForMember(x => x.Latitud, x => x.MapFrom(y => y.Ubicacion.Y))
            //    .ForMember(x => x.Longitud, x => x.MapFrom(y => y.Ubicacion.X));

            //CreateMap<SalaDeCineDTO, SalaDeCine>()
            //    .ForMember(x => x.Ubicacion, x => x.MapFrom(y =>
            //    geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));

            //CreateMap<SalaDeCineCreacionDTO, SalaDeCine>()
            //     .ForMember(x => x.Ubicacion, x => x.MapFrom(y =>
            //    geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));


            //CreateMap<Pelicula, PeliculaDTO>().ReverseMap();
            //CreateMap<PeliculaCreacionDTO, Pelicula>()
            //    .ForMember(x => x.Poster, options => options.Ignore())
            //    .ForMember(x => x.PeliculasGeneros, options => options.MapFrom(MapPeliculasGeneros))
            //    .ForMember(x => x.PeliculasActores, options => options.MapFrom(MapPeliculasActores));

            //CreateMap<Pelicula, PeliculaDetallesDTO>()
            //    .ForMember(x => x.Generos, options => options.MapFrom(MapPeliculasGeneros))
            //    .ForMember(x => x.Actores, options => options.MapFrom(MapPeliculasActores));

            //CreateMap<PeliculaPatchDTO, Pelicula>().ReverseMap();
        }

        private List<ClienteDTO> MapFamiliaClientes(Familia familia, FamiliaDetalleDTO familiaDetallesDTO)
        {
            var resultado = new List<ClienteDTO>();
            if (familia.Integrantes == null) { return resultado; }

            foreach (var clienteFamilia in familia.Integrantes)
            {
                resultado.Add(new ClienteDTO()
                {
                    Id = clienteFamilia.Id,
                    Nombres = clienteFamilia.Nombres,
                    Apellidos = clienteFamilia.Apellidos,
                    Direccion = clienteFamilia.Direccion,
                    TelefonoFijo = clienteFamilia.TelefonoFijo,
                    Celular = clienteFamilia.Celular,
                });
            }

            return resultado;
        }

        private List<Cliente> MapFamiliaClientes(FamiliaCreacionDTO familiaCreacionDTO,Familia familia)
        {
            var resultado = new List<Cliente>();
            if (familiaCreacionDTO.ClientesIds == null) { return resultado; }

            foreach (var id in familiaCreacionDTO.ClientesIds)
            {
                resultado.Add(new Cliente { Id = id }); ;
            }
            return resultado;
        }

        //private List<GeneroDTO> MapPeliculasGeneros(Pelicula pelicula, PeliculaDetallesDTO peliculaDetallesDTO)
        //{
        //    var resultado = new List<GeneroDTO>();
        //    if (pelicula.PeliculasGeneros == null) { return resultado; }
        //    foreach (var generoPelicula in pelicula.PeliculasGeneros)
        //    {
        //        resultado.Add(new GeneroDTO() { Id = generoPelicula.GeneroId, Nombre = generoPelicula.Genero.Nombre });
        //    }

        //    return resultado;
        //}

        //private List<PeliculasGeneros> MapPeliculasGeneros(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        //{
        //    var resultado = new List<PeliculasGeneros>();
        //    if (peliculaCreacionDTO.GenerosIDs == null) { return resultado; }
        //    foreach (var id in peliculaCreacionDTO.GenerosIDs)
        //    {
        //        resultado.Add(new PeliculasGeneros() { GeneroId = id });
        //    }

        //    return resultado;
        //}

        //private List<PeliculasActores> MapPeliculasActores(PeliculaCreacionDTO peliculaCreacionDTO, Pelicula pelicula)
        //{
        //    var resultado = new List<PeliculasActores>();
        //    if (peliculaCreacionDTO.Actores == null) { return resultado; }

        //    foreach (var actor in peliculaCreacionDTO.Actores)
        //    {
        //        resultado.Add(new PeliculasActores() { ActorId = actor.ActorId, Personaje = actor.Personaje });
        //    }

        //    return resultado;
        //}


    }
}
