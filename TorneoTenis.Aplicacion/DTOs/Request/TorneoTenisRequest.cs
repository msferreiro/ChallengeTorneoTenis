using System.Text.Json.Serialization;
using TorneoTenis.Aplicacion.Enums;

namespace TorneoTenis.Aplicacion.DTOs.Request
{
    public class TorneoTenisRequest
    {
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }

        [JsonIgnore]
        public SexoEnum Sexo { get; set; }
        public int CantidadJugadores { get; set; }      
    }
}
