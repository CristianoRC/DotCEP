using System;
using NUnit.Framework;

namespace DotCEP.Test
{
	[TestFixture]
	public class TestConsultas
	{

		private DotCEP.Endereco enderecoBase;

		[Test]
		public void TestConsultaEnderecoCompletoValido()
		{
			enderecoBase = DotCEP.Consultas.ObterEnderecoCompleto("96085000");

			Assert.That(enderecoBase.localidade, Is.EqualTo("Pelotas"));
			Assert.That(enderecoBase.bairro, Is.EqualTo("Areal"));
			Assert.That(enderecoBase.logradouro, Is.EqualTo("Avenida Ferreira Viana"));

		}

		[Test]
		public void TestConsultaEnderecoCompletoInvalido()
		{
			enderecoBase = DotCEP.Consultas.ObterEnderecoCompleto("960850000");

			Assert.That(enderecoBase.localidade, Is.Null);
			Assert.That(enderecoBase.bairro, Is.Null);
			Assert.That(enderecoBase.logradouro, Is.Null);
		}

		[Test]
		public void TestConsultaListaEnderecos()
		{
			System.Collections.Generic.List<Endereco> listaEnderecos = DotCEP.Consultas.ObterListaDeEnderecos(UF.RS, "Pelotas", "Ferreira");

			Assert.That(listaEnderecos.Count, Is.EqualTo(11));
		}

		/*
		[TearDown]
		public void ApagarCache()
		{
			Spartacus.Database.Generic database = new Spartacus.Database.Sqlite(ObterCaminhoBancoCache());
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Delete from Cache";
			database.Execute(cmd.GetUpdatedText());

			cmd.v_text = "Delete from ConsultaEndereco";
			database.Execute(cmd.GetUpdatedText());
		}
*/

		private static string ObterCaminhoBancoCache()
		{
			if (((int)Environment.OSVersion.Platform) < 4)
			{
				return string.Format(@"{0}\\Cache\\Cache.db", System.AppDomain.CurrentDomain.BaseDirectory); // Windows
			}
			else
			{
				return String.Format(@"{0}/Cache/Cache.db", System.AppDomain.CurrentDomain.BaseDirectory); // Linux e MacOSX
			}
		}
	}
}
