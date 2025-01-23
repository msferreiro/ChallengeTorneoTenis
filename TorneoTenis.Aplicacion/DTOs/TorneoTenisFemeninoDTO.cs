using TorneoTenis.Aplicacion.Enums;

namespace TorneoTenis.Aplicacion.DTOs
{
    public class TorneoTenisFemeninoDTO : TorneoTenisDTO
    {
      
        public List<JugadorFemeninoDTO> Jugadores { get; set; }
    }
}
