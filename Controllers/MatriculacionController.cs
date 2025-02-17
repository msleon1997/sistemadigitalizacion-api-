using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MatriculacionController : ControllerBase
    {

        private readonly ILogger<MatriculacionController> _logger;
        private readonly IsisMatriculacionRepository _matriculaculacionRepository;


        public MatriculacionController(ILogger<MatriculacionController> logger, IsisMatriculacionRepository matriculacion)
        {
            _logger = logger;
            _matriculaculacionRepository = matriculacion;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMatriculacion()
        {
            return Ok(await _matriculaculacionRepository.GetAllMatriculacion());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatriculacionDetails(int id)
        {
            return Ok(await _matriculaculacionRepository.GetDetails(id));
        }

        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetMatriculacionDetailsByUser(int users_id)
        {
            return Ok(await _matriculaculacionRepository.GetDetailsByUser(users_id));
        }


        [HttpPost]
        public async Task<IActionResult> CreateMatriculacion([FromBody] Matriculacion matriculacion)
        {
            if (matriculacion == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var created = await _matriculaculacionRepository.InsertarMatriculacion(matriculacion);
            return Created("Creado", created);


        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMatriculacion(int id, [FromBody] Matriculacion matriculacion)
        {
            if (matriculacion == null)
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

                await _matriculaculacionRepository.ActualizarMatriculacion(matriculacion);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Registrar el error
                _logger.LogError(ex, "Error al actualizar la matriculacion");
                return StatusCode(500, "Error interno del servidor");
            }


        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarMatriculacion(int id)
        {
            await _matriculaculacionRepository.EliminarMatriculacion(id);
            return NoContent();
        }

    }
}
