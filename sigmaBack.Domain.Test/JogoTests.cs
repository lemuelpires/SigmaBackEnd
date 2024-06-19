using sigmaBack.Domain.Entities;
using sigmaBack.Domain.Validation;
using Xunit;

namespace sigmaBack.Domain.Test
{
    public class JogoTests
    {
        [Fact]
        public void Jogo_DeveSerCriadoComCamposCorretos()
        {
            // Arrange
            string nomeJogo = "Jogo A";
            string categoriaJogo = "Categoria A";
            string processadorRequerido = "Processador A";
            string memoriaRAMRequerida = "8 GB";
            string placaVideoRequerida = "Placa A";
            string espacoDiscoRequerido = "20 GB";
            string referenciaImagemJogo = "imagem-jogo.jpg";
            DateTime data = DateTime.Now;
            bool ativo = true;

            // Act
            var jogo = new Jogo(nomeJogo, categoriaJogo, processadorRequerido, memoriaRAMRequerida, placaVideoRequerida, espacoDiscoRequerido, referenciaImagemJogo, data, ativo);

            // Assert
            Assert.NotNull(jogo);
            Assert.Equal(nomeJogo, jogo.NomeJogo);
            Assert.Equal(categoriaJogo, jogo.CategoriaJogo);
            Assert.Equal(processadorRequerido, jogo.ProcessadorRequerido);
            Assert.Equal(memoriaRAMRequerida, jogo.MemoriaRAMRequerida);
            Assert.Equal(placaVideoRequerida, jogo.PlacaVideoRequerida);
            Assert.Equal(espacoDiscoRequerido, jogo.EspacoDiscoRequerido);
            Assert.Equal(referenciaImagemJogo, jogo.ReferenciaImagemJogo);
            Assert.Equal(data, jogo.Data);
            Assert.Equal(ativo, jogo.Ativo);
        }

        [Theory]
        [InlineData("", "Categoria A", "Processador A", "8 GB", "Placa A", "20 GB", "imagem-jogo.jpg", "2023-01-01", true)]
        [InlineData("Jogo A", "", "Processador A", "8 GB", "Placa A", "20 GB", "imagem-jogo.jpg", "2023-01-01", true)]
        [InlineData("Jogo A", "Categoria A", "", "8 GB", "Placa A", "20 GB", "imagem-jogo.jpg", "2023-01-01", true)]
        [InlineData("Jogo A", "Categoria A", "Processador A", "", "Placa A", "20 GB", "imagem-jogo.jpg", "2023-01-01", true)]
        [InlineData("Jogo A", "Categoria A", "Processador A", "8 GB", "", "20 GB", "imagem-jogo.jpg", "2023-01-01", true)]
        [InlineData("Jogo A", "Categoria A", "Processador A", "8 GB", "Placa A", "", "imagem-jogo.jpg", "2023-01-01", true)]
        [InlineData("Jogo A", "Categoria A", "Processador A", "8 GB", "Placa A", "20 GB", "", "2023-01-01", true)]
        public void Jogo_ComCampoObrigatorioEmBranco_DeveLancarExcecao(string nomeJogo, string categoriaJogo, string processadorRequerido, string memoriaRAMRequerida, string placaVideoRequerida, string espacoDiscoRequerido, string referenciaImagemJogo, string data, bool ativo)
        {
            // Arrange
            DateTime dataConvertida = DateTime.Parse(data);

            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new Jogo(nomeJogo, categoriaJogo, processadorRequerido, memoriaRAMRequerida, placaVideoRequerida, espacoDiscoRequerido, referenciaImagemJogo, dataConvertida, ativo));
        }

        [Fact]
        public void Jogo_ComNomeJogoComMenosDeTresCaracteres_DeveLancarExcecao()
        {
            // Arrange
            string nomeJogo = "AB";
            string categoriaJogo = "Categoria A";
            string processadorRequerido = "Processador A";
            string memoriaRAMRequerida = "8 GB";
            string placaVideoRequerida = "Placa A";
            string espacoDiscoRequerido = "20 GB";
            string referenciaImagemJogo = "imagem-jogo.jpg";
            DateTime data = DateTime.Now;
            bool ativo = true;

            // Assert
            Assert.Throws<DomainExceptionValidation>(() => new Jogo(nomeJogo, categoriaJogo, processadorRequerido, memoriaRAMRequerida, placaVideoRequerida, espacoDiscoRequerido, referenciaImagemJogo, data, ativo));
        }

        [Fact]
        public void Jogo_Update_ComParametrosValidos_DeveAtualizar()
        {
            // Arrange
            var jogo = new Jogo("Jogo A", "Categoria A", "Processador A", "8 GB", "Placa A", "20 GB", "imagem-jogo.jpg", DateTime.Now, true);

            int idJogo = 2;
            string nomeJogo = "Jogo B";
            string categoriaJogo = "Categoria B";
            string processadorRequerido = "Processador B";
            string memoriaRAMRequerida = "16 GB";
            string placaVideoRequerida = "Placa B";
            string espacoDiscoRequerido = "40 GB";
            string referenciaImagemJogo = "imagem-jogo2.jpg";
            DateTime data = DateTime.Now.AddDays(1);
            bool ativo = false;

            // Act
            jogo.Update(idJogo, nomeJogo, categoriaJogo, processadorRequerido, memoriaRAMRequerida, placaVideoRequerida, espacoDiscoRequerido, referenciaImagemJogo, data, ativo);

            // Assert
            Assert.Equal(idJogo, jogo.IDJogo);
            Assert.Equal(nomeJogo, jogo.NomeJogo);
            Assert.Equal(categoriaJogo, jogo.CategoriaJogo);
            Assert.Equal(processadorRequerido, jogo.ProcessadorRequerido);
            Assert.Equal(memoriaRAMRequerida, jogo.MemoriaRAMRequerida);
            Assert.Equal(placaVideoRequerida, jogo.PlacaVideoRequerida);
            Assert.Equal(espacoDiscoRequerido, jogo.EspacoDiscoRequerido);
            Assert.Equal(referenciaImagemJogo, jogo.ReferenciaImagemJogo);
            Assert.Equal(data, jogo.Data);
            Assert.False(jogo.Ativo);
        }
    }
}
