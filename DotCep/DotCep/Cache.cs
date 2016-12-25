using System;

namespace DotCEP
{
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
			cmd.SetValue("dataconsulta", Datas.ObterDataFormatada());

			try
			{
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoCache());

				database.SetExecuteSecurity(false);

				database.Execute(cmd.GetUpdatedText());
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
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
			cmd.SetValue("dataconsulta", Datas.ObterDataFormatada());
			cmd.SetValue("idconsultandereco", IDConsulta);

			try
			{
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoCache());

				database.SetExecuteSecurity(false);

				database.Execute(cmd.GetUpdatedText());
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
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
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoCache());

				database.Execute(cmd.GetUpdatedText());

			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
			}
		}
	}
}
