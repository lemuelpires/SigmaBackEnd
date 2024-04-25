using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using sigmaBack.Infra.Data.Contexts;

namespace SigmaBack.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SigmaDbContext _dbContext;

        public UsuarioRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> ObterTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorId(int id)
        {
            return await _dbContext.Usuarios.FindAsync(id);
        }

        public async Task<int> InserirUsuario(Usuario usuario) // Corrigido: Retorno alterado para Task<int>
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario.IDUsuario; // Retorna o ID do usuário inserido
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoverUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> VerificarExistenciaEmail(string email)
        {
            return await _dbContext.Usuarios.AnyAsync(u => u.Email == email);
        }
    }
}
//