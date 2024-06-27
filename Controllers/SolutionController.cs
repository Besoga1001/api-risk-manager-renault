using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_renault.Models;
using project_renault.Services;
using System.Data;

namespace project_renault.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolutionController : Controller
    {

        SolutionService solutionService;

        public SolutionController(SolutionService solutionService)
        {
            this.solutionService = solutionService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllSolution()
        {
            var response = await solutionService.GetAllSolution();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdSolution(int? id)
        {
            var response = await solutionService.GetByIdSolution(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddSolution(SolutionModel solution)
        {
            var response = await solutionService.AddSolution(solution);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<SolutionModel>> PutSolution(SolutionModel solution)
        {
            var response = await solutionService.PutSolution(solution);
            return Ok(response);
        }


    }
}
