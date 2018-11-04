using System;
using System.Linq;
using DotCEP.Localidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TestEstado
    {

        [TestMethod]
        public void TestObtendoCodigoDoEstadoAtravesDaSigla()
        {
            var Resultado = new Estado("rs").Codigo;

            Assert.AreEqual(43, Resultado);
        }

        [TestMethod]
        public void TestObtendoCodigoDoEstadoAtravesDoNome()
        {
            var Resultado = new Estado("Rio Grande do Sul").Codigo;

            Assert.AreEqual(43, Resultado);
        }

        [TestMethod]
        public void TestObtendoNomeDoEstadoAtravesDaSigla()
        {
            string Resultado = new Estado("RS").Nome;

            Assert.AreEqual("Rio Grande do Sul", Resultado);
        }


        [TestMethod]
        public void TestObtendoNomeDoEstadoAtravesDoID()
        {
            string Resultado = new Estado(43).Nome;

            Assert.AreEqual("Rio Grande do Sul", Resultado);
        }

        [TestMethod]
        public void TestObtendoSiglaDoEstadoAtravesDoID()
        {
            string Resultado = new Estado(43).Sigla;

            Assert.AreEqual("RS", Resultado);
        }

        [TestMethod]
        public void TestObtendoSiglaDoEstadoAtravesDoNome()
        {
            string Resultado = new Estado("Rio Grande do Sul").Sigla;

            Assert.AreEqual("RS", Resultado);
        }

        [TestMethod]
        public void TestListaDeEstados()
        {
            var listaEstados = DotCEP.Localidades.Estado.ObterListaDeEstados().ToList();

            int NumeroDeResultados = listaEstados.Count;
            DotCEP.Localidades.Estado EstadoNumeroZero = listaEstados[0];

            Assert.AreEqual(12, EstadoNumeroZero.Codigo);
            Assert.AreEqual("AC", EstadoNumeroZero.Sigla);
            Assert.AreEqual("Acre", EstadoNumeroZero.Nome);
            Assert.AreEqual(27, NumeroDeResultados);
        }
    }
}
