using System.Linq;
using DotCEP.Localidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TestMunicipio
    {
        [TestMethod]
        public void TestObtendoCodigoDoMunicipioUF()
        {
            var Resultado = new Municipio("Pelotas", UF.RS).Codigo;

            Assert.AreEqual((uint) 4314407, Resultado);
        }


        [TestMethod]
        public void TestObtendoCodigoDoMunicipioNomeEstado()
        {
            var Resultado = new Municipio("Pelotas", "Rio Grande do Sul").Codigo;

            Assert.AreEqual((uint) 4314407, Resultado);
        }
        //TODO: Implementar busca do município com a sigla do estado
        //TODO: Implementar busca do município com o código do estado


        [TestMethod]
        public void TestObtendoInformacoesDoMunicipioCodigo()
        {
            var informacoesMunicipio = new Municipio(4314407);

            Assert.AreEqual((uint) 4314407, informacoesMunicipio.Codigo);
            Assert.AreEqual(43, (byte) informacoesMunicipio.Estado);
            Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
        }


        [TestMethod]
        public void TestObtendoInformacoesDoMunicipioUF()
        {
            var informacoesMunicipio = new Municipio("Pelotas", UF.RS);

            Assert.AreEqual((uint) 4314407, informacoesMunicipio.Codigo);
            Assert.AreEqual(43, (byte) informacoesMunicipio.Estado);
            Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
        }


        [TestMethod]
        public void TestObtendoInformacoesDoMunicipioNomeEstado()
        {
            var informacoesMunicipio = new Municipio("Pelotas", "Rio Grande do Sul");

            Assert.AreEqual((uint) 4314407, informacoesMunicipio.Codigo);
            Assert.AreEqual(43, (byte) informacoesMunicipio.Estado);
            Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
        }


        [TestMethod]
        public void TestObtendoNomeDoMunicipio()
        {
            var resultado = new Municipio(4314407).Nome;

            Assert.AreEqual("Pelotas", resultado);
        }

        [TestMethod]
        public void TestListaDeTodosMunicipios()
        {
            var numeroDeTodosRegistros = Municipio.ListarTodos().Count();
            Assert.AreEqual(5570, numeroDeTodosRegistros);
        }


        [TestMethod]
        public void TestListaDeMunicipiosPorUF()
        {
            var numeroDeTodosRegistrosDoRS = Municipio.ListarPorEstado(UF.RS).Count();
            Assert.AreEqual(497, numeroDeTodosRegistrosDoRS);
        }

        [TestMethod]
        public void TestListaDeMunicipiosPorEstado()
        {
            var numeroDeTodosRegistrosDoRS = Municipio.ListarPorEstado("São Paulo").Count();
            Assert.AreEqual(645, numeroDeTodosRegistrosDoRS);
        }
    }
}