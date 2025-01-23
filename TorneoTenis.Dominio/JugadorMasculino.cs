using TorneoTenis.Aplicacion.Enums;

namespace TorneoTenis.Dominio
{
    public class JugadorMasculino : Jugador
    {
        public JugadorMasculino() 
        {
        }
        public JugadorMasculino(string nombre, int habilidad, int fuerza, int velocidadDesplazamiento)
                         : base(nombre, habilidad)
        {
            Sexo = SexoEnum.Masculino;
            Fuerza = fuerza;
            VelocidadDesplazamiento = velocidadDesplazamiento;
        }

        public virtual int Fuerza { get; set; }
        public virtual int VelocidadDesplazamiento { get; set; }

        public override Jugador? Competir(Jugador jugador)
        {
            JugadorMasculino jugadorACompetir = (JugadorMasculino)jugador;
            var resultJugador = this.Habilidad + this.Fuerza + this.VelocidadDesplazamiento;
            var resultJugadorACompetir = jugadorACompetir.Habilidad + jugadorACompetir.Fuerza + jugadorACompetir.VelocidadDesplazamiento;

            if (resultJugador > resultJugadorACompetir) return this;
            else if (resultJugador < resultJugadorACompetir) return jugadorACompetir;
            else return null;
        }
    }
}
