using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)] // Oferta Inv�lida
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)] // Oferta V�lida
        [InlineData(null, "S�o Paulo", "2824-01-01", "2024-01-01", 0, false)]
        [InlineData("Vit�ria", "S�o Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "S�o Paulo", "2024-01-01", "2024-01-02", -500, false)]
        public void RetornaIsValidDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
        {
            // Arrange (Cen�rio)
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            // Act (A��o)
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Assert (Valida��o)
            Assert.Equal(validacao, oferta.isValid);
        }

        [Fact]
        public void RetornaMsgErroRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            // Arrange
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;

            // Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Assert
            Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
            Assert.False(oferta.isValid);
        }

        [Fact]
        public void RetornaMsgErroPeriodoInvalidoQuandoPeriodoNull()
        {
            // Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(null, null);
            double preco = 100.0;

            // Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Assert
            Assert.Contains("Erro: Per�odo de viagem inv�lido.", oferta.Erros.Sumario);
            Assert.False(oferta.isValid);
        }

        [Fact]
        public void RetornaMsgErroPeriodoInvalidoQuandoPeriodoInvalido()
        {
            // Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 5), new DateTime(2024, 2, 1));
            double preco = 100.0;

            // Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Assert
            Assert.Contains("Erro: Data de ida n�o pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(oferta.isValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-250)]
        public void RetornaMsgDeErroPrecoInvalidoDeAcordoComPrecoInformado(double preco)
        {
            // Arrange
            Rota rota = new Rota("Origen1", "Destino1");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));

            // Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Assert
            Assert.Contains("O pre�o da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }

        [Fact]
        public void RetornaTresErrosDeValidacaoQuandoRotaPeriodoEPRecoSaoInvalidos()
        {
            //arrange
            int quantidadeEsperada = 3;
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 6, 1), new DateTime(2024, 5, 10));
            double preco = -100;

            //act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //assert
            Assert.Equal(quantidadeEsperada, oferta.Erros.Count());
        }
    }
}