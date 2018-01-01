using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TestFormatacao
    {
        [TestMethod]
        public void TestFormatacaoComEspacosEmBranco()
        {
            String CEPFormatado = DotCEP.Formatacao.FormatarCEP("9 6 0 8 5 0 0 0");

            Assert.AreEqual("96085-000", CEPFormatado);
        }

        [TestMethod]
        public void TestCepFormatadoErrado()
        {
            String CEPFormatado = DotCEP.Formatacao.FormatarCEP("96-085 000");

            Assert.AreEqual("96085-000", CEPFormatado);
        }

        [TestMethod]
        [DataRow("960850000")]
        [DataRow("96085=000")]
        public void TestNaoValido(String CEPparaVerificar)
        {
            String CEPFormatado = DotCEP.Formatacao.FormatarCEP(CEPparaVerificar);

            Assert.AreEqual(string.Empty, CEPFormatado);
        }
    }
}
