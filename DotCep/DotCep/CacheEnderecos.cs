using System;
using System.Data;
using System.Collections.Generic;

namespace DotCEP
{
	internal static partial class Cache
	{
		internal static void Criar(UF p_UF, string Localidade, string Logradouro, string Resultado)
		{
			string parametros = formatarStrParametros(p_UF, Localidade, Logradouro);

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "insert into ConsultaEndereco (Parametros,DataConsulta) values(#parametros#,#dataconsulta#)";

			cmd.AddParameter("parametros", Spartacus.Database.Type.STRING);
			cmd.AddParameter("dataconsulta", Spartacus.Database.Type.STRING);

			cmd.SetValue("dataconsulta", obterDataFormatada(), false);
			cmd.SetValue("parametros", parametros, false);

			try
			{
				#region Inserindo informações sobre consulta de endereços no banco 

				database = new Spartacus.Database.Sqlite(obterCaminhoBanco());
				database.SetExecuteSecurity(false);

				database.Execute(cmd.GetUpdatedText());

				#endregion

				#region Formatando e inserindo enderecos no banco

				List<string> EnderecosJSON = SepararArrayJSON(Resultado);
				string IDInsercao = ObterIDultimaInsercao();


				foreach (string item in EnderecosJSON)
				{
					Criar(obterCEPdaStrJSON(item), item, IDInsercao);
				}

				#endregion
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro: " + ex.v_message);
			}

		}

		internal static List<string> ObterJson(UF p_UF, string Localidade, string Logradouro)
		{
			List<string> strJSON = new List<string>();

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabela = new DataTable();

			cmd.v_text = @"select c.retorno, x.DataConsulta, c.idconsultaendereco from cache c 
						  inner join ConsultaEndereco x on x.ID = c.idconsultaendereco 
			              where x.Parametros = #parametros#";

			cmd.AddParameter("parametros", Spartacus.Database.Type.STRING);

			cmd.SetValue("parametros", formatarStrParametros(p_UF, Localidade, Logradouro), false);

			try
			{
				database = new Spartacus.Database.Sqlite(obterCaminhoBanco());
				database.SetExecuteSecurity(false);

				tabela = database.Query(cmd.GetUpdatedText(), "Resultado");

				if (tabela.Rows.Count != 0)
				{
					if (validarIntervaloDeTempo(tabela.Rows[0][1].ToString()))
					{
						foreach (DataRow item in tabela.Rows)
						{
							strJSON.Add(item[0].ToString());
						}
					}
					else
					{
						deletar(Convert.ToInt16(tabela.Rows[0][2]));
					}
				}

			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro no banco: " + ex.v_message);
			}


			return strJSON;
		}

		private static void deletar(int IDConsulta)
		{

			Spartacus.Database.Generic database;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "delete from cache "
			+ "where IDconsultaEndereco = #idconsulta#";

			cmd.AddParameter("idconsulta", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("idconsulta", IDConsulta.ToString());

			try
			{
				database = new Spartacus.Database.Sqlite(obterCaminhoBanco());

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
				database = new Spartacus.Database.Sqlite(obterCaminhoBanco());

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
				database = new Spartacus.Database.Sqlite(obterCaminhoBanco());

				tabela = database.Query("select MAX(id) from ConsultaEndereco", "UltimoRegistro");

				return tabela.Rows[0][0].ToString();
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception("Erro: " + ex.v_message);
			}
		}


		private static string obterCEPdaStrJSON(string strJSON)
		{
			Endereco enderecobase = new Endereco();

			enderecobase = Newtonsoft.Json.JsonConvert.DeserializeObject<Endereco>(strJSON);

			return enderecobase.cep;
		}

		private static string formatarStrParametros(UF p_UF, string Localidade, string Logradouro)
		{
			return String.Format("{0},{1},{2}", p_UF.ToString(), Localidade, Logradouro);
		}

		/// <summary>
		/// Separa o array JSON em objetos.
		/// </summary>
		/// <param name="strJSON">String json.</param>
		private static List<string> SepararArrayJSON(string strJSON)
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
