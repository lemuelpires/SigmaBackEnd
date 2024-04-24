using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using SigmaBack.Domain.Interfaces;
using sigmaBack.Infra.Data.Contexts;

namespace sigmaBack.Infra.Data.Repositories
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly SigmaDbContext _context;

        public AvaliacaoRepository(SigmaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Avaliacao>> ObterTodasAvaliacoes()
        {
            return await _context.Avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao> ObterAvaliacaoPorId(int id)
        {
            return await _context.Avaliacoes.FindAsync(id);
        }

        public async Task<int> CriarNovaAvaliacao(Avaliacao avaliacao)
        {
            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return avaliacao.IDAvaliacao;
        }

        public async Task AtualizarAvaliacao(Avaliacao avaliacao)
        {
            _context.Entry(avaliacao).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAvaliacao(int id)
        {
            var avaliacao = await _context.Avaliacoes.FindAsync(id);
            if (avaliacao != null)
            {
                _context.Avaliacoes.Remove(avaliacao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
