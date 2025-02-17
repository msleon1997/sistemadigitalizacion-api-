using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;
using Microsoft.Extensions.Logging;

namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesPracticasController : ControllerBase
    {
        private readonly ILogger<ActividadesPracticasController> _logger;
        private readonly IsisactividadesPracticas _actividadesPracticasRepository;

        public ActividadesPracticasController(ILogger<ActividadesPracticasController> logger, IsisactividadesPracticas actividadesPracticasRepository)
        {
            _logger = logger;
            _actividadesPracticasRepository = actividadesPracticasRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActividadesPracticas()
        {
            return Ok(await _actividadesPracticasRepository.GetAllActividadesPracticas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _actividadesPracticasRepository.GetDetails(id));
        }



        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetActividadesPracticasDetailsByUser(int users_id)
        {
            return Ok(await _actividadesPracticasRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateActividadesPracticas([FromBody] ActividadesPracticas actividadesPracticas)
        {
            if (actividadesPracticas == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _actividadesPracticasRepository.InsertarActividadesPracticas(actividadesPracticas);
            return Created("Creado", created);


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActividadesPracticas(int id, [FromBody] ActividadesPracticas actividadesPracticas)
        {
            if (actividadesPracticas == null)
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

                await _actividadesPracticasRepository.ActualizarActividadesPracticas(actividadesPracticas);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Registrar el error
                _logger.LogError(ex, "Error al actualizar el registro de sus practicas");
                return StatusCode(500, "Error interno del servidor");
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarActividadesPracticas(int id)
        {
            await _actividadesPracticasRepository.EliminarActividadesPracticas(id);
            return NoContent();
        }



    }
}
