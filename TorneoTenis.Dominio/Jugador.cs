using System.ComponentModel.DataAnnotations;
using TorneoTenis.Aplicacion.Enums;
using TorneoTenis.Dominio.Interfaces;

namespace TorneoTenis.Dominio
{
    public class Jugador // : IJugador
    {
        public int Id { get; set; }
        public virtual string Nombre { get; set; }

        [Range(0, 100, ErrorMessage = "El valor de <Habilidad> debe estar entre 0 y 100.")]
        public virtual int Habilidad { get; set; }
        public virtual SexoEnum Sexo { get; set; }
        public virtual int TorneoId { get; set; }
        public virtual Torneo? Torneo { get; set; }
        public virtual List<Torneo> Torneos { get; set; }

        public Jugador()
        {
            Nombre = string.Empty;
            Habilidad = 0;
            Sexo = SexoEnum.Masculino;
        }

        public Jugador(string nombre, int habilidad)
        {
            Nombre = nombre;
            Habilidad = habilidad;
        }

        public virtual Jugador? Competir(Jugador jugador) 
        {
            return null;
        }       
    }
}
