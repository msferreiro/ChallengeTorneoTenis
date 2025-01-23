using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorneoTenis.Aplicacion.Enums;

namespace TorneoTenis.Dominio
{
    public class JugadorFemenino : Jugador
    {
        public JugadorFemenino(string nombre, int habilidad, int tiempoReaccion)
                        : base(nombre, habilidad)
        {
            Sexo = SexoEnum.Femenino;
            TiempoReaccion = tiempoReaccion;
        }
        public virtual int TiempoReaccion { get; set; }

        public override Jugador? Competir(Jugador jugador)
        {
            var jugadorACompetir = (JugadorFemenino)jugador;
            var resultJugador = this.Habilidad + this.TiempoReaccion;
            var resultJugadorACompetir = jugadorACompetir.Habilidad + jugadorACompetir.TiempoReaccion;

            if (resultJugador > resultJugadorACompetir) return this;
            else if (resultJugador < resultJugadorACompetir) return jugadorACompetir;
            else return null;
        }
    }
}
