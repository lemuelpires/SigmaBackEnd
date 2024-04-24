﻿using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly SigmaDbContext _context;

        public AvaliacaoService(SigmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Avaliacao>> GetAllAvaliacoesAsync()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao> GetAvaliacaoByIdAsync(int id)
        {
            return await _context.Avaliacoes.FindAsync(id);
        }

        public async Task<Avaliacao> CreateAvaliacaoAsync(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao;
        }

        public async Task UpdateAvaliacaoAsync(Avaliacao avaliacao)
        {
            _context.Entry(avaliacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAvaliacaoAsync(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao == null)
            {
                throw new ArgumentException("Avaliação não encontrada.");
            }

            _context.Avaliacoes.Remove(avaliacao);
            await _context.SaveChangesAsync();
        }
    }
}
