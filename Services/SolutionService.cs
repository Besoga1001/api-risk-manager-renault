using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using project_renault.Models;
using System.Diagnostics.Metrics;

namespace project_renault.Services
{
    public class SolutionService
    {
        DBSettings _context;
        public SolutionService(DBSettings context)
        {
            _context = context;
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
