using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TesteCEP
    {

        #region Formatacao
        [TestMethod]
        public void TestFormatacaoComEspacosEmBranco()
        {
            var cep = new DotCEP.CEP("9 6 0 8 5 0 0 0");
            Assert.AreEqual("96085-000", cep.Valor);
        }

        [TestMethod]
        public void TestCepFormatadoErrado()
        {
            var cep = new DotCEP.CEP("96-085 000");
            Assert.AreEqual("96085-000", cep.Valor);
        }

        [TestMethod]
        [DataRow("960850*00")]
        [DataRow("96085=000")]
        public void TestFormatacaoNaoValido(string CEPparaVerificar)
        {
            var saida = false;
            try
            {
                var cep = new DotCEP.CEP(CEPparaVerificar);
            }
            catch
            {
                saida = true;
            }

            Assert.AreEqual(true, saida);
        }

        #endregion

        [TestMethod]
        [DataRow("96085-000")]
        [DataRow("96085000")]
        public void TestVerificacaoCEPValido(string valor)
        {
            var cep = new DotCEP.CEP(valor);
            Assert.AreEqual(true, cep.Valido);
        }

        [TestMethod]
        [DataRow("960850-00")]
        [DataRow("960850000")]
        public void TestVerificacaoCEPInvalido(string valor)
        {
            var cep = new DotCEP.CEP(valor);
            Assert.AreEqual(false, cep.Valido);
        }

        [TestMethod]
        [DataRow("96085100")]
        [DataRow("96085000")]
        public void TestVerificacaoDeCEPExistente(string valor)
        {
            var resultadoDaExistencia = new DotCEP.CEP(valor).VerificarExistencia();
            Assert.AreEqual(true, resultadoDaExistencia);
        }

        [TestMethod]
        [DataRow("960850000")]
        [DataRow("96084100")]
        public void TestVerificacaoDeCEPInexistente(string valor)
        {
            var resultadoDaExistencia = new DotCEP.CEP(valor).VerificarExistencia();
            Assert.AreEqual(false, resultadoDaExistencia);
        }
    }
}