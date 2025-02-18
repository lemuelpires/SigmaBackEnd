﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<UsuarioJogo> UsuarioJogos { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avaliacao>()
                .HasKey(a => a.IDAvaliacao);

            modelBuilder.Entity<CarrinhoCompra>()
                .HasKey(c => c.IDCarrinho);

            modelBuilder.Entity<Endereco>()
                .HasKey(e => e.IDEndereco);

            modelBuilder.Entity<ItemCarrinho>()
                .HasKey(ic => ic.IDItemCarrinho);

            modelBuilder.Entity<ItemPedido>()
                .HasKey(ip => new { ip.IDPedido, ip.IDProduto });

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.IDPedido);

            modelBuilder.Entity<Produto>()
                .HasKey(p => p.IDProduto);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IDUsuario);

            modelBuilder.Entity<Categoria>()
                .HasKey(u => u.IDCategoria);

            modelBuilder.Entity<Jogo>()
                .HasKey(j => j.IDJogo);

            modelBuilder.Entity<UsuarioJogo>()
                .HasKey(uj => uj.IDAssociacao);

            modelBuilder.Entity<Favorito>()
                .HasKey(f => f.IDFavorito);

            modelBuilder.Entity<Anuncio>()
                .HasKey(an => an.IDAnuncio);

            modelBuilder.Entity<ItemCarrinho>()
                .Property(ic => ic.PrecoUnitario)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ItemPedido>()
                .Property(ip => ip.PrecoUnitario)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Pedido>()
                .Property(p => p.TotalPedido)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Anuncio>()
              .Property(an => an.Preco)
              .HasColumnType("decimal(18,2)");
        }
    }
}
