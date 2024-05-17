using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sigmaBack.Application.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly SigmaDbContext _context;

        public AnuncioService(SigmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Anuncio>> ObterTodosAnuncios()
        {
            return await _context.Anuncios.ToListAsync();
        }

        public async Task<Anuncio> ObterAnuncioPorId(int id)
        {
            return await _context.Anuncios.FindAsync(id) ?? throw new ArgumentException("Anúncio não encontrado.");
        }

        public async Task<int> CriarAnuncio(Anuncio anuncio)
        {
            _context.Anuncios.Add(anuncio);
            await _context.SaveChangesAsync();
            return anuncio.IDAnuncio;
        }

        public async Task AtualizarAnuncio(int id, Anuncio anuncio)
        {
            if (id != anuncio.IDAnuncio)
            {
                throw new ArgumentException("ID do anúncio não corresponde ao ID na URL.");
            }

            _context.Entry(anuncio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnuncioExists(id))
                {
                    throw new ArgumentException("Anúncio não encontrado.");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task HabilitarAnuncio(int id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio == null)
            {
                throw new ArgumentException("Anúncio não encontrado.");
            }

            anuncio.Ativo = true;
            await _context.SaveChangesAsync();
        }

        public async Task DesabilitarAnuncio(int id)
        {
            var anuncio = await _context.Anuncios.FindAsync(id);
            if (anuncio == null)
            {
                throw new ArgumentException("Anúncio não encontrado.");
            }

            anuncio.Ativo = false;
            await _context.SaveChangesAsync();
        }

        private bool AnuncioExists(int id)
        {
            return _context.Anuncios.Any(e => e.IDAnuncio == id);
        }
    }
}

