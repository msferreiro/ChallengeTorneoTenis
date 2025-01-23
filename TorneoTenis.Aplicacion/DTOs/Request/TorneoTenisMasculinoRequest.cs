using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoTenis.Aplicacion.DTOs.Request
{
    public class TorneoTenisMasculinoRequest : TorneoTenisRequest
    {
        public List<JugadorMasculinoDTO> Jugadores { get; set; }
    }
}
