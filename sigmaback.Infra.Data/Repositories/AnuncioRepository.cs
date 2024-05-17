using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Infra.Data.Repositories
{
    public class AnuncioRepository : IAnuncioRepository
    {
        private readonly SigmaDbContext _dbContext;

        public AnuncioRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext;
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
            if (_dbContext == null || _dbContext.Anuncios == null)
            {
                throw new NullReferenceException("_dbContext ou _dbContext.Anuncios é nulo. Verifique se foram inicializados corretamente.");
            }

            return await _dbContext.Anuncios
                .Where(a => a.Titulo != null && a.Titulo.Contains(termoPesquisa))
                .ToListAsync();
        }

        public async Task InserirAnuncio(Anuncio anuncio)
        {
            _dbContext.Anuncios.Add(anuncio);
            await _dbContext.SaveChangesAsync();
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
    }
}

