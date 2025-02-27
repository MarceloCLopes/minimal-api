using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Dominio.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }

        [TestMethod]
        public void TestandoSalvarAdministrador()
        {
            // Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var administradorServico = new AdministradorServico(context);

            // Act
            administradorServico.Incluir(adm);

            // Assert
            Assert.AreEqual(1, administradorServico.Todos(1).Count);
        }

        //[TestMethod]
        // public void TestantoBuscaPorId()
        // {
        //     // Arrange
        //     var context = CriarContextoDeTeste();
        //     context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        //     var adm = new Administrador
        //     {
        //         Email = "test@teste.com",
        //         Senha = "123456",
        //         Perfil = "Adm"
        //     };
        //     var administradorServico = new AdministradorServico(context);

        //     // Act          
        //     var admDoBanco = administradorServico.BuscaPorId(adm.Id);

        //     // Assert
        //     Assert.AreEqual(1, admDoBanco?.Id);
        // }
    }
}