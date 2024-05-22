using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemTeste
    {
        [Fact]
        public void TestandoOfertaValida()
        {
            //TESTE PADRÃO AAA
            //Cenário - ARRANGE
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 5, 22), new DateTime(2024, 5, 24));
            double preco = 100.0;
            var validacao = true;

            //Ação - ACT
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Validação - ASSERT
            Assert.Equal(validacao, oferta.EhValido);
        }
        
        [Fact]
        public void TestandoOfertaComRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 5, 22), new DateTime(2024, 5, 24));
            double preco = 100.0;            

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }
    }
}