using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;
using sigmaBack.Infra.Data.Repositories;
using SigmaBack.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sigmaBack.Application.Services
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioRepository;

        public AnuncioService(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository ?? throw new ArgumentNullException(nameof(anuncioRepository));
        }

        public async Task<IEnumerable<Anuncio>> ObterTodosAnuncios()
        {
            return await _anuncioRepository.ObterTodosAnuncios();
        }

        public async Task<Anuncio> ObterAnuncioPorId(int id)
        {
            return await _anuncioRepository.ObterAnuncioPorId(id) ?? throw new ArgumentException("Anúncio não encontrado.");
        }

        public async Task<int> CriarAnuncio(Anuncio anuncio)
        {
            return await _anuncioRepository.CriarAnuncio(anuncio);
        }

        public async Task AtualizarAnuncio(int id, Anuncio anuncio)
        {
            if (id != anuncio.IDAnuncio)
            {
                throw new ArgumentException("ID do anúncio não corresponde ao ID na URL.");
            }

            await _anuncioRepository.AtualizarAnuncio(anuncio);
        }

        public async Task HabilitarAnuncio(int id)
        {
            var anuncio = await _anuncioRepository.ObterAnuncioPorId(id)
          ?? throw new ArgumentException("Anúncio não encontrado.");
            
            anuncio.Ativo = true;
            await _anuncioRepository.AtualizarAnuncio(anuncio);
        }

        public async Task DesabilitarAnuncio(int id)
        {
            var anuncio = await _anuncioRepository.ObterAnuncioPorId(id)
           ?? throw new ArgumentException("Anúncio não encontrado.");

            anuncio.Ativo = false;
            await _anuncioRepository.AtualizarAnuncio(anuncio);
        }

        public async Task AtualizarReferenciaImagem(int idAnuncio, string referenciaImagem)
        {
            var anuncio = await _anuncioRepository.ObterAnuncioPorId(idAnuncio)
                ?? throw new ArgumentException("Anúncio não encontrado");

            anuncio.ReferenciaImagem = referenciaImagem;
            await _anuncioRepository.AtualizarAnuncio(anuncio);
        }
    }
}
