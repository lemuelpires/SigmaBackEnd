using sigmaBack.Domain.Entities;
using SigmaBack.Domain.Interfaces;

namespace sigmaBack.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository ?? throw new ArgumentNullException(nameof(categoriaRepository));
        }

        public async Task<IEnumerable<Categoria>> ObterTodasCategorias()
        {
            return await _categoriaRepository.ObterTodasCategorias();
        }

        public async Task<Categoria> ObterCategoriaPorId(int id)
        {
            return await _categoriaRepository.ObterCategoriaPorId(id);
        }

        public async Task<int> CriarNovaCategoria(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            return await _categoriaRepository.CriarNovaCategoria(categoria);
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            if (categoria == null)
            {
                throw new ArgumentNullException(nameof(categoria));
            }

            await _categoriaRepository.AtualizarCategoria(categoria);
        }

        public async Task DesabilitarCategoria(int id)
        {
            await _categoriaRepository.DesabilitarCategoria(id);
        }

        public async Task HabilitarCategoria(int id)
        {
            await _categoriaRepository.HabilitarCategoria(id);
        }
    }
}
