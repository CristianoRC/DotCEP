using System;
using System.Data;
using System.Globalization;

namespace DotCEP
{
	internal static class Cache
	{
		internal static void Criar(string CEP, string Resultado)
		{
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "insert into consultas values(#cep#,#retorno#,#dataconsulta#)";

			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);
			cmd.AddParameter("retorno", Spartacus.Database.Type.STRING);
			cmd.AddParameter("dataconsulta", Spartacus.Database.Type.STRING);

			cmd.SetValue("cep", CEP);
			cmd.SetValue("retorno", Resultado, false);
			cmd.SetValue("dataconsulta", ObterDataFormatada());

			try
			{
				database = new Spartacus.Database.Sqlite(ObterCaminhoBanco());

				database.SetExecuteSecurity(false);

				database.Execute(cmd.GetUpdatedText());
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
			}
		}

		internal static string ObterJson(string CEP)
		{
			string strJSON = string.Empty;

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabela = new DataTable();

			cmd.v_text = "select * from consultas where CEP = #cep#";

			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);

			cmd.SetValue("cep", CEP);


			try
			{
				database = new Spartacus.Database.Sqlite(ObterCaminhoBanco());
				database.SetExecuteSecurity(false);

				tabela = database.Query(cmd.GetUpdatedText(), "Resultado");

				if (tabela.Rows.Count == 1)
				{
					if (ValidarIntervaloDeTempo(tabela.Rows[0]["DataConsulta"].ToString()))
					{
						strJSON = tabela.Rows[0]["Retorno"].ToString();
					}
					else
					{
						Deletar(CEP);
					}
				}


			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
			}


			return strJSON;
		}

		private static void Deletar(string CEP)
		{
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "delete from consultas where CEP = #cep#";

			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);

			cmd.SetValue("cep", CEP);


			try
			{
				database = new Spartacus.Database.Sqlite(ObterCaminhoBanco());

				database.Execute(cmd.GetUpdatedText());

			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
			}
		}


		/// <summary>
		/// Gera a data no formatado certo para salvar no banco.
		/// </summary>
		/// <returns>A data formatada.</returns>
		private static string ObterDataFormatada()
		{
			return DateTime.Now.ToString("yyyyMMdd HHmmss");
		}

		/// <summary>
		/// Verifica se o interváli de tempo é maior que 30 dias.
		/// </summary>
		/// <returns><c>true</c>, se a data for menor que 30 dias, <c>false</c> mais que 30 dias.</returns>
		/// <param name="DataConsulta">Data consulta.</param>
		private static bool ValidarIntervaloDeTempo(string p_DataConsulta)
		{
			bool resultado = false;

			string HoraEdataAtual = DateTime.Now.ToString("yyyyMMdd HHmmss");

			DateTime dataAtual = DateTime.ParseExact(HoraEdataAtual, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture);
			DateTime dataDaConsulta = DateTime.ParseExact(p_DataConsulta, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture);


			TimeSpan ts = new TimeSpan();

			ts = dataAtual - dataDaConsulta;

			if (ts.Days < 31)
			{
				resultado = true;
			}


			return resultado;
		}

		private static string ObterCaminhoBanco()
		{
			String caminhoexecutavel = System.AppDomain.CurrentDomain.BaseDirectory;


			if (((int)Environment.OSVersion.Platform) < 4)
			{
				return string.Format(@"{0}\\Cache\\Cache.db", caminhoexecutavel); // Windows
			}
			else
			{
				return String.Format(@"{0}/Cache/Cache.db", caminhoexecutavel); // Linux e MacOSX
			}
		}
	}
}
