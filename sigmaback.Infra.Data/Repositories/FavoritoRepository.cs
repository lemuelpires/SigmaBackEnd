using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Infra.Data.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public FavoritoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> AdicionarFavorito(Favorito favorito)
        {
            _dbContext.Favoritos.Add(favorito);
            await _dbContext.SaveChangesAsync();
            return favorito.IDFavorito;
        }

        public async Task AtualizarFavorito(Favorito favorito)
        {
            _dbContext.Favoritos.Update(favorito);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Favorito>> ObterTodosFavoritos()
        {
            return await _dbContext.Favoritos.ToListAsync();
        }

        public async Task<Favorito> ObterFavoritoPorId(int id)
        {
            return await _dbContext.Favoritos.FindAsync(id) ?? throw new ArgumentException("Favorito não encontrado.");
        }

        public async Task HabilitarFavorito(int id)
        {
            var favorito = await _dbContext.Favoritos.FindAsync(id);
            if (favorito != null)
            {
                favorito.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DesabilitarFavorito(int id)
        {
            var favorito = await _dbContext.Favoritos.FindAsync(id);
            if (favorito != null)
            {
                favorito.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

