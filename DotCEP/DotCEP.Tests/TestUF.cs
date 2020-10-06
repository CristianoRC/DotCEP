using DotCEP.Compartilhado.Enumeradores;
using FluentAssertions;
using Xunit;

namespace DotCEP.Tests
{
    public class TestUF
    {
        [Fact]
        public void TestSiglaEstado()
        {
            UF.RS.ToString().Should().Be("RS");
        }

        [Fact]
        public void TestCodigoEstado()
        {
            var codigoEstado = (int) UF.RS;
            codigoEstado.Should().Be(43);
        }
    }
}