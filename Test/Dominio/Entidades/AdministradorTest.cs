using minimal_api.Dominio.Entidades;

namespace Test.Dominio.Entidades
{
    [TestClass]
    public class AdministradorTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            // Arrange
            var adm = new Administrador
            {
                // Act
                Id = 1,
                Email = "test@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            };

            // Assert
            Assert.AreEqual(1, adm.Id);
            Assert.AreEqual("test@teste.com", adm.Email);
            Assert.AreEqual("123456", adm.Senha);
            Assert.AreEqual("Adm", adm.Perfil);
        }
    }
}