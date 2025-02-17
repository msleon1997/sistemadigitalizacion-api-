using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;
using Microsoft.Extensions.Logging;

namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CronoActividadesController : ControllerBase

    {

        private readonly ILogger<CronoActividadesController> _logger;
        private readonly IsiscronoActividades _cronoActividadesRepository;

        public CronoActividadesController(ILogger<CronoActividadesController> logger, IsiscronoActividades cronoActividadesRepository)
        {
            _logger = logger;
            _cronoActividadesRepository = cronoActividadesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCronoActividades()
        {
            return Ok(await _cronoActividadesRepository.GetAllCronoActividades());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _cronoActividadesRepository.GetDetails(id));
        }



        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetCronoActividadesDetailsByUser(int users_id)
        {
            return Ok(await _cronoActividadesRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateCronoActividades([FromBody] CronoActividades cronoActividades)
        {
            if (cronoActividades == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _cronoActividadesRepository.InsertarCronoActividades(cronoActividades);
            return Created("Creado", created);


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCronoActividades(int id, [FromBody] CronoActividades cronoActividades)
        {
            if (cronoActividades == null)
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

                await _cronoActividadesRepository.ActualizaCronoActividades(cronoActividades);
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
        public async Task<IActionResult> EliminarCronoActividades(int id)
        {
            await _cronoActividadesRepository.EliminarCronoActividades(id);
            return NoContent();
        }
    }
}
