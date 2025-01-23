using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TorneoTenis.Aplicacion.DTOs;
using TorneoTenis.Aplicacion.DTOs.Request;
using TorneoTenis.Aplicacion.Interfaces.Servicios;

namespace TorneoTenis.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneoController : ControllerBase
    {
        private readonly ILogger<TorneoController> _logger;
        private readonly IMapper _mapper;
        private readonly IServicioTorneo _servicioTorneo;

        public TorneoController(ILogger<TorneoController> logger, IServicioTorneo servicioTorneo, IMapper mapper)
        {
            _logger = logger;
            _servicioTorneo = servicioTorneo;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("PorFecha")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTorneoPorFecha(DateTime? fecha)
        {
            if (fecha is null) return BadRequest("Debe indicar una fecha.");
           
            var torneos = await _servicioTorneo.ObtenerTorneosPorFecha(fecha);

            if (torneos is not null)
                return Ok(torneos);
            else return StatusCode(500, "Se produjo un error inesperado.");
        }

        [HttpGet]
        [Route("PorNombre")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTorneoPorFecha(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) return BadRequest("Debe indicar un nombre.");

            var torneos = await _servicioTorneo.ObtenerTorneosPorNombre(nombre);

            if (torneos is not null)
                return Ok(torneos);
            else return StatusCode(500, "Se produjo un error inesperado.");
        }

        [HttpGet]
        [Route("TorneosFemeninos")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTorneosFemeninos()
        {
             var torneos = await _servicioTorneo.ObtenerTorneosFemeninos();

            if (torneos is not null)
                return Ok(torneos);
            else return StatusCode(500, "Se produjo un error inesperado.");
        }

        [HttpGet]
        [Route("TorneosMasculinos")]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTorneosMasculinos()
        {
            var torneos = await _servicioTorneo.ObtenerTorneosMasculinos();

            if (torneos is not null)
                return Ok(torneos);
            else return StatusCode(500, "Se produjo un error inesperado.");
        }

        [HttpPost]
        [Route("Femenino")]
        [AllowAnonymous]
        public async Task<IActionResult> CrearTorneoFeminino([FromBody] TorneoTenisFemeninoRequest torneo)
        {
            if (torneo == null) return BadRequest("Debe enviar los datos del torneo.");
            if (torneo.Jugadores is null) return BadRequest("Debe enviar datos de los torneo.");

            var torneoDTO = _mapper.Map<TorneoTenisFemeninoDTO>(torneo);
            torneoDTO.Sexo = Aplicacion.Enums.SexoEnum.Femenino;
            var ganadorTorneo = await _servicioTorneo.CrerTorneo(torneoDTO);

            if (ganadorTorneo is not null)
                return Ok (ganadorTorneo);
            else return StatusCode(500, "Se produjo un error inesperado.");
        }

        [HttpPost]
        [Route("Masculino")]
        [AllowAnonymous]
        public async Task<IActionResult> CrearTorneoMasculino([FromBody] TorneoTenisMasculinoRequest torneo)
        {
            if (torneo == null) return BadRequest("Debe enviar los datos del torneo.");
            if (torneo.Jugadores is null) return BadRequest("Debe enviar datos de los torneo.");

            var torneoDTO = _mapper.Map<TorneoTenisMasculinoDTO>(torneo);
            torneoDTO.Sexo = Aplicacion.Enums.SexoEnum.Masculino;
            var ganadorTorneo = await _servicioTorneo.CrerTorneo(torneoDTO);

            if (ganadorTorneo is not null)
                return Ok(ganadorTorneo);
            else return StatusCode(500, "Se produjo un error inesperado.");
        }


    }
}