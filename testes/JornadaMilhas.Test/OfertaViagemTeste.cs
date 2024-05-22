using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemTeste
    {
        [Fact]
        public void TestandoOfertaValida()
        {
            //TESTE PADR�O AAA
            //Cen�rio - ARRANGE
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 5, 22), new DateTime(2024, 5, 24));
            double preco = 100.0;
            var validacao = true;

            //A��o - ACT
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //Valida��o - ASSERT
            Assert.Equal(validacao, oferta.EhValido);
        }
        
        [Fact]
        public void TestandoOfertaComRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 5, 22), new DateTime(2024, 5, 24));
            double preco = 100.0;            

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }
    }
}