using TorneoTenis.Aplicacion.Enums;

namespace TorneoTenis.Aplicacion.DTOs
{
    public class TorneoTenisDTO
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public SexoEnum Sexo { get; set; }
        public int CantidadJugadores { get; set; }
        public string Ganador { get; set; }
        public List<JugadorDTO> Jugadores { get; set; }

    }
}
