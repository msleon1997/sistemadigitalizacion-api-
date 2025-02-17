using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;
using Microsoft.Extensions.Logging;

namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class oficioDireccionCarreraController : ControllerBase
    {
        private readonly ILogger<oficioDireccionCarreraController> _logger;
        private readonly IsisoficioDireccionCarreraRepository _oficioDireccionCarreraRepository;

        public oficioDireccionCarreraController(ILogger<oficioDireccionCarreraController> logger, IsisoficioDireccionCarreraRepository oficioDireccionCarreraRepository)
        {
            _logger = logger;
            _oficioDireccionCarreraRepository = oficioDireccionCarreraRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGetAllOficioDireccionCarrera()
        {
            return Ok(await _oficioDireccionCarreraRepository.GetAllOficioDireccionCarrera());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOficioDireccionCarreraDetails(int id)
        {
            return Ok(await _oficioDireccionCarreraRepository.GetDetails(id));
        }

        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetOficioDireccionCarreraDetailsByUser(int users_id)
        {
            return Ok(await _oficioDireccionCarreraRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateOficioDireccionCarrera([FromBody] OficioDireccionCarrera oficioDireccionCarrera)
        {
            if (oficioDireccionCarrera == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _oficioDireccionCarreraRepository.InsertarOficioDireccionCarrera(oficioDireccionCarrera);
            return Created("Creado", created);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOficioDireccionCarrera(int id, [FromBody] OficioDireccionCarrera oficioDireccionCarrera)
        {
            if (oficioDireccionCarrera == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //await _planificacionRepository.ActualizarPlanificacion(planificacion);
            //return NoContent();
            try
            {

                await _oficioDireccionCarreraRepository.ActualizarOficioDireccionCarrera(oficioDireccionCarrera);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Registrar el error
                _logger.LogError(ex, "Error al actualizar el Oficio Dirección de Carrera");
                return StatusCode(500, "Error interno del servidor");
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarOficioDireccionCarrera(int id)
        {
            await _oficioDireccionCarreraRepository.EliminarOficioDireccionCarrera(id);
            return NoContent();
        }










    }












}