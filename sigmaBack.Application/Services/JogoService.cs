using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using SigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.Application.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository ?? throw new ArgumentNullException(nameof(jogoRepository));
        }

        public async Task<IEnumerable<Jogo>> ObterTodosJogos()
        {
            return await _jogoRepository.ObterTodosJogos();
        }

        public async Task<Jogo> ObterJogoPorId(int id)
        {
            return await _jogoRepository.ObterJogoPorId(id);
        }

        public async Task<IEnumerable<Jogo>> ObterJogosPorCategoria(string categoria)
        {
            return await _jogoRepository.ObterJogosPorCategoria(categoria);
        }

        public async Task<IEnumerable<Jogo>> ObterJogosAtivos()
        {
            return await _jogoRepository.ObterJogosAtivos();
        }

        public async Task<IEnumerable<Jogo>> PesquisarJogos(string termoPesquisa)
        {
            return await _jogoRepository.PesquisarJogos(termoPesquisa);
        }

        public async Task InserirJogo(Jogo jogo)
        {
            await _jogoRepository.InserirJogo(jogo);
        }

        public async Task AtualizarJogo(Jogo jogo)
        {
            await _jogoRepository.AtualizarJogo(jogo);
        }

        public async Task HabilitarJogo(int id)
        {
            await _jogoRepository.HabilitarJogo(id);
        }

        public async Task DesabilitarJogo(int id)
        {
            await _jogoRepository.DesabilitarJogo(id);
        }
    }
}
