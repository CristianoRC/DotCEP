using System;
using System.Data;
using System.Collections.Generic;

namespace DotCEP
{
	
	/// <summary>
	/// Manipulação do cache de consulta de vários endereços
	/// </summary>
	internal partial class Cache
	{
		internal static void Criar(UF p_UF, string p_Localidade, string p_Logradouro, string p_ResultadoJSON)
		{
			var parametros = Formatacao.FormatarStrParametros(p_UF, p_Localidade, p_Logradouro);

            SpartacusMin.Database.Generic database;
			var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "insert into ConsultaEndereco (Parametros,DataConsulta) values(#parametros#,#dataconsulta#)";

			cmd.AddParameter("parametros", SpartacusMin.Database.Type.STRING);
			cmd.AddParameter("dataconsulta", SpartacusMin.Database.Type.STRING);

			cmd.SetValue("dataconsulta", DateTime.Now.ObterDataFormatada(), false);
			cmd.SetValue("parametros", parametros, false);

			database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());

			try
			{
				#region Inserindo informações sobre consulta de endereços no banco 

				database.Open();

				database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());
				database.SetExecuteSecurity(false);

				database.Execute(cmd.GetUpdatedText());

				#endregion

				#region Formatando e inserindo enderecos no banco

				List<string> EnderecosJSON = ManipulacaoJSON.SepararArrayJSON(p_ResultadoJSON);
				var IDInsercao = ObterIDultimaInsercao();


				foreach (string item in EnderecosJSON)
				{
					Criar(ManipulacaoJSON.ObterCEPdaStrJSON(item), item, IDInsercao);
				}

				#endregion
			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception($"Erro:{ex.v_message} ");
			}
			finally
			{
				database.Close();
			}

		}

		internal static void Deletar(int IDConsulta)
		{

			SpartacusMin.Database.Generic database;
			SpartacusMin.Database.Command cmd = new SpartacusMin.Database.Command();

			cmd.v_text = "delete from cache "
			+ "where IDconsultaEndereco = #idconsulta#";

			cmd.AddParameter("idconsulta", SpartacusMin.Database.Type.INTEGER);
			cmd.SetValue("idconsulta", IDConsulta.ToString());

			try
			{
				database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());

				database.Execute(cmd.GetUpdatedText());

				deletarConsulta(IDConsulta);

			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception($"Erro no banco: {ex.v_message}");
			}
		}

		internal static List<Endereco> ObterCache(UF p_UF, string Localidade, string Logradouro)
		{
			List<string> listaCaheJSON = new List<string>();
			List<Endereco> listaEnderecos = new List<Endereco>();

			SpartacusMin.Database.Generic database;
			SpartacusMin.Database.Command cmd = new SpartacusMin.Database.Command();
			DataTable tabela = new DataTable();

			cmd.v_text = @"select c.retorno, x.DataConsulta, c.idconsultaendereco from cache c 
						  inner join ConsultaEndereco x on x.ID = c.idconsultaendereco 
			              where x.Parametros = #parametros#";

			cmd.AddParameter("parametros", SpartacusMin.Database.Type.STRING);

			cmd.SetValue("parametros", Formatacao.FormatarStrParametros(p_UF, Localidade, Logradouro), false);

			try
			{
				database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());
				database.SetExecuteSecurity(false);

				tabela = database.Query(cmd.GetUpdatedText(), "Resultado");

				if (tabela.Rows.Count != 0)
				{
					if (DateTime.Now.ValidarIntervaloDeTempo(tabela.Rows[0]["DataConsulta"].ToString()))
					{
						foreach (DataRow item in tabela.Rows)
						{
							listaCaheJSON.Add(item[0].ToString());
						}

						listaEnderecos = ManipulacaoJSON.ObterEnderecos(listaCaheJSON);
					}
					else
					{
						Cache.Deletar(Convert.ToInt16(tabela.Rows[0][2]));
					}
				}

			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception($"Erro no banco: {ex.v_message}");
			}


			return listaEnderecos;
		}

		private static void deletarConsulta(int IDConsulta)
		{
			SpartacusMin.Database.Generic database;
			SpartacusMin.Database.Command cmd = new SpartacusMin.Database.Command();

			cmd.v_text = "delete from ConsultaEndereco where Id = #id#";

			cmd.AddParameter("id", SpartacusMin.Database.Type.INTEGER);
			cmd.SetValue("id", IDConsulta.ToString());

			try
			{
				database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());

				database.Execute(cmd.GetUpdatedText());

			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception($"Erro no banco: {ex.v_message}");
			}
		}

		private static string ObterIDultimaInsercao()
		{
			SpartacusMin.Database.Generic database;
			DataTable tabela;

			try
			{
				database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoCache());

				tabela = database.Query("select MAX(id) from ConsultaEndereco", "UltimoRegistro");

				return tabela.Rows[0][0].ToString();
			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception($"Erro: {ex.v_message}");
			}
		}
	}
}
