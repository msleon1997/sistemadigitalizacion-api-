using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;
namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluacionFinalCertificadoController: ControllerBase
    {
        private readonly ILogger<EvaluacionFinalCertificadoController> _logger;
        private readonly IsisEvaluacionFinalCertificadoRepository _evaluacionFinalCertificadoRepository;


        public EvaluacionFinalCertificadoController(ILogger<EvaluacionFinalCertificadoController> logger, IsisEvaluacionFinalCertificadoRepository evaluacionFinalCertificado)
        {
            _logger = logger;
            _evaluacionFinalCertificadoRepository = evaluacionFinalCertificado;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluacionFinalCertificado()
        {
            return Ok(await _evaluacionFinalCertificadoRepository.GetAllEvaluacionFinalCertificado());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _evaluacionFinalCertificadoRepository.GetDetails(id));
        }

        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetEvaluacionFinalCertificadoDetailsByUser(int users_id)
        {
            return Ok(await _evaluacionFinalCertificadoRepository.GetDetailsByUser(users_id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvaluacionFinalCertificado([FromBody] EvaluacionFinalCertificado evaluacionFinalCertificado)
        {
            if (evaluacionFinalCertificado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _evaluacionFinalCertificadoRepository.InsertarEvaluacionFinalCertificado(evaluacionFinalCertificado);
            return Created("Creado", created);



        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvaluacionFinalCertificado(int id, [FromBody] EvaluacionFinalCertificado evaluacionFinalCertificado)
        {
            if (evaluacionFinalCertificado == null)
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

                await _evaluacionFinalCertificadoRepository.ActualizarEvaluacionFinalCertificado(evaluacionFinalCertificado);
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
            await _evaluacionFinalCertificadoRepository.EliminarEvaluacionFinalCertificado(id);
            return NoContent();
        }



    }

}
