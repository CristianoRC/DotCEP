using System;
using NUnit.Framework;

namespace DotCEP.Test
{
	[TestFixture]
	public class TestEstado
	{
		[Test]
		public void TestObtendoCodigoDoEstadoAtravesDaSigla()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterCodigoDoEstado("RS");

			Assert.AreEqual("43", Resultado);
		}

		[Test]
		public void TestObtendoNomeDoEstadoAtravesDaSigla()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterNomeDoEstado("RS");

			Assert.AreEqual("Rio Grande do Sul", Resultado);
		}

		[Test]
		public void TestObtendoNomeDoEstadoAtravesDoID()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterNomeDoEstado(43);

			Assert.AreEqual("Rio Grande do Sul", Resultado);
		}

		[Test]
		public void TestObtendoSiglaDoEstadoAtravesDoID()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterSiglaDoEstado(43);

			Assert.AreEqual("RS",Resultado);
		}

		[Test]
		public void TestObtendoSiglaDoEstadoAtravesDoNome()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterSiglaDoEstado("Rio Grande do Sul");

			Assert.AreEqual("RS",Resultado);
		}

		[Test]
		public void TestListaDeEstados()
		{
			int NumeroDeResultados = DotCEP.Localidades.Estado.ObterListaDeEstados().Count;
			DotCEP.Localidades.Estado EstadoNumeroZero = DotCEP.Localidades.Estado.ObterListaDeEstados()[0];

			Assert.AreEqual(11, EstadoNumeroZero.Codigo);
			Assert.AreEqual("RO", EstadoNumeroZero.Sigla);
			Assert.AreEqual("Rondonia", EstadoNumeroZero.Nome);
			Assert.AreEqual(27,NumeroDeResultados);
		}
	}
}
