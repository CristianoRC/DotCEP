using System;
using System.Data;

namespace DotCEP
{
	/// <summary>
	/// Manipulação do cache de consulta de endereço 
	/// </summary>
	internal static partial class Cache
	{
		internal static void Criar(string CEP, string Resultado)
		{
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "insert into cache (cep,retorno,dataconsulta) values(#cep#,#retorno#,#dataconsulta#)";

			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);
			cmd.AddParameter("retorno", Spartacus.Database.Type.STRING);
			cmd.AddParameter("dataconsulta", Spartacus.Database.Type.STRING);

			cmd.SetValue("cep", CEP);
			cmd.SetValue("retorno", Resultado, false);
			cmd.SetValue("dataconsulta", DateTime.Now.ObterDataFormatada());

			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());

				database.SetExecuteSecurity(false);

				database.Execute(cmd.GetUpdatedText());
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception($"Erro no banco: {ex.v_message}");
			}
		}

		internal static void Criar(string CEP, string Resultado, string IDConsulta)
		{
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "insert into cache values(#cep#,#retorno#,#dataconsulta#,#idconsultandereco#)";

			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);
			cmd.AddParameter("retorno", Spartacus.Database.Type.STRING);
			cmd.AddParameter("dataconsulta", Spartacus.Database.Type.STRING);
			cmd.AddParameter("idconsultandereco", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("cep", CEP);
			cmd.SetValue("retorno", Resultado, false);
			cmd.SetValue("dataconsulta", DateTime.Now.ObterDataFormatada());
			cmd.SetValue("idconsultandereco", IDConsulta);

			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());

				database.SetExecuteSecurity(false);

				database.Execute(cmd.GetUpdatedText());
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception($"Erro no banco: {ex.v_message}");
			}
		}

		internal static void Deletar(string CEP)
		{
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "delete from cache where CEP = #cep#";

			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);

			cmd.SetValue("cep", CEP);


			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());

				database.Execute(cmd.GetUpdatedText());

			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception($"Erro no banco: {ex.v_message}");
			}
		}

		internal static Endereco ObterCache(string CEP)
		{
			var enderecoBase = new Endereco();

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabela = new DataTable();

			cmd.v_text = "select * from cache where CEP = #cep#";

			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);

			cmd.SetValue("cep", CEP);


			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());
				database.SetExecuteSecurity(false);

				tabela = database.Query(cmd.GetUpdatedText(), "Saida");

				if (tabela.Rows.Count != 0)
				{
					var strJSON = tabela.Rows[0]["Retorno"].ToString();

					enderecoBase = ManipulacaoJSON.ObterEndereco(strJSON);
				}
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception($"Erro no banco: {ex.v_message}");
			}

			return enderecoBase;
		}
	}
}
