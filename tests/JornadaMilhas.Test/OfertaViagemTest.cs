using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemTest
    {
        [Fact]
        public void TestandoOfertaValida()
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
        public void TestandoOfertaComRotaNula()
        {
            // Scenario --> Arrange
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.0;

            // Action --> Act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            // Validation --> Assert
            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.isValid);
        }
    }
}