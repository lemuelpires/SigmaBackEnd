﻿using System.Collections.Generic;
using System.Threading.Tasks;
using sigmaBack.Domain.Entities;

namespace SigmaBack.Domain.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ObterTodasCategorias();
        Task<Categoria> ObterCategoriaPorId(int id);
        Task<int> CriarNovaCategoria(Categoria categoria);
        Task AtualizarCategoria(Categoria categoria);
        Task RemoverCategoria(int id);
    }
}
