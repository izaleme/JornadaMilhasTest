using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)] // Oferta Inválida
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)] // Oferta Válida
        [InlineData(null, "São Paulo", "2824-01-01", "2024-01-01", 0, false)]
        [InlineData("Vitória", "São Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "São Paulo", "2024-01-01", "2024-01-02", -500, false)]
        public void RetornaIsValidDeAcordoComDadosDeEntrada(string origem, string destino, string dataIda, string dataVolta, double preco, bool validacao)
        {
            // Arrange (Cenário)
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            // Act (Ação)
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Assert (Validação)
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
            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
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
            Assert.Contains("Erro: Período de viagem inválido.", oferta.Erros.Sumario);
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
            Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);
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
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
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