using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class Categoria
    {
        public int IDCategoria { get; set; }
        private string? _nomeCategoria;
        public string? NomeCategoria
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
        public bool Ativo { get; set; } // Novo campo

        public Categoria(string nomeCategoria)
        {
            NomeCategoria = nomeCategoria;
        }

        public Categoria()
        {
        }

        public Categoria(int idCategoria, string nomeCategoria, bool ativo)
        {
            IDCategoria = idCategoria;
            NomeCategoria = nomeCategoria;
            Ativo = ativo; // Defina o valor do novo campo
        }

        public void Update(string? novoNomeCategoria, bool ativo)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(novoNomeCategoria), "O novo nome da categoria é obrigatório.");
            NomeCategoria = novoNomeCategoria;
            Ativo = ativo; // Atualize o valor do novo campo
        }
    }
}
