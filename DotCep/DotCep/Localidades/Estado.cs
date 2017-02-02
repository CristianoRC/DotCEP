using System;
using System.Data;
using System.Collections.Generic;

namespace DotCEP.Localidades
{
	public class Estado
	{
		#region Propriedades
		public int Codigo { get; set; }
		public string Sigla { get; set; }
		public string Nome { get; set; }
		#endregion

		public static List<Estado> ObterListaDeEstados()
		{
			List<Estado> listaDeEstados = new List<Estado>();
			DataTable tabelaResultado;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.* from ESTADOS t";
			tabelaResultado = ObterInformacoesDoBanco(cmd.GetUpdatedText());

			foreach (DataRow item in tabelaResultado.Rows)
			{
				listaDeEstados.Add(ConverterRowParaEntidade(item));
			}

			return listaDeEstados;
		}

		public static string ObterNomeDoEstado(int p_Codigo)
		{
			String Saida = "Estado não encontrado, verifique o codigo";
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.nome from ESTADOS t where t.codigo = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", p_Codigo.ToString());

			DataTable tabelaResultado = ObterInformacoesDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Nome"].ToString();
			}

			return Saida;
		}

		public static string ObterNomeDoEstado(string p_Sigla)
		{
			String Saida = "Estado não encontrado, verifique a sigla";
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.nome from ESTADOS t where t.sigla = #sigla#";
			cmd.AddParameter("sigla", Spartacus.Database.Type.STRING);
			cmd.SetValue("sigla", p_Sigla.ToUpper());

			DataTable tabelaResultado = ObterInformacoesDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Nome"].ToString();
			}

			return Saida;
		}

		public static string ObterSiglaDoEstado(int p_Codigo)
		{
			String Saida = "Estado não encontrado, verifique o codigo";
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.Sigla from ESTADOS t where t.codigo = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", p_Codigo.ToString());

			DataTable tabelaResultado = ObterInformacoesDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Sigla"].ToString();
			}

			return Saida;
		}

		public static string ObterSiglaDoEstado(string p_Nome)
		{
			String Saida = "Estado não encontrado, verifique a sigla";
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.Sigla from ESTADOS t where t.Nome = #nome#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.SetValue("nome", p_Nome);

			DataTable tabelaResultado = ObterInformacoesDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Sigla"].ToString();
			}

			return Saida;
		}

		public static string ObterCodigoDoEstado(string p_Sigla)
		{
			String Saida = "Código não encontrado, verifique o nome!";
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.codigo from ESTADOS t where t.sigla = #sigla#";
			cmd.AddParameter("sigla", Spartacus.Database.Type.STRING);
			cmd.SetValue("sigla", p_Sigla.ToUpper());

			DataTable tabelaResultado = ObterInformacoesDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Codigo"].ToString();
			}

			return Saida;
		}

		private static Estado ConverterRowParaEntidade(DataRow LinhaDaTabela)
		{
			Estado estadoBase = new Estado();

			estadoBase.Codigo = Convert.ToInt16(LinhaDaTabela["Codigo"]);
			estadoBase.Sigla = LinhaDaTabela["Sigla"].ToString();
			estadoBase.Nome = LinhaDaTabela["Nome"].ToString();

			return estadoBase;
		}

		private static DataTable ObterInformacoesDoBanco(string p_Query)
		{
			DataTable tabelaSaida = new DataTable();
			Spartacus.Database.Generic database;
			try
			{
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoLugares());
				tabelaSaida = database.Query(p_Query, "Resultado");
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return tabelaSaida;
		}
	}
}
