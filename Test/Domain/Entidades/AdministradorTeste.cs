using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades


{
    [TestClass]
    public class AdministradorTeste
    {
        [TestMethod]
        
        public void TestGetSetProps()
          {
            //Arrange
            var adm = new Administrador();

            // Act

            adm.Id = 1;
            adm.Email = "administrador@teste.com";
            adm.Senha = "1234";
            adm.Perfil = "Adm";

            //Assert
            Assert.AreEqual(1,adm.Id);
            Assert.AreEqual("administrador@teste.com",adm.Email);
            Assert.AreEqual("1234",adm.Senha);
            Assert.AreEqual("Adm",adm.Perfil);


          }
        
    }
}