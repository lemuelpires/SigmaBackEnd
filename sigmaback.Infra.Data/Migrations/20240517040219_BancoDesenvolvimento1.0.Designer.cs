﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sigmaBack.Infra.Data.Contexts;

#nullable disable

namespace sigmaback.Infra.Data.Migrations
{
    [DbContext(typeof(SigmaDbContext))]
    [Migration("20240517040219_BancoDesenvolvimento1.0")]
    partial class BancoDesenvolvimento10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sigmaBack.Domain.Entities.Anuncio", b =>
                {
                    b.Property<int>("IDAnuncio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDAnuncio"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDProduto")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReferenciaImagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDAnuncio");

                    b.ToTable("Anuncios");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Avaliacao", b =>
                {
                    b.Property<int>("IDAvaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDAvaliacao"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("Classificacao")
                        .HasColumnType("int");

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAvaliacao")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDProduto")
                        .HasColumnType("int");

                    b.Property<int>("IDUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoIDProduto")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioIDUsuario")
                        .HasColumnType("int");

                    b.HasKey("IDAvaliacao");

                    b.HasIndex("ProdutoIDProduto");

                    b.HasIndex("UsuarioIDUsuario");

                    b.ToTable("Avaliacoes");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.CarrinhoCompra", b =>
                {
                    b.Property<int>("IDCarrinho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCarrinho"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataHoraCriacaoCarrinho")
                        .HasColumnType("datetime2");

                    b.Property<int>("IDUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioIDUsuario")
                        .HasColumnType("int");

                    b.HasKey("IDCarrinho");

                    b.HasIndex("UsuarioIDUsuario");

                    b.ToTable("CarrinhosCompras");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("IDCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDCategoria"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("IDCategoriaPai")
                        .HasColumnType("int");

                    b.Property<string>("NomeCategoria")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDCategoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Endereco", b =>
                {
                    b.Property<int>("IDEndereco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDEndereco"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDUsuario")
                        .HasColumnType("int");

                    b.Property<string>("Pais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioIDUsuario")
                        .HasColumnType("int");

                    b.HasKey("IDEndereco");

                    b.HasIndex("UsuarioIDUsuario");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Favorito", b =>
                {
                    b.Property<int>("IDFavorito")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDFavorito"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("IDProduto")
                        .HasColumnType("int");

                    b.Property<int>("IDUsuario")
                        .HasColumnType("int");

                    b.Property<string>("ImagemProduto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDFavorito");

                    b.ToTable("Favoritos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.ItemCarrinho", b =>
                {
                    b.Property<int>("IDItemCarrinho")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDItemCarrinho"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int?>("CarrinhoCompraIDCarrinho")
                        .HasColumnType("int");

                    b.Property<string>("DescricaoProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDCarrinho")
                        .HasColumnType("int");

                    b.Property<int>("IDProduto")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProdutoIDProduto")
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("URLImagem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDItemCarrinho");

                    b.HasIndex("CarrinhoCompraIDCarrinho");

                    b.HasIndex("ProdutoIDProduto");

                    b.ToTable("ItensCarrinhos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.ItemPedido", b =>
                {
                    b.Property<int>("IDPedido")
                        .HasColumnType("int");

                    b.Property<int>("IDProduto")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("DescricaoProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDItemPedido")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("URLImagem")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDPedido", "IDProduto");

                    b.HasIndex("IDProduto");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Jogo", b =>
                {
                    b.Property<int>("IDJogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDJogo"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CategoriaJogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("EspacoDiscoRequerido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemoriaRAMRequerida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeJogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlacaVideoRequerida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcessadorRequerido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferenciaImagemJogo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDJogo");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Pedido", b =>
                {
                    b.Property<int>("IDPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDPedido"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("datetime2");

                    b.Property<string>("DetalhesEnvio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnderecoEntrega")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDUsuario")
                        .HasColumnType("int");

                    b.Property<string>("MetodoPagamento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StatusPedido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalPedido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("UsuarioIDUsuario")
                        .HasColumnType("int");

                    b.HasKey("IDPedido");

                    b.HasIndex("UsuarioIDUsuario");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Produto", b =>
                {
                    b.Property<int>("IDProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDProduto"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Categoria")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescricaoProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FichaTecnica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagemProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeProduto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantidadeEstoque")
                        .HasColumnType("int");

                    b.HasKey("IDProduto");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("IDUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDUsuario"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.UsuarioJogo", b =>
                {
                    b.Property<int>("IDAssociacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IDAssociacao"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<int>("IDJogo")
                        .HasColumnType("int");

                    b.Property<int>("IDUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("JogoIDJogo")
                        .HasColumnType("int");

                    b.Property<string>("ReferenciaImagemJogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UsuarioIDUsuario")
                        .HasColumnType("int");

                    b.HasKey("IDAssociacao");

                    b.HasIndex("JogoIDJogo");

                    b.HasIndex("UsuarioIDUsuario");

                    b.ToTable("UsuarioJogos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Avaliacao", b =>
                {
                    b.HasOne("sigmaBack.Domain.Entities.Produto", null)
                        .WithMany("Avaliacoes")
                        .HasForeignKey("ProdutoIDProduto");

                    b.HasOne("sigmaBack.Domain.Entities.Usuario", null)
                        .WithMany("Avaliacoes")
                        .HasForeignKey("UsuarioIDUsuario");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.CarrinhoCompra", b =>
                {
                    b.HasOne("sigmaBack.Domain.Entities.Usuario", "Usuario")
                        .WithMany("CarrinhosCompras")
                        .HasForeignKey("UsuarioIDUsuario");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Endereco", b =>
                {
                    b.HasOne("sigmaBack.Domain.Entities.Usuario", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("UsuarioIDUsuario");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.ItemCarrinho", b =>
                {
                    b.HasOne("sigmaBack.Domain.Entities.CarrinhoCompra", null)
                        .WithMany("ItensCarrinho")
                        .HasForeignKey("CarrinhoCompraIDCarrinho");

                    b.HasOne("sigmaBack.Domain.Entities.Produto", null)
                        .WithMany("ItensCarrinho")
                        .HasForeignKey("ProdutoIDProduto");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.ItemPedido", b =>
                {
                    b.HasOne("sigmaBack.Domain.Entities.Pedido", null)
                        .WithMany("ItensPedidos")
                        .HasForeignKey("IDPedido")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sigmaBack.Domain.Entities.Produto", null)
                        .WithMany("ItensPedido")
                        .HasForeignKey("IDProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Pedido", b =>
                {
                    b.HasOne("sigmaBack.Domain.Entities.Usuario", null)
                        .WithMany("Pedidos")
                        .HasForeignKey("UsuarioIDUsuario");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.UsuarioJogo", b =>
                {
                    b.HasOne("sigmaBack.Domain.Entities.Jogo", "Jogo")
                        .WithMany()
                        .HasForeignKey("JogoIDJogo");

                    b.HasOne("sigmaBack.Domain.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioIDUsuario");

                    b.Navigation("Jogo");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.CarrinhoCompra", b =>
                {
                    b.Navigation("ItensCarrinho");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Pedido", b =>
                {
                    b.Navigation("ItensPedidos");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Produto", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("ItensCarrinho");

                    b.Navigation("ItensPedido");
                });

            modelBuilder.Entity("sigmaBack.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Avaliacoes");

                    b.Navigation("CarrinhosCompras");

                    b.Navigation("Enderecos");

                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
