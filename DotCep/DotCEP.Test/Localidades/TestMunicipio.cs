using System;
using NUnit.Framework;

namespace DotCEP.Test
{
	[TestFixture]
	public class TestMunicipio
	{
		[Test]
		public void TestObtendoCodigoDoMunicipioUF()
		{
			int Resultado = DotCEP.Localidades.Municipio.ObterCodigoDoMunicipio("Pelotas", UF.RS);

			Assert.AreEqual(4314407, Resultado);
		}

		[Test]
		public void TestObtendoCodigoDoMunicipioSigla()
		{
			int Resultado = DotCEP.Localidades.Municipio.ObterCodigoDoMunicipio("Pelotas", "RS");

			Assert.AreEqual(4314407, Resultado);
		}

		[Test]
		public void TestObtendoCodigoDoMunicipioNome()
		{
			int Resultado = DotCEP.Localidades.Municipio.ObterCodigoDoMunicipio("Pelotas", "Rio Grande do Sul");

			Assert.AreEqual(4314407, Resultado);
		}



		[Test]
		public void TestObtendoInformacoesDoMunicipioCodigo()
		{
			Localidades.Municipio informacoesMunicipio = Localidades.Municipio.ObterInformacoesDoMunicipio(4314407);

			Assert.AreEqual(4314407, informacoesMunicipio.Codigo);
			Assert.AreEqual(43, informacoesMunicipio.CodigoEstado);
			Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
		}


		[Test]
		public void TestObtendoInformacoesDoMunicipioUF()
		{
			Localidades.Municipio informacoesMunicipio = Localidades.Municipio.ObterInformacoesDoMunicipio("Pelotas", UF.RS);

			Assert.AreEqual(4314407, informacoesMunicipio.Codigo);
			Assert.AreEqual(43, informacoesMunicipio.CodigoEstado);
			Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
		}

		[Test]
		public void TestObtendoInformacoesDoMunicipioSigla()
		{
			Localidades.Municipio informacoesMunicipio = Localidades.Municipio.ObterInformacoesDoMunicipio("Pelotas", "RS");

			Assert.AreEqual(4314407, informacoesMunicipio.Codigo);
			Assert.AreEqual(43, informacoesMunicipio.CodigoEstado);
			Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
		}

		[Test]
		public void TestObtendoInformacoesDoMunicipioNOme()
		{
			Localidades.Municipio informacoesMunicipio = Localidades.Municipio.ObterInformacoesDoMunicipio("Pelotas","Rio Grande do Sul");

			Assert.AreEqual(4314407, informacoesMunicipio.Codigo);
			Assert.AreEqual(43, informacoesMunicipio.CodigoEstado);
			Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
		}


		[Test]
		public void TestObtendoNomeDoMunicipio()
		{
			String Resultado = Localidades.Municipio.ObterNomeDoMunicipio(4314407);

			Assert.AreEqual("Pelotas", Resultado);
		}

		[Test]
		public void TestListaDeTodosMunicipios()
		{
			int numeroDeTodosRegistros = Localidades.Municipio.ObterListaDeMunicipio().Count;
			Assert.AreEqual(5570, numeroDeTodosRegistros);
		}


		[Test]
		public void TestListaDeMunicipiosPorEstado()
		{
			int numeroDeTodosRegistrosDoRS = Localidades.Municipio.ObterListaDeMunicipio(UF.RS).Count;
			Assert.AreEqual(497, numeroDeTodosRegistrosDoRS);
		}

		[Test]
		public void TestListaDeMunicipiosPorEstadoSigla()
		{
			int numeroDeTodosRegistrosDoRS = Localidades.Municipio.ObterListaDeMunicipio("SP").Count;
			Assert.AreEqual(645, numeroDeTodosRegistrosDoRS);
		}

		[Test]
		public void TestListaDeMunicipiosPorEstadoNome()
		{
			int numeroDeTodosRegistrosDoRS = Localidades.Municipio.ObterListaDeMunicipio("São Paulo").Count;
			Assert.AreEqual(645, numeroDeTodosRegistrosDoRS);
		}
	}
}