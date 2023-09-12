using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static IConfiguration _configuration; //permite almacenar toda la conf en el archivo de pruebas, basicamente toda la conf contenido en eel archivo appsettting.JSON

        private static IServiceScopeFactory _scopeFactory; //nos permite crear diverssos servivios dentro del scope actual

        [ClassInitialize]//nos permitie identificar un
                         //metood que contiene codigo que se debe
                         //de implementar antes de que se ejecute cualquiera de clases de la clase de prueba
        public static void Initialize(TestContext _) //siempre tiene que estar este TestConextxt aunque no lo usemos
        { 
            //var builder = new ConfigurationBuilder()

        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
