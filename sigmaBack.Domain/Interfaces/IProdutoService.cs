﻿using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ObterTodosProdutos();
        Task<Produto> ObterProdutoPorId(int id);
        Task<IEnumerable<Produto>> ObterProdutosPorCategoria(string categoria);
        Task<IEnumerable<Produto>> ObterProdutosPorPreco(decimal precoMin, decimal precoMax);
        Task<IEnumerable<Produto>> ObterProdutosEmEstoque();
        Task<IEnumerable<Produto>> PesquisarProdutos(string termoPesquisa);
        Task InserirProduto(Produto produto);
        Task AtualizarProduto(Produto produto);
        Task HabilitarProduto(int id);
        Task DesabilitarProduto(int id);
        Task AplicarDescontoPromocional(int idProduto, decimal percentualDesconto);
        Task VerificarDisponibilidadeEstoque(int idProduto, int quantidadeDesejada);
        Task AtualizarImagemProduto(int idProduto, string imagemProduto);
    }
}
