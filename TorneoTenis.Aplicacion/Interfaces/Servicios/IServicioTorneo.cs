using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoTenis.Aplicacion.DTOs;
using TorneoTenis.Aplicacion.DTOs.Request;

namespace TorneoTenis.Aplicacion.Interfaces.Servicios
{
    public interface IServicioTorneo
    {
        public Task<JugadorDTO> CrerTorneo(TorneoTenisDTO? torneo);

        public Task<List<TorneoTenisDTO>> ObtenerTorneosPorFecha(DateTime? fecha);
        public Task<List<TorneoTenisDTO>> ObtenerTorneosPorNombre(string nombre);
        public Task<List<TorneoTenisDTO>> ObtenerTorneosFemeninos();
        public Task<List<TorneoTenisDTO>> ObtenerTorneosMasculinos();
    }
}
