using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class Favorito
    {
        public int IDFavorito { get; set; }
        public int IDUsuario { get; set; }
        public int IDProduto { get; set; }
        public string? ImagemProduto { get; set; }
        public bool Ativo { get; set; }

        public Favorito() { }

        public Favorito(int idUsuario, int idProduto, string imagemProduto, bool ativo)
        {
            ValidationDomain(idUsuario, idProduto, imagemProduto);
            Ativo = ativo;
        }

        public Favorito(int idFavorito, int idUsuario, int idProduto, string imagemProduto, bool ativo)
        {
            IDFavorito = idFavorito;
            ValidationDomain(idUsuario, idProduto, imagemProduto);
            Ativo = ativo;
        }

        private void ValidationDomain(int idUsuario, int idProduto, string imagemProduto)
        {
            DomainExceptionValidation.When(idUsuario < 0, "O ID do usuário é obrigatório.");
            DomainExceptionValidation.When(idProduto < 0, "O ID do produto é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(imagemProduto), "A imagem do produto é obrigatória.");

            IDUsuario = idUsuario;
            IDProduto = idProduto;
            ImagemProduto = imagemProduto;
        }

        public void Update(int idFavorito, int idUsuario, int idProduto, string imagemProduto, bool ativo)
        {
            ValidationDomain(idUsuario, idProduto, imagemProduto);
            IDFavorito = idFavorito;
            Ativo = ativo;
        }
    }
}

