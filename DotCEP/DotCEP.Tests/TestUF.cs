using Xunit;

namespace DotCEP.Test
{
    public class TestUF
    {
        [Fact]
        public void TestSiglaEstado()
        {
            Assert.Equal("RS", UF.RS.ToString());
        }

        [Fact]
        public void TestCodigoEstado()
        {
            int codigoEstado = (int) UF.RS;

            Assert.Equal(43, codigoEstado);
        }
    }
}