using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TestEstado
    {
        [TestMethod]
        public void TestObtendoCodigoDoEstadoAtravesDaSigla()
        {
            String Resultado = DotCEP.Localidades.Estado.ObterCodigoDoEstado("rs");

            Assert.AreEqual("43", Resultado);
        }

        [TestMethod]
        public void TestObtendoCodigoDoEstadoAtravesDoNome()
        {
            String Resultado = DotCEP.Localidades.Estado.ObterCodigoDoEstado("Rio Grande do Sul");

            Assert.AreEqual("43", Resultado);
        }

        [TestMethod]
        public void TestObtendoNomeDoEstadoAtravesDaSigla()
        {
            String Resultado = DotCEP.Localidades.Estado.ObterNomeDoEstado("RS");

            Assert.AreEqual("Rio Grande do Sul", Resultado);
        }


        [TestMethod]
        public void TestObtendoNomeDoEstadoAtravesDoID()
        {
            String Resultado = DotCEP.Localidades.Estado.ObterNomeDoEstado(43);

            Assert.AreEqual("Rio Grande do Sul", Resultado);
        }

        [TestMethod]
        public void TestObtendoSiglaDoEstadoAtravesDoID()
        {
            String Resultado = DotCEP.Localidades.Estado.ObterSiglaDoEstado(43);

            Assert.AreEqual("RS", Resultado);
        }

        [TestMethod]
        public void TestObtendoSiglaDoEstadoAtravesDoNome()
        {
            String Resultado = DotCEP.Localidades.Estado.ObterSiglaDoEstado("Rio Grande do Sul");

            Assert.AreEqual("RS", Resultado);
        }

        [TestMethod]
        public void TestListaDeEstados()
        {
            int NumeroDeResultados = DotCEP.Localidades.Estado.ObterListaDeEstados().Count;
            DotCEP.Localidades.Estado EstadoNumeroZero = DotCEP.Localidades.Estado.ObterListaDeEstados()[0];

            Assert.AreEqual(12, EstadoNumeroZero.Codigo);
            Assert.AreEqual("AC", EstadoNumeroZero.Sigla);
            Assert.AreEqual("Acre", EstadoNumeroZero.Nome);
            Assert.AreEqual(27, NumeroDeResultados);
        }
    }
}
