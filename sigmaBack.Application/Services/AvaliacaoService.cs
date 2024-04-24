using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sigmaBack.Application.Services
{
    public class AvaliacaoService : IAvaliacaoService
    {
        private readonly List<Avaliacao> _avaliacoes; // Lista simulando o armazenamento das avaliações

        public AvaliacaoService()
        {
            _avaliacoes = new List<Avaliacao>();
        }

        public Task<IEnumerable<Avaliacao>> GetAllAvaliacoesAsync()
        {
            return Task.FromResult<IEnumerable<Avaliacao>>(_avaliacoes);
        }

        public Task<Avaliacao> GetAvaliacaoByIdAsync(int id)
        {
            var avaliacao = _avaliacoes.Find(a => a.IDAvaliacao == id);
            return Task.FromResult(avaliacao);
        }

        public Task<Avaliacao> CreateAvaliacaoAsync(Avaliacao avaliacao)
        {
            avaliacao.IDAvaliacao = _avaliacoes.Count + 1; // Atribui um ID sequencial
            _avaliacoes.Add(avaliacao);
            return Task.FromResult(avaliacao);
        }

        public Task UpdateAvaliacaoAsync(Avaliacao avaliacao)
        {
            var index = _avaliacoes.FindIndex(a => a.IDAvaliacao == avaliacao.IDAvaliacao);
            if (index != -1)
            {
                _avaliacoes[index] = avaliacao;
            }
            else
            {
                throw new ArgumentException("Avaliação não encontrada.");
            }
            return Task.CompletedTask;
        }

        public Task DeleteAvaliacaoAsync(int id)
        {
            var index = _avaliacoes.FindIndex(a => a.IDAvaliacao == id);
            if (index != -1)
            {
                _avaliacoes.RemoveAt(index);
            }
            else
            {
                throw new ArgumentException("Avaliação não encontrada.");
            }
            return Task.CompletedTask;
        }
    }
}
