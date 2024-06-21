using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQuandoDadosValidos()
        {
            // Scenario --> Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;
            var validacao = true;

            // Action --> Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Validation --> Assert
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

        [Fact]
        public void RetornaMsgDeErroPrecoInvalidoQuandoPrecoNegativo()
        {
            // Arrange
            Rota rota = new Rota("Origen1", "Destino1");
            Periodo periodo = new Periodo(new DateTime(2024, 8, 20), new DateTime(2024, 8, 30));
            double preco = -250;

            // Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }

    }
}