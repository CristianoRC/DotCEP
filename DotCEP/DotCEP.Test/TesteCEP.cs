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
            cep.Formatar();
            Assert.AreEqual("96085-000", cep.Valor);
        }

        [TestMethod]
        public void TestCepFormatadoErrado()
        {
            var cep = new DotCEP.CEP("96-085 000");
            cep.Formatar();
            Assert.AreEqual("96085-000", cep.Valor);
        }

        [TestMethod]
        [DataRow("960850*00")]
        [DataRow("96085=000")]
        public void TestFormatacaoNaoValido(String CEPparaVerificar)
        {
            var saida = false;
            try
            {
                var cep = new DotCEP.CEP(CEPparaVerificar);
                cep.Formatar();
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
        public void TestVerificacaoCEPValido(String valor)
        {
            var cep = new DotCEP.CEP(valor);
            Assert.AreEqual(true, cep.Valido);
        }

        [TestMethod]
        [DataRow("960850-00")]
        [DataRow("960850000")]
        public void TestVerificacaoCEPInvalido(String valor)
        {
            var cep = new DotCEP.CEP(valor);
            Assert.AreEqual(false, cep.Valido);
        }

        [TestMethod]
        public void TestVerificacaoDeCEPExistente()
        {
            var resultadoDaExistencia = new DotCEP.CEP("96085100").VerificarExistencia();
            Assert.AreEqual(true, resultadoDaExistencia);
        }

        [TestMethod]
        public void TestVerificacaoDeCEPInexistente()
        {
            var resultadoDaExistencia = new DotCEP.CEP("960850000").VerificarExistencia();
            Assert.AreEqual(false, resultadoDaExistencia);
        }

        [TestCleanup]
        public void ApagarCache()
        {
            //TODO: Atualziar após a refatoração do sistema de cache.
        }
    }
}