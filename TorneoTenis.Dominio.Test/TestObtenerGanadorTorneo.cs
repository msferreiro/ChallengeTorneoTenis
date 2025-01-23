using Moq;
using TorneoTenis.Aplicacion.Enums;
using TorneoTenis.Dominio;

namespace TorneoTestUnitario
{
    [TestClass]
    public sealed class TestObtenerGanadorTorneo
    {
        [TestMethod]
        public void ObtenerGanadorTorneo_DeberiaDevolverGanadorCorrecto()
        {
            // Arrange
            var jugadorMock1 = new Mock<JugadorMasculino>();
            jugadorMock1.Setup(j => j.Nombre).Returns("Juan Perez");
            jugadorMock1.Setup(j => j.Habilidad).Returns(10);
            jugadorMock1.Setup(j => j.Sexo).Returns(SexoEnum.Masculino);
            jugadorMock1.Setup(j => j.Fuerza).Returns(10);
            jugadorMock1.Setup(j => j.VelocidadDesplazamiento).Returns(10);

            var jugadorMock2 = new Mock<JugadorMasculino>();
            jugadorMock2.Setup(j => j.Nombre).Returns("Jorge Gomez");
            jugadorMock2.Setup(j => j.Habilidad).Returns(20);
            jugadorMock2.Setup(j => j.Sexo).Returns(SexoEnum.Masculino);
            jugadorMock2.Setup(j => j.Fuerza).Returns(20);
            jugadorMock2.Setup(j => j.VelocidadDesplazamiento).Returns(20);

            var jugadorMock3 = new Mock<JugadorMasculino>();
            jugadorMock3.Setup(j => j.Nombre).Returns("Raul Ferreiro");
            jugadorMock3.Setup(j => j.Habilidad).Returns(30);
            jugadorMock3.Setup(j => j.Sexo).Returns(SexoEnum.Masculino);
            jugadorMock3.Setup(j => j.Fuerza).Returns(30);
            jugadorMock3.Setup(j => j.VelocidadDesplazamiento).Returns(30);

            var jugadorMock4 = new Mock<JugadorMasculino>();
            jugadorMock4.Setup(j => j.Nombre).Returns("Ernesto Petrarca");
            jugadorMock4.Setup(j => j.Habilidad).Returns(60);
            jugadorMock4.Setup(j => j.Sexo).Returns(SexoEnum.Masculino);
            jugadorMock4.Setup(j => j.Fuerza).Returns(60);
            jugadorMock4.Setup(j => j.VelocidadDesplazamiento).Returns(60);


            // Simulamos el comportamiento de competir
            jugadorMock1.Setup(j => j.Competir(jugadorMock2.Object)).Returns(jugadorMock2.Object);
            jugadorMock3.Setup(j => j.Competir(jugadorMock4.Object)).Returns(jugadorMock4.Object);
            jugadorMock2.Setup(j => j.Competir(jugadorMock4.Object)).Returns(jugadorMock4.Object);
                       
            var torneo = new TorneoTenisMasculino
            {
                Nombre = "Torneo Masculino 2025",
                Fecha = DateTime.Now,
                CantidadJugadores = 4,
                Jugadores = new List<Jugador> { jugadorMock1.Object, jugadorMock2.Object, jugadorMock3.Object, jugadorMock4.Object }
            };

            // Inicializamos el juego
            torneo.InicializarJuego();

            var ganador = torneo.ObtenerGanadorTorneo();

            // Assert
            Assert.IsNotNull(ganador);
            Assert.AreEqual(jugadorMock4.Object, ganador); 
        }

    }
}
