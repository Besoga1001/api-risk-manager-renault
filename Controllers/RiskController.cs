using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_renault.Models;
using Dapper;
using MySql.Data;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace project_renault.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RiskController : Controller
    {
        private readonly DBSettings _context;

        public RiskController(DBSettings context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllRisk()
        {
            return Ok(await _context.Risk.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdRisk(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var risk = await _context.Risk.FindAsync(id);

            if (risk == null)
            {
                return NotFound();
            }

            return Ok(risk);
        }

        [HttpPost]
        public async Task<ActionResult<RiskModel>> AddRisk(RiskModel risk)
        {
            try
            {
                await _context.Risk.AddAsync(risk);
                await _context.SaveChangesAsync();

                return Ok(risk);
            } catch 
            {       
                return StatusCode(500);
            }
  
        }

        [HttpPut]
        public async Task<ActionResult<RiskModel>> PutRisk(RiskModel risk)
        {
            try
            {
                _context.Entry(risk).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(risk);
            } catch {
                return StatusCode(500);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntidade(int id)
        {
            var entidade = await _context.Risk.FindAsync(id);
            if (entidade == null)
            {
                return NotFound();
            }

            _context.Risk.Remove(entidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("filters_project")]
        public async Task<IActionResult> GetFilters()
        {
            try
            {
                var projetos = await _context.Risk
                    .Select(r => r.Projeto)
                    .Distinct()
                    .ToListAsync();
                return Ok(projetos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("filters_metier")]
        public async Task<IActionResult> GetMetier()
        {
            try
            {
                var metiers = await _context.Risk
                    .Select(r => r.Metier)
                    .Distinct()
                    .ToListAsync();
                return Ok(metiers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("filters_jalon")]
        public async Task<IActionResult> GetJalon()
        {
            try
            {
                var jalon = await _context.Risk
                    .Select(r => r.JalonAfetado)
                    .Distinct()
                    .ToListAsync();
                return Ok(jalon);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }


    }
}
