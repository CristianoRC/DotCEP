using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TesteEndereco
    {

        private DotCEP.Endereco enderecoBase;

        [TestMethod]
        public void TestConsultaEnderecoCompletoValido()
        {
            enderecoBase = DotCEP.Consultas.ObterEnderecoCompleto("96085000");

            Assert.AreEqual("Pelotas", enderecoBase.localidade);
            Assert.AreEqual("Areal", enderecoBase.bairro);
            Assert.AreEqual("Avenida Ferreira Viana", enderecoBase.logradouro);

        }

        [TestMethod]
        public void TestConsultaEnderecoCompletoInvalido()
        {
            enderecoBase = DotCEP.Consultas.ObterEnderecoCompleto("960850000");

            Assert.IsNull(enderecoBase.localidade);
            Assert.IsNull(enderecoBase.bairro);
            Assert.IsNull(enderecoBase.logradouro);
        }

        [TestMethod]
        public void TestConsultaListaEnderecos()
        {
            System.Collections.Generic.List<Endereco> listaEnderecos = DotCEP.Consultas.ObterListaDeEnderecos(UF.RS, "Pelotas", "Ferreira");

            Assert.AreEqual(11, listaEnderecos.Count);
        }


        [TestCleanup]
        public void ApagarCache()
        {
            //TODO: Reparar o sistema de apagar o Cache

            /*
            Spartacus.Database.Generic database = new Spartacus.Database.Sqlite(ObterCaminhoBancoCache());
            Spartacus.Database.Command cmd = new Spartacus.Database.Command();

            cmd.v_text = "Delete from Cache";
            database.Execute(cmd.GetUpdatedText());

            cmd.v_text = "Delete from ConsultaEndereco";
            database.Execute(cmd.GetUpdatedText());*/
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
