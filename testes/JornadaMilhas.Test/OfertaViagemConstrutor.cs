using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-10", 0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-05-22", "2024-05-24", 100, true)]
        [InlineData(null, "Bahia", "2024-05-22", "2024-05-30", -50, false)]
        [InlineData("Recife", "Rio de Janeiro", "2024-01-01", "2024-01-15", 0, false)]
        public void RetornaOfertaValidaQuandoDadosValidos(string origem, string destino, string dataIda, 
            string dataVolta, double preco, bool validacao)
        {
            //TESTE PADRÃO AAA
            //Cenário - ARRANGE
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));           

            //Ação - ACT
            JornadaMilhasV1.Modelos.OfertaViagem oferta = new JornadaMilhasV1.Modelos.OfertaViagem(rota, periodo, preco);

            //Validação - ASSERT
            Assert.Equal(validacao, oferta.EhValido);
        }
        
        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 5, 22), new DateTime(2024, 5, 24));
            double preco = 100.0;

            JornadaMilhasV1.Modelos.OfertaViagem oferta = new JornadaMilhasV1.Modelos.OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válido.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemdeDeDataInvalidaQuandoDataInicialMaiorQueDataFinal()
        {
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 5, 30), new DateTime(2024, 5, 01));
            double preco = 100.0;

            JornadaMilhasV1.Modelos.OfertaViagem oferta = new JornadaMilhasV1.Modelos.OfertaViagem(rota, periodo, preco);

            Assert.Contains("Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(periodo.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoMenorQueZero()
        {
            //Arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 06, 01), new DateTime(2024, 06, 21));
            double preco = -50;

            //Act
            JornadaMilhasV1.Modelos.OfertaViagem oferta = new JornadaMilhasV1.Modelos.OfertaViagem(rota, periodo, preco);

            //Assert
            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
        }
    }
}