using TorneoTenis.Aplicacion.Enums;

namespace TorneoTenis.Dominio
{
    public class Torneo
    {
        private bool _torneoInicializado;

        #region Constructor

        public Torneo()
        {
            Jugadores = new List<Jugador>();
        }
        public Torneo(string nombre, SexoEnum sexo, int cantidadJugadores, List<Jugador> jugadores)
        {
            Nombre = nombre;
            Sexo = sexo;
            CantidadJugadores = cantidadJugadores;
            Jugadores = jugadores ?? new List<Jugador>();
        }

        #endregion

        #region Properties
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; } 
        public SexoEnum Sexo { get; set; }
        public int CantidadJugadores { get; set; }
        public int? GanadorId { get; set; }
        public Jugador? Ganador { get; set; }
        public List<Jugador> Jugadores { get; set; }

       

        #endregion

        #region Public
        public bool InicializarJuego()
        {
            _torneoInicializado = CantidadJugadores > 0 &&
                                  CantidadJugadores % 2 == 0;
            


            return _torneoInicializado;
        }
        public Jugador? ObtenerGanadorTorneo()
        {
            if (_torneoInicializado)
            {
                var listaJugadores = Jugadores;
                List<Jugador> listaGanadores;

                do
                {
                    listaGanadores = new List<Jugador>(); 

                    for (int i = 0; i < listaJugadores.Count; i += 2)
                    {
                        if (i + 1 >= listaJugadores.Count)
                            break;

                        List<Jugador> jugadores = listaJugadores.Skip(i).Take(2).ToList();

                        Jugador? jugadorGanador = ObtenerJugadorGanador(jugadores[0], jugadores[1]);
                        if (jugadorGanador is not null)
                            listaGanadores.Add(jugadorGanador);
                    }

                    listaJugadores = listaGanadores;

                } while (listaJugadores.Count > 1);
                
                return listaJugadores[0];
            }
            return null;
        }

        #endregion

        #region Private
        private Jugador? ObtenerJugadorGanador(Jugador jugador1, Jugador jugador2)
        {
            if (jugador1 == null || jugador2 == null) return null;

            var ganador = jugador1.Competir(jugador2);

            if (ganador is null)
                return ObtenerGanadorFactorSuerte(jugador1, jugador2);

            return ganador;
        }

        private Jugador ObtenerGanadorFactorSuerte(Jugador jugador1, Jugador jugador2)
        {
            Random random = new Random();

            Jugador? ganador = null;
            while (ganador is null)
            {
                var habilidadRandomJugador1 = jugador1.Habilidad + random.Next(0, 100);
                var habilidadRandomJugador2 = jugador2.Habilidad + random.Next(0, 100);

                if (habilidadRandomJugador1 > habilidadRandomJugador2) ganador = jugador1;
                else if (habilidadRandomJugador2 > habilidadRandomJugador1) ganador = jugador2;
            }

            return ganador;
        }

        #endregion
    }

    public class TorneoTenisFemenino : Torneo
    {
        public TorneoTenisFemenino()
        {
            this.Sexo = SexoEnum.Femenino;                 
        }
     
    }
    public class TorneoTenisMasculino : Torneo
    {
        public TorneoTenisMasculino()
        {
            this.Sexo = SexoEnum.Masculino;
        }
      
    }
}
