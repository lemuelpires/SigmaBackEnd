using sigmaBack.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sigmaBack.Domain.Entities
{
    public class Produto
    {
        public int IDProduto { get; set; }

        public string NomeProduto { get; private set; }
        public string DescricaoProduto { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public string Categoria { get; private set; }
        public string Marca { get; private set; }
        public string ImagemProduto { get; private set; }
        public string FichaTecnica { get; private set; }

        public ICollection<ItemPedido> ItensPedido { get; set; }
        public ICollection<ItemCarrinho> ItensCarrinho { get; set; }
        public ICollection<Avaliacao> Avaliacoes { get; set; }

        public Produto(string nomeProduto, string descricaoProduto, decimal preco, int quantidadeEstoque, string categoria, string marca, string imagemProduto, string fichaTecnica)
        {
            ValidationDomain(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica);
        }

        public Produto(int idProduto, string nomeProduto, string descricaoProduto, decimal preco, int quantidadeEstoque, string categoria, string marca, string imagemProduto, string fichaTecnica)
        {
            IDProduto = idProduto;
            ValidationDomain(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica);
        }

        private void ValidationDomain(string nomeProduto, string descricaoProduto, decimal preco, int quantidadeEstoque, string categoria, string marca, string imagemProduto, string fichaTecnica)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nomeProduto), "O nome do produto é obrigatório.");
            DomainExceptionValidation.When(nomeProduto.Length < 3, "O nome do produto deve ter no mínimo 3 caracteres.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricaoProduto), "A descrição do produto é obrigatória.");
            DomainExceptionValidation.When(descricaoProduto.Length < 5, "A descrição do produto deve ter no mínimo 5 caracteres.");

            DomainExceptionValidation.When(preco < 0, "O preço do produto deve ser maior ou igual a zero.");

            DomainExceptionValidation.When(quantidadeEstoque < 0, "A quantidade em estoque do produto deve ser maior ou igual a zero.");

            NomeProduto = nomeProduto;
            DescricaoProduto = descricaoProduto;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Categoria = categoria;
            Marca = marca;
            ImagemProduto = imagemProduto;
            FichaTecnica = fichaTecnica;
        }

        public void Update(int idProduto, string nomeProduto, string descricaoProduto, decimal preco, int quantidadeEstoque, string categoria, string marca, string imagemProduto, string fichaTecnica)
        {
            ValidationDomain(nomeProduto, descricaoProduto, preco, quantidadeEstoque, categoria, marca, imagemProduto, fichaTecnica);
            IDProduto = idProduto;
        }
    }
}
