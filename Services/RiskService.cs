﻿using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_renault.Models;
using System.Diagnostics.Metrics;

namespace project_renault.Services
{
    public class RiskService
    {
        DBSettings _context;
        public RiskService(DBSettings context)
        {
            _context = context;
        }

        public async Task<List<RiskModel>> GetAllRisk()
        {
            return await _context.Risk.ToListAsync();
        }

        public async Task<RiskModel> GetByIdRisk(int? id)
        {
            if (id == null)
            {
                throw new Exception();
            }

            var risk = await _context.Risk.FindAsync(id);

            if (risk == null)
            {
                throw new Exception();
            }

            return risk;
        }

        public async Task<RiskModel> AddRisk(RiskModel risk)
        {
            try
            {
                await _context.Risk.AddAsync(risk);
                await _context.SaveChangesAsync();

                return risk;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<RiskModel> PutRisk(RiskModel risk)
        {
            try
            {
                _context.Entry(risk).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return risk;
            }
            catch
            {
                throw new Exception();
            }

        }

        public async Task<List<String>> GetProjects()
        {
            try
            {
                var projetos = await _context.Risk
                    .Select(r => r.Projeto)
                    .Distinct()
                    .ToListAsync();
                return projetos;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpGet]
        [Route("filters_metier")]
        public async Task<List<String>> GetMetier()
        {
            try
            {
                var metiers = await _context.Risk
                    .Select(r => r.Metier)
                    .Distinct()
                    .ToListAsync();
                return metiers;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public async Task<List<String>> GetJalon()
        {
            try
            {
                var jalon = await _context.Risk
                    .Select(r => r.JalonAfetado)
                    .Distinct()
                    .ToListAsync();
                return jalon;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
