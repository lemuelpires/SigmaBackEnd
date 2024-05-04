using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Contexts;
using SigmaBack.Domain.Interfaces;

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
            return await _dbContext.Usuarios.FindAsync(id) ?? throw new ArgumentException("Usuario não encontrado.");
        }

        public async Task<int> InserirUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario.IDUsuario;
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            _dbContext.Entry(usuario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> VerificarExistenciaEmail(string email)
        {
            return await _dbContext.Usuarios.AnyAsync(u => u.Email == email);
        }

        public async Task DesabilitarUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                usuario.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task HabilitarUsuario(int id)
        {
            var usuario = await _dbContext.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                usuario.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}