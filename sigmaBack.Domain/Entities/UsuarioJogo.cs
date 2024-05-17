using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class UsuarioJogo
    {
        [Key]
        public int IDAssociacao { get; set; }

        public int IDUsuario { get; set; }

        public int IDJogo { get; set; }

        public string? ReferenciaImagemJogo { get; set; }

        public bool Ativo { get; set; }

        public Usuario? Usuario { get; set; }

        public Jogo? Jogo { get; set; }

        public UsuarioJogo() { }

        public UsuarioJogo(int idUsuario, int idJogo, string referenciaImagemJogo, bool ativo)
        {
            ValidationDomain(idUsuario, idJogo, referenciaImagemJogo);
            Ativo = ativo;
        }

        public UsuarioJogo(int idAssociacao, int idUsuario, int idJogo, string referenciaImagemJogo, bool ativo)
            : this(idUsuario, idJogo, referenciaImagemJogo, ativo)
        {
            IDAssociacao = idAssociacao;
        }

        private void ValidationDomain(int idUsuario, int idJogo, string referenciaImagemJogo)
        {
            DomainExceptionValidation.When(idUsuario <= 0, "O ID do usuário é obrigatório.");
            DomainExceptionValidation.When(idJogo <= 0, "O ID do jogo é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(referenciaImagemJogo), "A referência da imagem do jogo é obrigatória.");

            IDUsuario = idUsuario;
            IDJogo = idJogo;
            ReferenciaImagemJogo = referenciaImagemJogo;
        }

        public void Update(int idUsuario, int idJogo, string referenciaImagemJogo, bool ativo)
        {
            ValidationDomain(idUsuario, idJogo, referenciaImagemJogo);
            Ativo = ativo;
        }
    }
}
