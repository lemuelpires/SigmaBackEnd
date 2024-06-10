using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sigmaBack.Infra.Data.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly SigmaDbContext _dbContext;

        public AnuncioRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Anuncio>> ObterTodosAnuncios()
        {
            return await _dbContext.Anuncios.ToListAsync();
        }

        public async Task<Anuncio> ObterAnuncioPorId(int id)
        {
            return await _dbContext.Anuncios.FindAsync(id) ?? throw new ArgumentException("Anúncio não encontrado.");
        }

        public async Task<IEnumerable<Anuncio>> ObterAnunciosPorPreco(decimal precoMin, decimal precoMax)
        {
            return await _dbContext.Anuncios.Where(a => a.Preco >= precoMin && a.Preco <= precoMax).ToListAsync();
        }

        public async Task<IEnumerable<Anuncio>> ObterAnunciosAtivos()
        {
            return await _dbContext.Anuncios.Where(a => a.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<Anuncio>> PesquisarAnuncios(string termoPesquisa)
        {
            if (string.IsNullOrWhiteSpace(termoPesquisa))
            {
                throw new ArgumentNullException(nameof(termoPesquisa));
            }

            return await _dbContext.Anuncios
                .Where(a => a.Titulo != null && a.Titulo.Contains(termoPesquisa)) // Verificação de nulidade
                .ToListAsync();
        }

        public async Task<int> CriarAnuncio(Anuncio anuncio)
        {
            _dbContext.Anuncios.Add(anuncio);
            await _dbContext.SaveChangesAsync();
            return anuncio.IDAnuncio;
        }

        public async Task AtualizarAnuncio(Anuncio anuncio)
        {
            _dbContext.Entry(anuncio).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DesabilitarAnuncio(int id)
        {
            var anuncio = await _dbContext.Anuncios.FindAsync(id);
            if (anuncio != null)
            {
                anuncio.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task HabilitarAnuncio(int id)
        {
            var anuncio = await _dbContext.Anuncios.FindAsync(id);
            if (anuncio != null)
            {
                anuncio.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AtualizarReferenciaImagem(int id, string referenciaImagem)
        {
            var anuncio = await _dbContext.Anuncios.FindAsync(id);
            if (anuncio != null)
            {
                anuncio.ReferenciaImagem = referenciaImagem;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
