using Microsoft.AspNetCore.Mvc;
using project_renault.Models;
using project_renault.Services;

namespace project_renault.Controllers
{
    [Route("/risk")]
    [ApiController]
    public class RiskController : Controller
    {
        RiskService riskService;

        public RiskController(RiskService riskService)
        {
            this.riskService = riskService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllRisk()
        {
            var response = await riskService.GetAllRisk();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdRisk(int? id)
        {
            var response = await riskService.GetByIdRisk(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddRisk(RiskModel risk)
        {
            await riskService.AddRisk(risk);
            return Ok(risk);
        }

        [HttpPut]
        public async Task<ActionResult<RiskModel>> PutRisk(RiskModel risk)
        {
            return Ok(riskService.PutRisk(risk));
        }

        [HttpGet]
        [Route("filters_project")]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var project = await riskService.GetProjects();
                return Ok(project);
            }
            catch (Exception ex) {
                return StatusCode(500, "Erro Interno.");
            }
        }

        [HttpGet]
        [Route("filters_metier")]
        public async Task<IActionResult> GetMetier()
        {
            try {
                var metier = await riskService.GetMetier();
                return Ok(metier);
            } 
            catch (Exception ex)
            {
                return StatusCode(500, "Erro Interno.");
            }

        }

        [HttpGet]
        [Route("filters_jalon")]
        public async Task<IActionResult> GetJalon()
        {
            try
            {
                var jalon = await riskService.GetJalon();
                return Ok(jalon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro Interno.");
            }
        }

    }
}
