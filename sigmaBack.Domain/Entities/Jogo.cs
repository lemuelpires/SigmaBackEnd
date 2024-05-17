using System;
using System.Collections.Generic;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class Jogo
    {
        public int IDJogo { get; set; }
        public string? NomeJogo { get; set; }
        public string? CategoriaJogo { get; set; }
        public string? ProcessadorRequerido { get; set; }
        public string? MemoriaRAMRequerida { get; set; }
        public string? PlacaVideoRequerida { get; set; }
        public string? EspacoDiscoRequerido { get; set; }
        public string? ReferenciaImagemJogo { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }

        public Jogo() { }

        public Jogo(string nomeJogo, string categoriaJogo, string processadorRequerido, string memoriaRAMRequerida, string placaVideoRequerida, string espacoDiscoRequerido, string referenciaImagemJogo, DateTime data, bool ativo)
        {
            ValidationDomain(nomeJogo, categoriaJogo, processadorRequerido, memoriaRAMRequerida, placaVideoRequerida, espacoDiscoRequerido, referenciaImagemJogo);
            Ativo = ativo;
        }

        public Jogo(int idJogo, string nomeJogo, string categoriaJogo, string processadorRequerido, string memoriaRAMRequerida, string placaVideoRequerida, string espacoDiscoRequerido, string referenciaImagemJogo, DateTime data, bool ativo)
        {
            IDJogo = idJogo;
            ValidationDomain(nomeJogo, categoriaJogo, processadorRequerido, memoriaRAMRequerida, placaVideoRequerida, espacoDiscoRequerido, referenciaImagemJogo);
            Ativo = ativo;
        }

        private void ValidationDomain(string nomeJogo, string categoriaJogo, string processadorRequerido, string memoriaRAMRequerida, string placaVideoRequerida, string espacoDiscoRequerido, string referenciaImagemJogo)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeJogo), "O nome do jogo é obrigatório.");
            DomainExceptionValidation.When(nomeJogo.Length < 3, "O nome do jogo deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(categoriaJogo), "A categoria do jogo é obrigatória.");
            DomainExceptionValidation.When(categoriaJogo.Length < 3, "A categoria do jogo deve ter no mínimo 3 caracteres.");

            // Outras validações aqui...

            NomeJogo = nomeJogo;
            CategoriaJogo = categoriaJogo;
            ProcessadorRequerido = processadorRequerido;
            MemoriaRAMRequerida = memoriaRAMRequerida;
            PlacaVideoRequerida = placaVideoRequerida;
            EspacoDiscoRequerido = espacoDiscoRequerido;
            ReferenciaImagemJogo = referenciaImagemJogo;
        }

        public void Update(int idJogo, string nomeJogo, string categoriaJogo, string processadorRequerido, string memoriaRAMRequerida, string placaVideoRequerida, string espacoDiscoRequerido, string referenciaImagemJogo, DateTime data, bool ativo)
        {
            ValidationDomain(nomeJogo, categoriaJogo, processadorRequerido, memoriaRAMRequerida, placaVideoRequerida, espacoDiscoRequerido, referenciaImagemJogo);
            IDJogo = idJogo;
            Ativo = ativo;
        }
    }
}
