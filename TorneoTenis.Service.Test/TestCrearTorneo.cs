using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TorneoTenis.AccesoDatos;
using TorneoTenis.Aplicacion.DTOs;
using TorneoTenis.Aplicacion.DTOs.Request;
using TorneoTenis.Aplicacion.Mappings;
using TorneoTenis.Servicios;

namespace TorneoTenis.Service.Test
{
    [TestClass]
    public class TorneoServiceTests
    {
        private ServicioTorneo _torneoService;
        private DbContextOptions<ApplicationDbContext> _dbContextOptions;
        private ApplicationDbContext _context;
        private IMapper _mapper;
     
        [TestInitialize]
        public void Setup()
        {
            // Configuramos base de datos en memoria
            _dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Torneo")
                .Options;

            _context = new ApplicationDbContext(_dbContextOptions);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>(); 
            });

            _mapper = config.CreateMapper();

            _torneoService = new ServicioTorneo(_mapper, _context);
        }

        [TestMethod]
        public async Task CrearTorneo_ValidTorneoMasculino_ShouldReturnGanador()
        {
            var torneoMasculinoDTO = new TorneoTenisMasculinoDTO
            {
                Nombre = "Torneo Masculino",
                CantidadJugadores = 4,
                Fecha = DateTime.Now,
                Jugadores = new List<JugadorMasculinoDTO>
            {
                new JugadorMasculinoDTO { Nombre = "Jugador 1", Habilidad = 8, Fuerza = 10, VelocidadDesplazamiento = 10 },
                new JugadorMasculinoDTO { Nombre = "Jugador 2", Habilidad = 9, Fuerza = 10, VelocidadDesplazamiento = 200 },
                new JugadorMasculinoDTO { Nombre = "Jugador 3", Habilidad = 10, Fuerza = 10, VelocidadDesplazamiento = 30 },
                new JugadorMasculinoDTO { Nombre = "Jugador 4", Habilidad = 11, Fuerza = 10, VelocidadDesplazamiento = 40 },
            }
            };
                       
         
            var ganador = await _torneoService.CrerTorneo(torneoMasculinoDTO);

            Assert.IsNotNull(ganador, "El ganador no debe ser nulo.");
            Assert.AreEqual("Jugador 2", ganador.Nombre, "El ganador esperado es Jugador 4.");
            Assert.AreEqual(9, ganador.Habilidad, "La habilidad del ganador debe ser 9.");
        }

        [TestMethod]
        public async Task CrearTorneo_NullTorneo_ShouldReturnNull()
        {            
            var resultado = await _torneoService.CrerTorneo(null);

            Assert.IsNull(resultado, "El resultado debe ser nulo para un torneo nulo.");
        }
    }

}
