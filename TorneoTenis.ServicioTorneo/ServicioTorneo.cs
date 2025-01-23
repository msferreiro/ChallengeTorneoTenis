using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TorneoTenis.AccesoDatos;
using TorneoTenis.Aplicacion.DTOs;
using TorneoTenis.Aplicacion.DTOs.Request;
using TorneoTenis.Aplicacion.Interfaces.Servicios;
using TorneoTenis.Dominio;

namespace TorneoTenis.Servicios
{
    public class ServicioTorneo : IServicioTorneo 
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        #region Constructor
        public ServicioTorneo(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        #endregion

        #region Public
        public async Task<JugadorDTO> CrerTorneo(TorneoTenisDTO? torneo)
        {
            if (torneo is null) return null;

            //var torneoDTO = _mapper.Map<TorneoTenisDTO>(torneo);    

            Torneo? torneoModel = torneo switch
            {
                TorneoTenisFemeninoDTO femeninoDto => _mapper.Map<TorneoTenisFemenino>(femeninoDto),
                TorneoTenisMasculinoDTO masculinoDto => _mapper.Map<TorneoTenisMasculino>(masculinoDto),
                _ => null
            };

            if (torneoModel is null)
                throw new InvalidOperationException("El tipo de torneo no es válido.");

            if (torneoModel.InicializarJuego())
            {
                var ganadorTorneo = torneoModel.ObtenerGanadorTorneo();

                _context.Torneos.Add(torneoModel);
                var result = await _context.SaveChangesAsync();
                if (result <= 0) return null;

                torneoModel.Ganador = ganadorTorneo;
                _context.Torneos.Update(torneoModel);
                result = await _context.SaveChangesAsync();
                if (result <= 0) return null;
           

                return _mapper.Map<JugadorDTO>(ganadorTorneo);
            }

            return null;
        }

        public async Task<List<TorneoTenisDTO>> ObtenerTorneosPorFecha(DateTime? fecha)
        { 
            if (fecha is null) return null;

            var torneos = await _context.Torneos.Include(x=>x.Ganador).Where(x=>x.Fecha.Date == fecha).ToListAsync();
            var result = _mapper.Map<List<TorneoTenisDTO>>(torneos);

            foreach (var torneo in result)
            {
                var ganador = torneos.First(x => x.Nombre == torneo.Nombre).Ganador;
                torneo.Ganador = ganador is not null ? ganador.Nombre : string.Empty;
            }

            return result;
        }

        public async Task<List<TorneoTenisDTO>> ObtenerTorneosPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) return null;

            var torneos = await _context.Torneos.Include(x=>x.Ganador).Where(x => x.Nombre.Contains(nombre)).ToListAsync();
            var result = _mapper.Map<List<TorneoTenisDTO>>(torneos);

            foreach (var torneo in result)
            {
                var ganador = torneos.First(x => x.Nombre == torneo.Nombre).Ganador;
                torneo.Ganador = ganador is not null ? ganador.Nombre : string.Empty;
            }

            return result;
        }

        public async Task<List<TorneoTenisDTO>> ObtenerTorneosFemeninos()
        {
            var torneos = await _context.Torneos.Where(x => x.Sexo == Aplicacion.Enums.SexoEnum.Femenino).ToListAsync();
            return _mapper.Map<List<TorneoTenisDTO>>(torneos);
        }

        public async Task<List<TorneoTenisDTO>> ObtenerTorneosMasculinos()
        {
            var torneos = await _context.Torneos.Where(x => x.Sexo == Aplicacion.Enums.SexoEnum.Masculino).ToListAsync();
            return _mapper.Map<List<TorneoTenisDTO>>(torneos);
        }

        #endregion
    }
}
