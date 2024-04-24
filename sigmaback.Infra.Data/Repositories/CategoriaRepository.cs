using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Contexts;

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
            return await _dbContext.Categorias.FindAsync(id);
        }

        public async Task<int> CriarNovaCategoria(Categoria categoria)
        {
            _dbContext.Categorias.Add(categoria);
            await _dbContext.SaveChangesAsync();
            return categoria.IDCategoria; // Supondo que o ID seja gerado automaticamente
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            _dbContext.Categorias.Update(categoria);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverCategoria(int id)
        {
            var categoria = await _dbContext.Categorias.FindAsync(id);
            if (categoria != null)
            {
                _dbContext.Categorias.Remove(categoria);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
