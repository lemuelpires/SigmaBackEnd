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
    public class UsuarioJogoRepository : IUsuarioJogoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public UsuarioJogoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<int> CriarNovoUsuarioJogo(UsuarioJogo usuarioJogo)
        {
            _dbContext.UsuarioJogos.Add(usuarioJogo);
            await _dbContext.SaveChangesAsync();
            return usuarioJogo.IDAssociacao;
        }

        public async Task AtualizarUsuarioJogo(UsuarioJogo usuarioJogo)
        {
            _dbContext.UsuarioJogos.Update(usuarioJogo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UsuarioJogo>> ObterTodosUsuarioJogo()
        {
            return await _dbContext.UsuarioJogos.ToListAsync();
        }

        public async Task<UsuarioJogo> ObterUsuarioJogoPorId(int id)
        {
            return await _dbContext.UsuarioJogos.FindAsync(id) ?? throw new ArgumentException("Usuário-Jogo não encontrado.");
        }

        public async Task HabilitarUsuarioJogo(int id)
        {
            var usuarioJogo = await _dbContext.UsuarioJogos.FindAsync(id);
            if (usuarioJogo != null)
            {
                usuarioJogo.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task DesabilitarUsuarioJogo(int id)
        {
            var usuarioJogo = await _dbContext.UsuarioJogos.FindAsync(id);
            if (usuarioJogo != null)
            {
                usuarioJogo.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
