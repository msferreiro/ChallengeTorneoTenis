using TorneoTenis.Aplicacion.Enums;

namespace TorneoTenis.Aplicacion.DTOs
{
    public class TorneoTenisMasculinoDTO : TorneoTenisDTO
    {
         public List<JugadorMasculinoDTO> Jugadores { get; set; }
    }
}
