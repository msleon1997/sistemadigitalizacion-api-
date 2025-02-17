using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;
using System.Text.Json;

namespace sisdigitalizacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InformeFinalController :ControllerBase
    {
        private readonly ILogger<InformeFinalController> _logger;
        private readonly IsisInformeFinal _informeFinalRepository;

        public InformeFinalController(ILogger<InformeFinalController> logger, IsisInformeFinal informeFinal)
        {
            _logger = logger;
            _informeFinalRepository = informeFinal;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInformeFinal()
        {
            return Ok(await _informeFinalRepository.GetAllInformeFinal());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _informeFinalRepository.GetDetails(id));
        }

        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetInformeFinalDetailsByUser(int users_id)
        {
            return Ok(await _informeFinalRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateInformeFinal([FromBody] InformeFinal informeFinal)
        {
            if (informeFinal == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _informeFinalRepository.InsertarInformeFinal(informeFinal);
            return Created("Creado", created);


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInformeFinal(int id, [FromBody] InformeFinal informeFinal)
        {
            if (informeFinal == null)
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

                await _informeFinalRepository.ActualizarInformeFinal(informeFinal);
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
        public async Task<IActionResult> EliminarInformeFinal(int id)
        {
            await _informeFinalRepository.EliminarInformeFinal(id);
            return NoContent();
        }

    }


}
