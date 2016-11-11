using System;
using System.Collections.Generic;
using System.Data;

namespace DotCEP
{
	internal static class ControleJSON
	{
		internal static string ObterJsonDoCacheLocal(string CEP)
		{
			string strJSON = string.Empty;

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabela = new DataTable();

			cmd.v_text = "select * from cache where CEP = #cep#";

			cmd.AddParameter("cep", Spartacus.Database.Type.STRING);

			cmd.SetValue("cep", CEP);


			try
			{
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBanco());
				database.SetExecuteSecurity(false);

				tabela = database.Query(cmd.GetUpdatedText(), "Resultado");

				if (tabela.Rows.Count != 0)
				{
					if (Datas.ValidarIntervaloDeTempo(tabela.Rows[0]["DataConsulta"].ToString()))
					{
						strJSON = tabela.Rows[0]["Retorno"].ToString();
					}
					else
					{
						Cache.Deletar(CEP);
					}
				}


			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
			}


			return strJSON;
		}

		internal static List<string> ObterJsonDoCacheLocal(UF p_UF, string Localidade, string Logradouro)
		{
			List<string> strJSON = new List<string>();

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabela = new DataTable();

			cmd.v_text = @"select c.retorno, x.DataConsulta, c.idconsultaendereco from cache c 
						  inner join ConsultaEndereco x on x.ID = c.idconsultaendereco 
			              where x.Parametros = #parametros#";

			cmd.AddParameter("parametros", Spartacus.Database.Type.STRING);

			cmd.SetValue("parametros", Ferramentas.FormatarStrParametros(p_UF, Localidade, Logradouro), false);

			try
			{
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBanco());
				database.SetExecuteSecurity(false);

				tabela = database.Query(cmd.GetUpdatedText(), "Resultado");

				if (tabela.Rows.Count != 0)
				{
					if (Datas.ValidarIntervaloDeTempo(tabela.Rows[0][1].ToString()))
					{
						foreach (DataRow item in tabela.Rows)
						{
							strJSON.Add(item[0].ToString());
						}
					}
					else
					{
						Cache.Deletar(Convert.ToInt16(tabela.Rows[0][2]));
					}
				}

			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
			}


			return strJSON;
		}

		internal static string ObterCEPdaStrJSON(string strJSON)
		{
			Endereco enderecobase = new Endereco();

			enderecobase = Newtonsoft.Json.JsonConvert.DeserializeObject<Endereco>(strJSON);

			string CEPtemp = enderecobase.cep.Replace("-", "");

			return CEPtemp;
		}

		/// <summary>
		/// Separa o array JSON em objetos.
		/// </summary>
		/// <param name="strJSON">String json.</param>
		internal static List<string> SepararArrayJSON(string strJSON)
		{
			List<string> EnderecosJSON = new List<string>();

			List<Endereco> Enderecos = new List<Endereco>();

			Enderecos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Endereco>>(strJSON);


			foreach (Endereco item in Enderecos)
			{
				EnderecosJSON.Add(Newtonsoft.Json.JsonConvert.SerializeObject(item));
			}

			return EnderecosJSON;
		}

	}
}
