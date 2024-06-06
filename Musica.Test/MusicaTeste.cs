namespace JornadaMilhas.Test
{
    public class Musica
    {
        public Musica(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; }

        [Fact]
        public void TesteNomeInicializadoCorretamente()
        {
            // Arrange
            string nome = "Música Teste";

            // Act
            Musica musica = new Musica(nome);

            // Assert
            Assert.Equal(nome, musica.Nome);
        }
    }
}