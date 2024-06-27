using Microsoft.EntityFrameworkCore;
using project_renault.Models;

namespace project_renault.Services
{
    public class SolutionService
    {
        DBSettings _context;
        RiskService riskService;
        public SolutionService(DBSettings context, RiskService riskService)
        {
            _context = context;
            this.riskService = riskService;
        }

        public async Task<List<SolutionModel>> GetAllSolution()
        {
            return await _context.Solution.ToListAsync();
        }

        public async Task<SolutionModel> GetByIdSolution(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }

            var solution = await _context.Solution.FindAsync(id);

            if (solution == null)
            {
                throw new Exception();
            }

            return solution;
        }

        public async Task<SolutionModel> AddSolution(SolutionModel solution)
        {
            try
            {
                await _context.Solution.AddAsync(solution);
                await _context.SaveChangesAsync();

                RiskModel? risk = await _context.Risk.FindAsync(solution.id_risk);
                if (risk == null)
                {
                    throw new Exception();
                }
                risk.id_solution = solution.Id_Solution;
                var resp = await riskService.PutRisk(risk);
                await _context.SaveChangesAsync();

                return solution;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<SolutionModel> PutSolution(SolutionModel solution)
        {
            try
            {
                _context.Entry(solution).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return solution;
            }
            catch
            {
                throw new Exception();
            }

        }
    }
}
