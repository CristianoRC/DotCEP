using System;
using NUnit.Framework;

namespace DotCEP.Test
{
	[TestFixture]
	public class TestConsultas
	{
		[Test]
		public void TestConsultaEnderecoCompletoValido()
		{
			DotCEP.Endereco enderecoBase = DotCEP.Consultas.ObterEnderecoCompleto("96085000");

			Assert.AreEqual("Pelotas", enderecoBase.localidade);
			Assert.AreEqual("Areal", enderecoBase.bairro);
			Assert.AreEqual("Avenida Ferreira Viana", enderecoBase.logradouro);
		}

		[Test]
		public void TestConsultaEnderecoCompletoInvalido()
		{
			DotCEP.Endereco enderecoBase = DotCEP.Consultas.ObterEnderecoCompleto("960850000");

			Assert.AreEqual(null, enderecoBase.localidade);
			Assert.AreEqual(null, enderecoBase.bairro);
			Assert.AreEqual(null, enderecoBase.logradouro);
		}

		[Test]
		public void TestConsultaListaEnderecos()
		{
			System.Collections.Generic.List<Endereco> ListaEnderecos = DotCEP.Consultas.ObterListaDeEnderecos(UF.RS, "Pelotas", "Ferreira");

			Assert.AreEqual(11, ListaEnderecos.Count);
		}

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
