using System;
using NUnit.Framework;

namespace DotCEP.Test
{
	[TestFixture]
	public class TestValidacao
	{
		[TestCase("96085-000")]
		[TestCase("96085000")]
		public void TestVerificacaoCEPValido(String CepTeste)
		{
			Boolean resultadoValidacao = DotCEP.Validacoes.VerificarValidadeDoCep(CepTeste);
			Assert.AreEqual(true, resultadoValidacao);
		}

		[TestCase("960850-00")]
		[TestCase("960850000")]
		public void TestVerificacaoCEPInvalido(String CepTeste)
		{
			bool ResultadoValidacao = DotCEP.Validacoes.VerificarValidadeDoCep(CepTeste);
			Assert.AreEqual(false, ResultadoValidacao);
		}

		[Test]
		public void TestVerificacaoDeCEPExistente()
		{
			bool resultadoDaExistencia = DotCEP.Validacoes.VerificarExistenciaDoCEP("96085100");
			Assert.AreEqual(true, resultadoDaExistencia);
		}

		[Test]
		public void TestVerificacaoDeCEPInexistente()
		{
			bool resultadoDaExistencia = DotCEP.Validacoes.VerificarExistenciaDoCEP("960850000");
			Assert.AreEqual(false, resultadoDaExistencia);
		}
	}
}
