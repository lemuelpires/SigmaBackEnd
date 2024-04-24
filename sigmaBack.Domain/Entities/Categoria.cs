using sigmaBack.Domain.Validation;
using System;

namespace sigmaBack.Domain.Entities
{
    public class Categoria
    {
        public int IDCategoria { get; set; }

        private string _nomeCategoria;
        public string NomeCategoria
        {
            get { return _nomeCategoria; }
             set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new DomainExceptionValidation("O nome da categoria é obrigatório.");
                }
                _nomeCategoria = value;
            }
        }

        public int IDCategoriaPai { get; set; }

        public Categoria(string nomeCategoria)
        {
            NomeCategoria = nomeCategoria;
        }

        public Categoria()
        {        
        }

        public Categoria(int idCategoria, string nomeCategoria)
        {
            IDCategoria = idCategoria;
            NomeCategoria = nomeCategoria;
        }

        public void Update(string novoNomeCategoria)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(novoNomeCategoria), "O novo nome da categoria é obrigatório.");
            NomeCategoria = novoNomeCategoria;
        }

    }
}