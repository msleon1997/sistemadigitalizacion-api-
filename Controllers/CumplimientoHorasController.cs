using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CumplimientoHorasController : ControllerBase
    {
        private readonly ILogger<CumplimientoHorasController> _logger;
        private readonly IsisCumplimientoHorasRepository _cumplimientoHorasRepository;

        public CumplimientoHorasController(ILogger<CumplimientoHorasController> logger, IsisCumplimientoHorasRepository cumplimientoHoras)
        {
            _logger = logger;
            _cumplimientoHorasRepository = cumplimientoHoras;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCumplimientoHoras()
        {
            return Ok(await _cumplimientoHorasRepository.GetAllCumplimientoHoras());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _cumplimientoHorasRepository.GetDetails(id));
        }



        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetCumplimientoHorasDetailsByUser(int users_id)
        {
            return Ok(await _cumplimientoHorasRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateCumplimientoHoras([FromBody] CumplimientoHoras cumplimientoHoras)
        {
            if (cumplimientoHoras == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _cumplimientoHorasRepository.InsertarCumplimientoHoras(cumplimientoHoras);
            return Created("Creado", created);


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCumplimientoHoras(int id, [FromBody] CumplimientoHoras cumplimientoHoras)
        {
            if (cumplimientoHoras == null)
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

                await _cumplimientoHorasRepository.ActualizarCumplimientoHoras(cumplimientoHoras);
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
        public async Task<IActionResult> EliminarCumplimientoHoras(int id)
        {
            await _cumplimientoHorasRepository.EliminarCumplimientoHoras(id);
            return NoContent();
        }
    }
}
