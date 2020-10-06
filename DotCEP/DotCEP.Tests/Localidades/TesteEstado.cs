using System.Linq;
using DotCEP.Localidades;
using Xunit;

namespace DotCEP.Tests.Localidades
{
    public class TesteEstado
    {
        [Fact]
        public void TestObtendoCodigoDoEstadoAtravesDaSigla()
        {
            var resultado = new Estado("rs").Codigo;

            Assert.Equal(43, resultado);
        }

        [Fact]
        public void TestObtendoCodigoDoEstadoAtravesDoNome()
        {
            var resultado = new Estado("Rio Grande do Sul").Codigo;

            Assert.Equal(43, resultado);
        }

        [Fact]
        public void TestObtendoNomeDoEstadoAtravesDaSigla()
        {
            var resultado = new Estado("RS").Nome;

            Assert.Equal("Rio Grande do Sul", resultado);
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

            Assert.Equal("RS", resultado);
        }

        [Fact]
        public void TestObtendoSiglaDoEstadoAtravesDoNome()
        {
            var resultado = new Estado("Rio Grande do Sul").Sigla;

            Assert.Equal("RS", resultado);
        }

        [Fact]
        public void TestListaDeEstados()
        {
            var listaEstados = Estado.ObterListaDeEstados().ToList();

            var numeroDeResultados = listaEstados.Count;
            var estadoNumeroZero = listaEstados[0];

            Assert.Equal(12, estadoNumeroZero.Codigo);
            Assert.Equal("AC", estadoNumeroZero.Sigla);
            Assert.Equal("Acre", estadoNumeroZero.Nome);
            Assert.Equal(27, numeroDeResultados);
        }
    }
}