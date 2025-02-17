using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeTutoriasController : ControllerBase
    {

        private readonly ILogger<InformeTutoriasController> _logger;
        private readonly IsisInformeTutorias _informeTutoriasRepository;

        public InformeTutoriasController(ILogger<InformeTutoriasController> logger, IsisInformeTutorias informeTutorias)
        {
            _logger = logger;
            _informeTutoriasRepository = informeTutorias;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInformeTutorias()
        {
            return Ok(await _informeTutoriasRepository.GetAllInformeTutorias());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _informeTutoriasRepository.GetDetails(id));
        }

        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetInformeTutoriasDetailsByUser(int users_id)
        {
            return Ok(await _informeTutoriasRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateInformeTutorias([FromBody] InformeTutorias informeTutorias)
        {
            if (informeTutorias == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _informeTutoriasRepository.InsertarInformeTutorias(informeTutorias);
            return Created("Creado", created);


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInformeTutorias(int id, [FromBody] InformeTutorias informeTutorias)
        {
            if (informeTutorias == null)
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

                await _informeTutoriasRepository.ActualizarInformeTutorias(informeTutorias);
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
        public async Task<IActionResult> EliminarInformeTutorias(int id)
        {
            await _informeTutoriasRepository.EliminarInformeTutorias(id);
            return NoContent();
        }


    }
}
