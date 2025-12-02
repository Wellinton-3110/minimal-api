using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Servicos

{
    [TestClass]
    public class AdministradorServicoTeste
    {
        private DbContexto CriarContextoTeste()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..",".."));
            var builder = new ConfigurationBuilder()
                .SetBasePath(path ?? Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            var configuration = builder.Build();

            return new DbContexto(configuration);
        }



        [TestMethod]

        public void TestandoSalvarAdm()
          {
            var context = CriarContextoTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");
            //Arrange
            var adm = new Administrador();
            adm.Email = "administrador@teste.com";
            adm.Senha = "1234";
            adm.Perfil = "Adm";
            var administradorServico = new AdministradorServico(context);

            //Act
            administradorServico.Incluir(adm);
            administradorServico.BuscaPorId(adm.Id);

            //Assert
            Assert.AreEqual(1,administradorServico.Todos(1).Count());
            


          }
    }
}