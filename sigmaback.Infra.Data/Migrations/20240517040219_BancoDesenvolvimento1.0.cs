using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sigmaback.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class BancoDesenvolvimento10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anuncios",
                columns: table => new
                {
                    IDAnuncio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReferenciaImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anuncios", x => x.IDAnuncio);
                });

            migrationBuilder.CreateTable(
                name: "Favoritos",
                columns: table => new
                {
                    IDFavorito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    IDProduto = table.Column<int>(type: "int", nullable: false),
                    ImagemProduto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favoritos", x => x.IDFavorito);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    IDJogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeJogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaJogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessadorRequerido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoriaRAMRequerida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlacaVideoRequerida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EspacoDiscoRequerido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReferenciaImagemJogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.IDJogo);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioJogos",
                columns: table => new
                {
                    IDAssociacao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDUsuario = table.Column<int>(type: "int", nullable: false),
                    IDJogo = table.Column<int>(type: "int", nullable: false),
                    ReferenciaImagemJogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioIDUsuario = table.Column<int>(type: "int", nullable: true),
                    JogoIDJogo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioJogos", x => x.IDAssociacao);
                    table.ForeignKey(
                        name: "FK_UsuarioJogos_Jogos_JogoIDJogo",
                        column: x => x.JogoIDJogo,
                        principalTable: "Jogos",
                        principalColumn: "IDJogo");
                    table.ForeignKey(
                        name: "FK_UsuarioJogos_Usuarios_UsuarioIDUsuario",
                        column: x => x.UsuarioIDUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IDUsuario");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioJogos_JogoIDJogo",
                table: "UsuarioJogos",
                column: "JogoIDJogo");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioJogos_UsuarioIDUsuario",
                table: "UsuarioJogos",
                column: "UsuarioIDUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anuncios");

            migrationBuilder.DropTable(
                name: "Favoritos");

            migrationBuilder.DropTable(
                name: "UsuarioJogos");

            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
