using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
{
    public class UsuarioJogoService : IUsuarioJogoService
    {
        private readonly SigmaDbContext _context;

        public UsuarioJogoService(SigmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioJogo>> ObterTodosUsuarioJogo()
        {
            return await _context.UsuarioJogos.ToListAsync();
        }

        public async Task<UsuarioJogo> ObterUsuarioJogoPorId(int id)
        {
            return await _context.UsuarioJogos.FindAsync(id) ?? throw new ArgumentException("Usuário do jogo não encontrado.");
        }

        public async Task<int> AdicionarUsuarioJogo(UsuarioJogo usuarioJogo)
        {
            _context.UsuarioJogos.Add(usuarioJogo);
            await _context.SaveChangesAsync();
            return usuarioJogo.IDAssociacao;
        }

        public async Task AtualizarUsuarioJogo(UsuarioJogo usuarioJogo)
        {
            _context.Entry(usuarioJogo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DesabilitarUsuarioJogo(int id)
        {
            var usuarioJogo = await _context.UsuarioJogos.FindAsync(id);
            if (usuarioJogo == null)
            {
                throw new ArgumentException("Usuário do jogo não encontrado.");
            }

            usuarioJogo.Ativo = false; // Alterando para desabilitar o usuário do jogo
            await _context.SaveChangesAsync();
        }

        public async Task HabilitarUsuarioJogo(int id)
        {
            var usuarioJogo = await _context.UsuarioJogos.FindAsync(id);
            if (usuarioJogo == null)
            {
                throw new ArgumentException("Não foi possível habilitar o usuário do jogo. Usuário do jogo não encontrado.");
            }

            usuarioJogo.Ativo = true; // Alterando para habilitar o usuário do jogo
            await _context.SaveChangesAsync();
        }

    }
}
