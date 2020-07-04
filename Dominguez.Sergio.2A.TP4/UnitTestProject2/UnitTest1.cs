using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PriuebaIngresoPaquete()
        {
            Paquete p1 = new Paquete("calle 1", "123-233-888");

            bool valid = PaqueteDAO.insertar(p1);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void PruebaGuardaTexto()
        {
            string texto = "prueba 3";

            texto.Guardar("file.txt");


        }

        [TestMethod]
        public void ListaPaquetesOK()
        {
            Correo c1 = new Correo();

            Assert.IsNotNull(c1.Paquetes);

        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void RepetirTrackingIdNotOk()
        {
            //arrange
            string id = "1";
            string direccion1 = "Juarez 222";
            string direccion2 = "Patricios 562";

            Paquete p1 = new Paquete(direccion1, id);
            Paquete p2 = new Paquete(direccion2, id);

            Correo c1 = new Correo();

            //Act
            c1 += p1;
            c1 += p2;
            
        }
    }
}
