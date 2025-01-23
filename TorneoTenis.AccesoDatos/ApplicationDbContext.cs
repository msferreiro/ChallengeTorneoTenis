using Microsoft.EntityFrameworkCore;
using TorneoTenis.Aplicacion.Enums;
using TorneoTenis.Dominio;

namespace TorneoTenis.AccesoDatos
{
    public class ApplicationDbContext : DbContext
    {

        public virtual DbSet<Jugador> Jugadores { get; set; }
        public virtual DbSet<Torneo> Torneos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region Jugador

            modelBuilder.Entity<Jugador>().HasKey(x => x.Id);

            modelBuilder.Entity<Jugador>()
             .ToTable("Jugador")
             .HasDiscriminator<SexoEnum>("Sexo") // Discriminador
             .HasValue<Jugador>(SexoEnum.Otro)
             .HasValue<JugadorFemenino>(SexoEnum.Femenino)
             .HasValue<JugadorMasculino>(SexoEnum.Masculino);

            modelBuilder.Entity<Jugador>().Property(j => j.Nombre).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Jugador>().Property(j => j.Sexo).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Jugador>().Property(j => j.Habilidad).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Jugador>().Property(j => j.TorneoId).HasColumnType("int").IsRequired();

            modelBuilder.Entity<JugadorFemenino>().Property(j => j.TiempoReaccion).HasColumnType("int").IsRequired();
            modelBuilder.Entity<JugadorMasculino>().Property(j => j.Fuerza).HasColumnType("int").IsRequired();
            modelBuilder.Entity<JugadorMasculino>().Property(j => j.VelocidadDesplazamiento).HasColumnType("int").IsRequired();

            #endregion

            #region Torneo

            modelBuilder.Entity<Torneo>().HasKey(x => x.Id);
            modelBuilder.Entity<Torneo>().ToTable("Torneo");
            modelBuilder.Entity<Torneo>().Property(j => j.Nombre).HasColumnType("varchar(200)").IsRequired();
            modelBuilder.Entity<Torneo>().Property(j => j.Fecha).HasColumnType("datetime").IsRequired();
            modelBuilder.Entity<Torneo>().Property(j => j.CantidadJugadores).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Torneo>().Property(j => j.Sexo).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Torneo>().HasMany(x=>x.Jugadores).WithOne(x=>x.Torneo).HasForeignKey(x=>x.TorneoId);
            modelBuilder.Entity<Torneo>().HasOne(t => t.Ganador).WithMany(x=>x.Torneos).HasForeignKey(t => t.GanadorId); 
        }
        #endregion


    }
}
