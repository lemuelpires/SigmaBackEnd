using sigmaBack.Domain.Validation;

namespace sigmaBack.Domain.Entities
{
    public class Anuncio
    {
        public int IDAnuncio { get; set; }
        public int IDProduto { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public string? ReferenciaImagem { get; set; }
        public DateTime Data { get; set; }
        public bool Ativo { get; set; }

        public Anuncio() { }

        public Anuncio(int idProduto, string titulo, string descricao, decimal preco, string referenciaImagem, DateTime data, bool ativo)
        {
            ValidationDomain(idProduto, titulo, descricao, preco, referenciaImagem, data);
            Ativo = ativo;
        }

        public Anuncio(int idAnuncio, int idProduto, string titulo, string descricao, decimal preco, string referenciaImagem, DateTime data, bool ativo)
        {
            IDAnuncio = idAnuncio;
            ValidationDomain(idProduto, titulo, descricao, preco, referenciaImagem, data);
            Ativo = ativo;
        }

        private void ValidationDomain(int idProduto, string titulo, string descricao, decimal preco, string referenciaImagem, DateTime data)
        {
            DomainExceptionValidation.When(idProduto < 0, "O ID do produto é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo), "O título do anúncio é obrigatório.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "A descrição do anúncio é obrigatória.");
            DomainExceptionValidation.When(preco < 0, "O preço do anúncio deve ser maior ou igual a zero.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(referenciaImagem), "A referência da imagem é obrigatória.");
            DomainExceptionValidation.When(data == default, "A data do anúncio é obrigatória.");

            IDProduto = idProduto;
            Titulo = titulo;
            Descricao = descricao;
            Preco = preco;
            ReferenciaImagem = referenciaImagem;
            Data = data;
        }

        public void Update(int idAnuncio, int idProduto, string titulo, string descricao, decimal preco, string referenciaImagem, DateTime data, bool ativo)
        {
            ValidationDomain(idProduto, titulo, descricao, preco, referenciaImagem, data);
            IDAnuncio = idAnuncio;
            Ativo = ativo;
        }
    }
}
