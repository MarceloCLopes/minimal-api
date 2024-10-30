using minimal_api.Dominio.Entidades;

namespace Test.Dominio.Entidades
{
    [TestClass]
    public class VeiculoTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            // Arrange
            var veiculo = new Veiculo
            {
                // Act
                Id = 1,
                Nome = "Gol",
                Marca = "Volkswagen",
                Ano = 2020,
            };

            // Assert
            Assert.AreEqual(1, veiculo.Id);
            Assert.AreEqual("Gol", veiculo.Nome);
            Assert.AreEqual("Volkswagen", veiculo.Marca);
            Assert.AreEqual(2020, veiculo.Ano);
        }
    }
}