using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActaCompromisoController : ControllerBase
    {
        private readonly ILogger<ActaCompromisoController> _logger;
        private readonly IsisactaCompromiso _actaCompromisoRepository;

        public ActaCompromisoController(ILogger<ActaCompromisoController> logger, IsisactaCompromiso actaCompromisoRepository)
        {
            _logger = logger;
            _actaCompromisoRepository = actaCompromisoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllActaCompromiso()
        {
            return Ok(await _actaCompromisoRepository.GetAllActaCompromiso());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _actaCompromisoRepository.GetDetails(id));
        }



        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetActaCompromisoDetailsByUser(int users_id)
        {
            return Ok(await _actaCompromisoRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateActaCompromiso([FromBody] ActaCompromiso actaCompromiso)
        {
            if (actaCompromiso == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _actaCompromisoRepository.InsertarActaCompromiso(actaCompromiso);
            return Created("Creado", created);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActaCompromiso(int id, [FromBody] ActaCompromiso actaCompromiso)
        {
            if (actaCompromiso == null)
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

                await _actaCompromisoRepository.ActualizarActaCompromiso(actaCompromiso);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Registrar el error
                _logger.LogError(ex, "Error al actualizar el acta de compromiso");
                return StatusCode(500, "Error interno del servidor");
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarActaCompromiso(int id)
        {
            await _actaCompromisoRepository.EliminarActaCompromiso(id);
            return NoContent();
        }







    }
}
