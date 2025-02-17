using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;
using Microsoft.Extensions.Logging;

namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanificacionController : ControllerBase
    {
        private readonly ILogger<PlanificacionController> _logger;
        private readonly IsisdigitalizacionRepository _planificacionRepository;

        public PlanificacionController(ILogger<PlanificacionController> logger,IsisdigitalizacionRepository planificacionRepository) {
            _logger = logger;
            _planificacionRepository = planificacionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlanificaciones() {
            return Ok(await _planificacionRepository.GetAllPlanificaciones());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlanificacionDetails(int id) {
            return Ok(await _planificacionRepository.GetDetails(id));
        }

        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetPlanificacionDetailsByUser(int users_id)
        {
            return Ok(await _planificacionRepository.GetDetailsByUser(users_id));
        }

        [HttpGet("getDetailsWithMatriculacion/{id}")]
        public async Task<IActionResult> GetDetailsWithMatriculacion(int id)
        {
            var planificacion = await _planificacionRepository.GetDetailsWithMatriculacion(id);
            if (planificacion == null)
            {
                return NotFound("No se encontraron detalles de planificación.");
            }
            return Ok(planificacion);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePlanificacion([FromBody] Planificacion planificacion) {
            if (planificacion == null){
                return BadRequest();
            }
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            var created = await _planificacionRepository.InsertarPlanificacion(planificacion);
            return Created("Creado", created);
                 
           
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlanificacion(int id, [FromBody] Planificacion planificacion)
        {
            if (planificacion == null)
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
                
                await _planificacionRepository.ActualizarPlanificacion(planificacion);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Registrar el error
                _logger.LogError(ex, "Error al actualizar la planificación");
                return StatusCode(500, "Error interno del servidor");
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarPlanificacion(int id)
        {
            await _planificacionRepository.EliminarPlanificacion(id);
            return NoContent();
        }


    }
}
