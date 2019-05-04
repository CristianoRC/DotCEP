using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TesteEndereco
    {
        private Endereco enderecoBase;

        [TestMethod]
        public void TesteConsultaEnderecoCompletoValido()
        {
            var servicos = new ServicoEnderecos();

            enderecoBase = servicos.ObterEndereco(new CEP("96085000"));

            Assert.AreEqual("Pelotas", enderecoBase.Localidade);
            Assert.AreEqual("Areal", enderecoBase.Bairro);
            Assert.AreEqual("Avenida Ferreira Viana", enderecoBase.Logradouro);
        }


        [TestMethod]
        public void TesteConsultaEnderecoCompletoInvalido()
        {
            var servicos = new ServicoEnderecos();

            enderecoBase = servicos.ObterEndereco(new CEP("960850000"));

            Assert.IsNull(enderecoBase.Localidade);
            Assert.IsNull(enderecoBase.Bairro);
            Assert.IsNull(enderecoBase.Logradouro);
        }

        [TestMethod]
        public void TesteConsultaEnderecoCompletoValidoComString()
        {
            var servicos = new ServicoEnderecos();

            enderecoBase = servicos.ObterEndereco("96085000");

            Assert.AreEqual("Pelotas", enderecoBase.Localidade);
            Assert.AreEqual("Areal", enderecoBase.Bairro);
            Assert.AreEqual("Avenida Ferreira Viana", enderecoBase.Logradouro);
        }

        [TestMethod]
        public void TesteConsultaEnderecoCompletoInvalidoComString()
        {
            var servicos = new ServicoEnderecos();

            enderecoBase = servicos.ObterEndereco("960850000");

            Assert.IsNull(enderecoBase.Localidade);
            Assert.IsNull(enderecoBase.Bairro);
            Assert.IsNull(enderecoBase.Logradouro);
        }

        [TestMethod]
        public void TesteConsultaListaEnderecos()
        {
            var servicos = new ServicoEnderecos();

            var listaEnderecos = servicos.Buscar(UF.RS, "Pelotas", "Ferreira");

            Assert.AreEqual(11, listaEnderecos.ToList().Count);
        }

        [TestMethod]
        public void TesteConsultaListaInvalidos()
        {
            var servicos = new ServicoEnderecos();

            var listaEnderecos = servicos.Buscar(UF.RS, "Test", "Ferreira");

            Assert.AreEqual(0, listaEnderecos.ToList().Count);
        }
    }
}