using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotCEP.Localidades;
using DotCEP.Enumeradores;
using System.Collections.Generic;
using System.Linq;

namespace DotCEP.Test
{
    [TestClass]
    public class TesteEndereco
    {

        private DotCEP.Endereco enderecoBase;

        [TestMethod]
        public void TestConsultaEnderecoCompletoValido()
        {
            enderecoBase = new Endereco("96085000");

            Assert.AreEqual("Pelotas", enderecoBase.Localidade);
            Assert.AreEqual("Areal", enderecoBase.Bairro);
            Assert.AreEqual("Avenida Ferreira Viana", enderecoBase.Logradouro);

        }

        [TestMethod]
        public void TestConsultaEnderecoCompletoInvalido()
        {
            enderecoBase = new Endereco("960850000");

            Assert.IsNull(enderecoBase.Localidade);
            Assert.IsNull(enderecoBase.Bairro);
            Assert.IsNull(enderecoBase.Logradouro);
        }

        [TestMethod]
        public void TestConsultaListaEnderecos()
        {
            IEnumerable<Endereco> listaEnderecos = Endereco.Buscar(UF.RS, "Pelotas", "Ferreira");

            Assert.AreEqual(11, listaEnderecos.ToList().Count);
        }

         [TestMethod]
        public void TestConsultaListaInvalidos()
        {
            IEnumerable<Endereco> listaEnderecos = Endereco.Buscar(UF.RS, "Test", "Ferreira");

            Assert.AreEqual(0, listaEnderecos.ToList().Count);
        }
    }
}
