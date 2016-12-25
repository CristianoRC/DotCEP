using System;
using System.Data;
using System.Collections.Generic;

namespace DotCEP
{
	internal static partial class Cache
	{
		internal static void Criar(UF p_UF, string Localidade, string Logradouro, string Resultado)
		{
			string parametros = Ferramentas.FormatarStrParametros(p_UF, Localidade, Logradouro);

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "insert into ConsultaEndereco (Parametros,DataConsulta) values(#parametros#,#dataconsulta#)";

			cmd.AddParameter("parametros", Spartacus.Database.Type.STRING);
			cmd.AddParameter("dataconsulta", Spartacus.Database.Type.STRING);

			cmd.SetValue("dataconsulta", Datas.ObterDataFormatada(), false);
			cmd.SetValue("parametros", parametros, false);

			database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoCache());

			try
			{
				#region Inserindo informações sobre consulta de endereços no banco 

				database.Open();

				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoCache());
				database.SetExecuteSecurity(false);

				database.Execute(cmd.GetUpdatedText());

				#endregion

				#region Formatando e inserindo enderecos no banco

				List<string> EnderecosJSON = ControleJSON.SepararArrayJSON(Resultado);
				string IDInsercao = ObterIDultimaInsercao();


				foreach (string item in EnderecosJSON)
				{
					Criar(ControleJSON.ObterCEPdaStrJSON(item), item, IDInsercao);
				}

				#endregion
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro: " + ex.v_message);
			}
			finally
			{
				database.Close();
			}

		}

		internal static void Deletar(int IDConsulta)
		{

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "delete from cache "
			+ "where IDconsultaEndereco = #idconsulta#";

			cmd.AddParameter("idconsulta", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("idconsulta", IDConsulta.ToString());

			try
			{
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoCache());

				database.Execute(cmd.GetUpdatedText());

				deletarConsulta(IDConsulta);

			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
			}
		}

		private static void deletarConsulta(int IDConsulta)
		{
			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "delete from ConsultaEndereco where Id = #id#";

			cmd.AddParameter("id", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("id", IDConsulta.ToString());

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

		private static string ObterIDultimaInsercao()
		{
			Spartacus.Database.Generic database;
			DataTable tabela;

			try
			{
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoCache());

				tabela = database.Query("select MAX(id) from ConsultaEndereco", "UltimoRegistro");

				return tabela.Rows[0][0].ToString();
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro: " + ex.v_message);
			}
		}

	}
}
