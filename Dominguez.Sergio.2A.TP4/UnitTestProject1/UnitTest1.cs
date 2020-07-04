using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Paquete p1 = new Paquete("calle 1", "123-233-888");

            bool valid = PaqueteDAO.insertar(p1);

            Assert.IsTrue(valid);
            
        }
    }
}
