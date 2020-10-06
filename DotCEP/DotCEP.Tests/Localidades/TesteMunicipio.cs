using System.Linq;
using DotCEP.Compartilhado.Enumeradores;
using DotCEP.Localidades;
using Xunit;

namespace DotCEP.Tests.Localidades
{
    public class TesteMunicipio
    {
        [Fact]
        public void TestObtendoCodigoDoMunicipioUf()
        {
            var resultado = new Municipio("Pelotas", UF.RS).Codigo;

            Assert.Equal((uint) 4314407, resultado);
        }


        [Fact]
        public void TestObtendoCodigoDoMunicipioNomeEstado()
        {
            var resultado = new Municipio("Pelotas", "Rio Grande do Sul").Codigo;

            Assert.Equal((uint) 4314407, resultado);
        }
        //TODO: Implementar busca do município com a sigla do estado
        //TODO: Implementar busca do município com o código do estado


        [Fact]
        public void TestObtendoInformacoesDoMunicipioCodigo()
        {
            var informacoesMunicipio = new Municipio(4314407);

            Assert.Equal((uint) 4314407, informacoesMunicipio.Codigo);
            Assert.Equal(43, (byte) informacoesMunicipio.Estado);
            Assert.Equal("Pelotas", informacoesMunicipio.Nome);
        }


        [Fact]
        public void TestObtendoInformacoesDoMunicipioUf()
        {
            var informacoesMunicipio = new Municipio("Pelotas", UF.RS);

            Assert.Equal((uint) 4314407, informacoesMunicipio.Codigo);
            Assert.Equal(43, (byte) informacoesMunicipio.Estado);
            Assert.Equal("Pelotas", informacoesMunicipio.Nome);
        }


        [Fact]
        public void TestObtendoInformacoesDoMunicipioNomeEstado()
        {
            var informacoesMunicipio = new Municipio("Pelotas", "Rio Grande do Sul");

            Assert.Equal((uint) 4314407, informacoesMunicipio.Codigo);
            Assert.Equal(43, (byte) informacoesMunicipio.Estado);
            Assert.Equal("Pelotas", informacoesMunicipio.Nome);
        }


        [Fact]
        public void TestObtendoNomeDoMunicipio()
        {
            var resultado = new Municipio(4314407).Nome;

            Assert.Equal("Pelotas", resultado);
        }

        [Fact]
        public void TestListaDeTodosMunicipios()
        {
            var numeroDeTodosRegistros = Municipio.ListarTodos().Count();
            Assert.Equal(5570, numeroDeTodosRegistros);
        }


        [Fact]
        public void TestListaDeMunicipiosPorUf()
        {
            var numeroDeTodosRegistrosDoRs = Municipio.ListarPorEstado(UF.RS).Count();
            Assert.Equal(497, numeroDeTodosRegistrosDoRs);
        }

        [Fact]
        public void TestListaDeMunicipiosPorEstado()
        {
            var numeroDeTodosRegistrosDoRs = Municipio.ListarPorEstado("São Paulo").Count();
            Assert.Equal(645, numeroDeTodosRegistrosDoRs);
        }
    }
}