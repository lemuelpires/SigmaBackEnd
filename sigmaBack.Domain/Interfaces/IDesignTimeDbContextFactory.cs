using Microsoft.EntityFrameworkCore;
using sigmaBack.Domain.Entities;

namespace sigmaBack.Infra.Data.Contexts
{
    public class SigmaDbContext : DbContext
    {
        public SigmaDbContext(DbContextOptions<SigmaDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<CarrinhoCompra> CarrinhosCompras { get; set; }
        public DbSet<ItemCarrinho> ItensCarrinhos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações específicas do modelo podem ser adicionadas aqui
            // Por exemplo, configurações de chaves estrangeiras, índices, etc.
        }
    }
}
