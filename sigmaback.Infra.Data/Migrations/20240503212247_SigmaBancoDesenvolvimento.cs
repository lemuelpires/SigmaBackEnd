using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sigmaback.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SigmaBancoDesenvolvimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    IDCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCategoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IDCategoriaPai = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.IDCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    IDProduto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeEstoque = table.Column<int>(type: "int", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagemProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FichaTecnica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.IDProduto);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IDUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IDUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    IDAvaliacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Classificacao = table.Column<int>(type: "int", nullable: false),
                    DataAvaliacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ProdutoIDProduto = table.Column<int>(type: "int", nullable: true),
                    UsuarioIDUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.IDAvaliacao);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Produtos_ProdutoIDProduto",
                        column: x => x.ProdutoIDProduto,
                        principalTable: "Produtos",
                        principalColumn: "IDProduto");
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Usuarios_UsuarioIDUsuario",
                        column: x => x.UsuarioIDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario");
                });

            migrationBuilder.CreateTable(
                name: "CarrinhosCompras",
                columns: table => new
                {
                    IDCarrinho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    DataHoraCriacaoCarrinho = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioIDUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhosCompras", x => x.IDCarrinho);
                    table.ForeignKey(
                        name: "FK_CarrinhosCompras_Usuarios_UsuarioIDUsuario",
                        column: x => x.UsuarioIDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    IDEndereco = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioIDUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.IDEndereco);
                    table.ForeignKey(
                        name: "FK_Enderecos_Usuarios_UsuarioIDUsuario",
                        column: x => x.UsuarioIDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IDPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    DataPedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusPedido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPedido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DetalhesEnvio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioIDUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IDPedido);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_UsuarioIDUsuario",
                        column: x => x.UsuarioIDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario");
                });

            migrationBuilder.CreateTable(
                name: "ItensCarrinhos",
                columns: table => new
                {
                    IDItemCarrinho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCarrinho = table.Column<int>(type: "int", nullable: false),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    URLImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CarrinhoCompraIDCarrinho = table.Column<int>(type: "int", nullable: true),
                    ProdutoIDProduto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensCarrinhos", x => x.IDItemCarrinho);
                    table.ForeignKey(
                        name: "FK_ItensCarrinhos_CarrinhosCompras_CarrinhoCompraIDCarrinho",
                        column: x => x.CarrinhoCompraIDCarrinho,
                        principalTable: "CarrinhosCompras",
                        principalColumn: "IDCarrinho");
                    table.ForeignKey(
                        name: "FK_ItensCarrinhos_Produtos_ProdutoIDProduto",
                        column: x => x.ProdutoIDProduto,
                        principalTable: "Produtos",
                        principalColumn: "IDProduto");
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    IDPedido = table.Column<int>(type: "int", nullable: false),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    IDItemPedido = table.Column<int>(type: "int", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    URLImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescricaoProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => new { x.IDPedido, x.IDProduto });
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_IDPedido",
                        column: x => x.IDPedido,
                        principalTable: "Pedidos",
                        principalColumn: "IDPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Produtos_IDProduto",
                        column: x => x.IDProduto,
                        principalTable: "Produtos",
                        principalColumn: "IDProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ProdutoIDProduto",
                table: "Avaliacoes",
                column: "ProdutoIDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_UsuarioIDUsuario",
                table: "Avaliacoes",
                column: "UsuarioIDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhosCompras_UsuarioIDUsuario",
                table: "CarrinhosCompras",
                column: "UsuarioIDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_UsuarioIDUsuario",
                table: "Enderecos",
                column: "UsuarioIDUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinhos_CarrinhoCompraIDCarrinho",
                table: "ItensCarrinhos",
                column: "CarrinhoCompraIDCarrinho");

            migrationBuilder.CreateIndex(
                name: "IX_ItensCarrinhos_ProdutoIDProduto",
                table: "ItensCarrinhos",
                column: "ProdutoIDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_IDProduto",
                table: "ItensPedidos",
                column: "IDProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioIDUsuario",
                table: "Pedidos",
                column: "UsuarioIDUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "ItensCarrinhos");

            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "CarrinhosCompras");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
