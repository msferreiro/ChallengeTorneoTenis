using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorneoTenis.Aplicacion.DTOs.Request
{
    public class TorneoTenisFemeninoRequest : TorneoTenisRequest
    {
        public List<JugadorFemeninoDTO> Jugadores { get; set; }
    }
}
