using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionPracticaController : ControllerBase
    {
        private readonly ILogger<EvaluacionPracticaController> _logger;
        private readonly IsisEvaluacionPracticaRepository _evaluacionPracticaRepository;

        public EvaluacionPracticaController(ILogger<EvaluacionPracticaController> logger, IsisEvaluacionPracticaRepository evaluacionPractica)
        {
            _logger = logger;
            _evaluacionPracticaRepository = evaluacionPractica;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluacionPractica()
        {
            return Ok(await _evaluacionPracticaRepository.GetAllEvaluacionPractica());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _evaluacionPracticaRepository.GetDetails(id));
        }

        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetEvaluacionPracticaDetailsByUser(int users_id)
        {
            return Ok(await _evaluacionPracticaRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateEvaluacionPractica([FromBody] EvaluacionPractica evaluacionPractica)
        {
            if (evaluacionPractica == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _evaluacionPracticaRepository.InsertarEvaluacionPractica(evaluacionPractica);
            return Created("Creado", created);


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvaluacionPractica(int id, [FromBody] EvaluacionPractica evaluacionPractica)
        {
            if (evaluacionPractica == null)
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

                await _evaluacionPracticaRepository.ActualizarEvaluacionPractica(evaluacionPractica);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Registrar el error
                _logger.LogError(ex, "Error al actualizar el registro");
                return StatusCode(500, "Error interno del servidor");
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarEvaluacionPractica(int id)
        {
            await _evaluacionPracticaRepository.EliminarEvaluacionPractica(id);
            return NoContent();
        }

    }
}
