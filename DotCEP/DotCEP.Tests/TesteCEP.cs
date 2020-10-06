using System;
using FluentAssertions;
using Xunit;

namespace DotCEP.Tests
{
    public class TesteCep
    {
        [Theory]
        [InlineData("96085-000")]
        [InlineData("96085000")]
        public void TestVerificacaoCepValido(string valor)
        {
            var cep = new CEP(valor);
            cep.Valido.Should().BeTrue();
        }

        [Theory]
        [InlineData("960850-00")]
        [InlineData("960850000")]
        public void TestVerificacaoCepInvalido(string valor)
        {
            var cep = new CEP(valor);
            cep.Valido.Should().BeFalse();
        }

        [Theory]
        [InlineData("96085100")]
        [InlineData("96085000")]
        public void TestVerificacaoDeCepExistente(string valor)
        {
            var resultadoDaExistencia = new CEP(valor).VerificarExistencia();
            resultadoDaExistencia.Should().BeTrue();
        }

        [Theory]
        [InlineData("960850000")]
        [InlineData("96084100")]
        public void TestVerificacaoDeCepInexistente(string valor)
        {
            var resultadoDaExistencia = new CEP(valor).VerificarExistencia();
            resultadoDaExistencia.Should().BeFalse();
        }

        #region Formatacao

        [Fact]
        public void TestFormatacaoComEspacosEmBranco()
        {
            var cep = new CEP("9 6 0 8 5 0 0 0");
            cep.Valor.Should().Be("96085-000");
        }

        [Fact]
        public void TestCepFormatadoErrado()
        {
            var cep = new CEP("96-085 000");
            cep.Valor.Should().Be("96085-000");
        }

        [Theory]
        [InlineData("960850*00")]
        [InlineData("96085=000")]
        public void TestFormatacaoNaoValido(string cePparaVerificar)
        {
            Action act = () => { new CEP(cePparaVerificar); };

            act.Should().Throw<ArgumentException>();
        }

        #endregion
    }
}