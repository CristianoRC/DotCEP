using System;
using Xunit;

namespace DotCEP.Test
{
    public class TesteCEP
    {
        [Theory]
        [InlineData("96085-000")]
        [InlineData("96085000")]
        public void TestVerificacaoCepValido(string valor)
        {
            var cep = new CEP(valor);
            Assert.True(cep.Valido);
        }

        [Theory]
        [InlineData("960850-00")]
        [InlineData("960850000")]
        public void TestVerificacaoCepInvalido(string valor)
        {
            var cep = new CEP(valor);
            Assert.False(cep.Valido);
        }

        [Theory]
        [InlineData("96085100")]
        [InlineData("96085000")]
        public void TestVerificacaoDeCepExistente(string valor)
        {
            var resultadoDaExistencia = new CEP(valor).VerificarExistencia();
            Assert.True(resultadoDaExistencia);
        }

        [Theory]
        [InlineData("960850000")]
        [InlineData("96084100")]
        public void TestVerificacaoDeCepInexistente(string valor)
        {
            var resultadoDaExistencia = new CEP(valor).VerificarExistencia();
            Assert.False(resultadoDaExistencia);
        }

        #region Formatacao

        [Fact]
        public void TestFormatacaoComEspacosEmBranco()
        {
            var cep = new CEP("9 6 0 8 5 0 0 0");
            Assert.Equal("96085-000", cep.Valor);
        }

        [Fact]
        public void TestCepFormatadoErrado()
        {
            var cep = new CEP("96-085 000");
            Assert.Equal("96085-000", cep.Valor);
        }

        [Theory]
        [InlineData("960850*00")]
        [InlineData("96085=000")]
        public void TestFormatacaoNaoValido(string cePparaVerificar)
        {
            Assert.Throws<ArgumentException>(() => new CEP(cePparaVerificar));
        }

        #endregion
    }
}