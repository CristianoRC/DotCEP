using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TestValidacao
    {
        [TestMethod]
        [DataRow("96085-000")]
        [DataRow("96085000")]
        public void TestVerificacaoCEPValido(String CepTeste)
        {
            Boolean resultadoValidacao = DotCEP.Validacoes.VerificarValidadeDoCep(CepTeste);
            Assert.AreEqual(true, resultadoValidacao);
        }

        [TestMethod]
        [DataRow("960850-00")]
        [DataRow("960850000")]
        public void TestVerificacaoCEPInvalido(String CepTeste)
        {
            bool ResultadoValidacao = DotCEP.Validacoes.VerificarValidadeDoCep(CepTeste);
            Assert.AreEqual(false, ResultadoValidacao);
        }

        [TestMethod]
        public void TestVerificacaoDeCEPExistente()
        {
            bool resultadoDaExistencia = DotCEP.Validacoes.VerificarExistenciaDoCEP("96085100");
            Assert.AreEqual(true, resultadoDaExistencia);
        }

        [TestMethod]
        public void TestVerificacaoDeCEPInexistente()
        {
            bool resultadoDaExistencia = DotCEP.Validacoes.VerificarExistenciaDoCEP("960850000");
            Assert.AreEqual(false, resultadoDaExistencia);
        }

        [TestCleanup]
        public void ApagarCache()
        {
            //TODO: Reparar o sistema de apagar o Cache
            /*
            Spartacus.Database.Generic database = new Spartacus.Database.Sqlite(ObterCaminhoBancoCache());
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "Delete from Cache";
            database.Execute(cmd.GetUpdatedText()); */
        }

        private static string ObterCaminhoBancoCache()
        {
            if (((int)Environment.OSVersion.Platform) < 4)
            {
                return string.Format(@"{0}\\Cache\\Cache.db", System.AppDomain.CurrentDomain.BaseDirectory); // Windows
            }
            else
            {
                return String.Format(@"{0}/Cache/Cache.db", System.AppDomain.CurrentDomain.BaseDirectory); // Linux e MacOSX
            }
        }
    }
}
