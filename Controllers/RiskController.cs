using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_renault.Models;
using project_renault.Services;
using System.Data;

namespace project_renault.Controllers
{
    [Route("[controller]")]
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
            return Ok(riskService.GetProjects());
        }

        [HttpGet]
        [Route("filters_metier")]
        public async Task<IActionResult> GetMetier()
        {
            return Ok(riskService.GetMetier());
        }

        [HttpGet]
        [Route("filters_jalon")]
        public async Task<IActionResult> GetJalon()
        {
            return Ok(riskService.GetJalon());
        }

    }
}
