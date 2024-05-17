using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;
using sigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
{
    public class FavoritoService : IFavoritoService
    {
        private readonly SigmaDbContext _context;

        public FavoritoService(SigmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorito>> ObterTodosFavoritos()
        {
            return await _context.Favoritos.ToListAsync();
        }

        public async Task<Favorito> ObterFavoritoPorId(int id)
        {
            return await _context.Favoritos.FindAsync(id) ?? throw new ArgumentException("Favorito não encontrado.");
        }

        public async Task<int> AdicionarFavorito(Favorito favorito)
        {
            _context.Favoritos.Add(favorito);
            await _context.SaveChangesAsync();
            return favorito.IDFavorito;
        }

        public async Task AtualizarFavorito(Favorito favorito)
        {
            _context.Entry(favorito).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DesabilitarFavorito(int id)
        {
            var favorito = await _context.Favoritos.FindAsync(id);
            if (favorito == null)
            {
                throw new ArgumentException("Favorito não encontrado.");
            }

            favorito.Ativo = false;
            await _context.SaveChangesAsync();
        }

        public async Task HabilitarFavorito(int id)
        {
            var favorito = await _context.Favoritos.FindAsync(id);
            if (favorito == null)
            {
                throw new ArgumentException("Favorito não encontrado.");
            }

            favorito.Ativo = true;
            await _context.SaveChangesAsync();
        }
    }
}

