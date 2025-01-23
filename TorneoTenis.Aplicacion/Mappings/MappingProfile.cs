using AutoMapper;
using TorneoTenis.Aplicacion.DTOs;
using TorneoTenis.Aplicacion.DTOs.Request;
using TorneoTenis.Dominio;

namespace TorneoTenis.Aplicacion.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TorneoTenisMasculinoRequest, TorneoTenisMasculinoDTO>().ReverseMap();
            CreateMap<TorneoTenisFemeninoRequest, TorneoTenisFemeninoDTO>().ReverseMap();

            CreateMap<JugadorDTO, Jugador>().ReverseMap();

            CreateMap<JugadorFemeninoDTO, JugadorFemenino>()               
                 .IncludeBase<JugadorDTO, Jugador>();

            CreateMap<JugadorMasculinoDTO, JugadorMasculino>()          
                 .IncludeBase<JugadorDTO, Jugador>();        
        
            CreateMap<TorneoTenisDTO, Torneo>().ReverseMap();
            CreateMap<TorneoTenisRequest, Torneo>().ReverseMap();

            CreateMap<TorneoTenisFemeninoDTO, TorneoTenisFemenino>()
                .IncludeBase<TorneoTenisDTO, Torneo>();

            CreateMap<TorneoTenisMasculinoDTO, TorneoTenisMasculino>()
                .IncludeBase<TorneoTenisDTO, Torneo>();

            CreateMap<TorneoTenisFemeninoRequest, TorneoTenisFemenino>()
            .IncludeBase<TorneoTenisRequest, Torneo>();

            CreateMap<TorneoTenisMasculinoRequest, TorneoTenisMasculino>()
                .IncludeBase<TorneoTenisRequest, Torneo>();

        }
    }
}
