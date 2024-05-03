﻿// Interface IItemCarrinhoService
using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface IItemCarrinhoService
    {
        Task<IEnumerable<ItemCarrinho>> ObterTodosItensCarrinho();
        Task<ItemCarrinho> ObterItemCarrinhoPorId(int id);
        Task<int> AdicionarItemCarrinho(ItemCarrinho itemCarrinho); // Adicionado o método AdicionarItemCarrinho
        Task AtualizarItemCarrinho(ItemCarrinho itemCarrinho);
        Task HabilitarItemCarrinho(int id);
        Task DesabilitarItemCarrinho(int id);
    }
}

