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

			Assert.AreEqual(Resultado, "43");
		}

		[Test]
		public void TestObtendoNomeDoEstadoAtravesDaSigla()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterNomeDoEstado("RS");

			Assert.AreEqual(Resultado, "Rio Grande do Sul");
		}

		[Test]
		public void TestObtendoNomeDoEstadoAtravesDoID()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterNomeDoEstado(43);

			Assert.AreEqual(Resultado, "Rio Grande do Sul");
		}

		[Test]
		public void TestObtendoSiglaDoEstadoAtravesDoID()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterSiglaDoEstado(43);

			Assert.AreEqual(Resultado, "RS");
		}

		[Test]
		public void TestObtendoSiglaDoEstadoAtravesDoNome()
		{
			String Resultado = DotCEP.Localidades.Estado.ObterSiglaDoEstado("Rio Grande do Sul");

			Assert.AreEqual(Resultado, "RS");
		}

		[Test]
		public void TestListaDeEstados()
		{
			int NumeroDeResultados = DotCEP.Localidades.Estado.ObterListaDeEstados().Count;
			DotCEP.Localidades.Estado EstadoNumeroZero = DotCEP.Localidades.Estado.ObterListaDeEstados()[0];

			Assert.AreEqual(11, EstadoNumeroZero.Codigo);
			Assert.AreEqual("RO", EstadoNumeroZero.Sigla);
			Assert.AreEqual("Rondonia", EstadoNumeroZero.Nome);
			Assert.AreEqual(NumeroDeResultados, 27);
		}
	}
}
