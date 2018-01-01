using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TestUF
    {
        [TestMethod]
        public void TestSiglaEstado()
        {
            Assert.AreEqual("RS", UF.RS.ToString());
        }

        [TestMethod]
        public void TestCodigoEstado()
        {
            int codigoEstado = (int)UF.RS;

            Assert.AreEqual(43, codigoEstado);
        }
    }
}
