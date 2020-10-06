using System.Linq;
using DotCEP.Compartilhado.Enumeradores;
using DotCEP.Localidades;
using FluentAssertions;
using Xunit;

namespace DotCEP.Tests.Localidades
{
    public class TesteMunicipio
    {
        [Fact]
        public void TestObtendoCodigoDoMunicipioUf()
        {
            var resultado = new Municipio("Pelotas", UF.RS).Codigo;
            resultado.Should().Be(4314407);
        }


        [Fact]
        public void TestObtendoCodigoDoMunicipioNomeEstado()
        {
            var resultado = new Municipio("Pelotas", "Rio Grande do Sul").Codigo;
            resultado.Should().Be(4314407);
        }

        [Fact]
        public void TestObtendoInformacoesDoMunicipioCodigo()
        {
            var informacoesMunicipio = new Municipio(4314407);
            informacoesMunicipio.Codigo.Should().Be(4314407);
            informacoesMunicipio.Estado.Should().Be(43);
            informacoesMunicipio.Nome.Should().Be("Pelotas");
        }


        [Fact]
        public void TestObtendoInformacoesDoMunicipioUf()
        {
            var informacoesMunicipio = new Municipio("Pelotas", UF.RS);

            informacoesMunicipio.Codigo.Should().Be(4314407);
            informacoesMunicipio.Estado.Should().Be(43);
            informacoesMunicipio.Nome.Should().Be("Pelotas");
        }


        [Fact]
        public void TestObtendoInformacoesDoMunicipioNomeEstado()
        {
            var informacoesMunicipio = new Municipio("Pelotas", "Rio Grande do Sul");

            informacoesMunicipio.Codigo.Should().Be(4314407);
            informacoesMunicipio.Estado.Should().Be(43);
            informacoesMunicipio.Nome.Should().Be("Pelotas");
        }


        [Fact]
        public void TestObtendoNomeDoMunicipio()
        {
            var resultado = new Municipio(4314407).Nome;
            resultado.Should().Be("Pelotas");
        }

        [Fact]
        public void TestListaDeTodosMunicipios()
        {
            var numeroDeTodosRegistros = Municipio.ListarTodos().Count();
            numeroDeTodosRegistros.Should().Be(5570);
        }


        [Fact]
        public void TestListaDeMunicipiosPorUf()
        {
            var numeroDeTodosRegistrosDoRs = Municipio.ListarPorEstado(UF.RS).Count();
            numeroDeTodosRegistrosDoRs.Should().Be(497);
        }

        [Fact]
        public void TestListaDeMunicipiosPorEstado()
        {
            var numeroDeTodosRegistrosDoRs = Municipio.ListarPorEstado("São Paulo").Count();
            numeroDeTodosRegistrosDoRs.Should().Be(645);
        }
    }
}