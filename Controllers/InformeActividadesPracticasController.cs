using Microsoft.AspNetCore.Mvc;
using sisdigitalizacion.Data;
using sisdigitalizacion.Model;

namespace sisdigitalizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeActividadesPracticasController : ControllerBase
    {

        private readonly ILogger<InformeActividadesPracticasController> _logger;
        private readonly IsisInformeActividadesPracticas _informeActividadesPracticasRepository;

        public InformeActividadesPracticasController(ILogger<InformeActividadesPracticasController> logger, IsisInformeActividadesPracticas informeActividadesPracticas)
        {
            _logger = logger;
            _informeActividadesPracticasRepository = informeActividadesPracticas;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllInformeActividadesPracticas()
        {
            return Ok(await _informeActividadesPracticasRepository.GetAllInformeActividadesPracticas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            return Ok(await _informeActividadesPracticasRepository.GetDetails(id));
        }

        [HttpGet("detailsByUser/{users_id}")]
        public async Task<IActionResult> GetInformeFinalDetailsByUser(int users_id)
        {
            return Ok(await _informeActividadesPracticasRepository.GetDetailsByUser(users_id));
        }
    }
}
