using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Infra.Data.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SigmaDbContext _dbContext;

        public CategoriaRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Categoria>> ObterTodasCategorias()
        {
            return await _dbContext.Categorias.ToListAsync();
        }

        public async Task<Categoria> ObterCategoriaPorId(int id)
        {
            return await _dbContext.Categorias.FindAsync(id) ?? throw new ArgumentException("Categoria não encontrada.");
        }

        public async Task<int> CriarNovaCategoria(Categoria categoria)
        {
            _dbContext.Categorias.Add(categoria);
            await _dbContext.SaveChangesAsync();
            return categoria.IDCategoria;
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            _dbContext.Categorias.Update(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DesabilitarCategoria(int id)
        {
            var categoria = await _dbContext.Categorias.FindAsync(id);
            if (categoria != null)
            {
                categoria.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task HabilitarCategoria(int id)
        {
            var categoria = await _dbContext.Categorias.FindAsync(id);
            if (categoria != null)
            {
                categoria.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}