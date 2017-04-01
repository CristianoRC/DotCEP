using System;
using NUnit.Framework;

namespace DotCEP.Test
{
	[TestFixture]
	public class TestFormatacao
	{
		[Test]
		public void TestFormatacaoComEspacosEmBranco()
		{
			String CEPFormatado = DotCEP.Formatacao.FormatarCEP("9 6 0 8 5 0 0 0");

			Assert.That(CEPFormatado, Is.EqualTo("96085-000"));
		}

		[Test]
		public void TestCepFormatadoErrado()
		{
			String CEPFormatado = DotCEP.Formatacao.FormatarCEP("96-085 000");

			Assert.That(CEPFormatado,Is.EqualTo("96085-000"));
		}

		[TestCase("960850000")]
		[TestCase("96085=000")]
		public void TestNaoValido(String CEPparaVerificar)
		{
			String CEPFormatado = DotCEP.Formatacao.FormatarCEP(CEPparaVerificar);

			Assert.That(CEPFormatado, Is.Empty);
		}
	}
}
