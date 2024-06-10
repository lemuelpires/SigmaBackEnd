using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Contexts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sigmaBack.Infra.Data.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly SigmaDbContext _dbContext;

        public JogoRepository(SigmaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Jogo>> ObterTodosJogos()
        {
            return await _dbContext.Jogos.ToListAsync();
        }

        public async Task<Jogo> ObterJogoPorId(int id)
        {
            return await _dbContext.Jogos.FindAsync(id) ?? throw new ArgumentException("Jogo não encontrado.");
        }

        public async Task<IEnumerable<Jogo>> ObterJogosPorCategoria(string categoria)
        {
            return await _dbContext.Jogos.Where(j => j.CategoriaJogo == categoria).ToListAsync();
        }

        public async Task<IEnumerable<Jogo>> ObterJogosAtivos()
        {
            return await _dbContext.Jogos.Where(j => j.Ativo).ToListAsync();
        }

        public async Task<IEnumerable<Jogo>> PesquisarJogos(string termoPesquisa)
        {
            return await _dbContext.Jogos
                .Where(j => j.NomeJogo != null && j.NomeJogo.Contains(termoPesquisa))
                .ToListAsync();
        }

        public async Task InserirJogo(Jogo jogo)
        {
            _dbContext.Jogos.Add(jogo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AtualizarJogo(Jogo jogo)
        {
            _dbContext.Entry(jogo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DesabilitarJogo(int id)
        {
            var jogo = await _dbContext.Jogos.FindAsync(id);
            if (jogo != null)
            {
                jogo.Ativo = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task HabilitarJogo(int id)
        {
            var jogo = await _dbContext.Jogos.FindAsync(id);
            if (jogo != null)
            {
                jogo.Ativo = true;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task AtualizarReferenciaImagem(int id, string referenciaImagem)
        {
            var jogo = await _dbContext.Jogos.FindAsync(id);
            if (jogo != null)
            {
                jogo.ReferenciaImagemJogo = referenciaImagem;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
