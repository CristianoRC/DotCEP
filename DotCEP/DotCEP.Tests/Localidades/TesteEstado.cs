using System.Linq;
using DotCEP.Localidades;
using FluentAssertions;
using Xunit;

namespace DotCEP.Tests.Localidades
{
    public class TesteEstado
    {
        [Fact]
        public void TestObtendoCodigoDoEstadoAtravesDaSigla()
        {
            var resultado = new Estado("rs").Codigo;
            resultado.Should().Be(43);
        }

        [Fact]
        public void TestObtendoCodigoDoEstadoAtravesDoNome()
        {
            var resultado = new Estado("Rio Grande do Sul").Codigo;
            resultado.Should().Be(43);
        }

        [Fact]
        public void TestObtendoNomeDoEstadoAtravesDaSigla()
        {
            var resultado = new Estado("RS").Nome;
            resultado.Should().Be("Rio Grande do Sul");
        }


        [Fact]
        public void TestObtendoNomeDoEstadoAtravesDoId()
        {
            var resultado = new Estado(43).Nome;

            Assert.Equal("Rio Grande do Sul", resultado);
        }

        [Fact]
        public void TestObtendoSiglaDoEstadoAtravesDoId()
        {
            var resultado = new Estado(43).Sigla;
            resultado.Should().Be("RS");
        }

        [Fact]
        public void TestObtendoSiglaDoEstadoAtravesDoNome()
        {
            var resultado = new Estado("Rio Grande do Sul").Sigla;
            resultado.Should().Be("RS");
        }

        [Fact]
        public void TestListaDeEstados()
        {
            var listaEstados = Estado.ObterListaDeEstados().ToList();

            var numeroDeResultados = listaEstados.Count;
            var estadoNumeroZero = listaEstados[0];
            estadoNumeroZero.Codigo.Should().Be(12);
            estadoNumeroZero.Sigla.Should().Be("AC");
            estadoNumeroZero.Nome.Should().Be("Acre");
            numeroDeResultados.Should().Be(27);
        }
    }
}