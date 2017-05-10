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
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.* from ESTADOS t order by t.Nome";

			try
			{

				listaDeEstados = ObterListaDoBanco(cmd.GetUpdatedText());
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
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


			DataTable tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

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

			DataTable tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

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

			DataTable tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

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

			DataTable tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Sigla"].ToString();
			}

			return Saida;
		}

		public static string ObterCodigoDoEstado(string p_SiglaOuNome)
		{
			String Saida = "Código não encontrado, verifique o nome!";
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			if (p_SiglaOuNome.Length == 2) //Se tiver 2 caracteres é uma sigla
			{
				cmd.v_text = "select t.codigo from ESTADOS t where t.sigla = #parametro#";

				p_SiglaOuNome = p_SiglaOuNome.ToUpper();
			}
			else
			{
				cmd.v_text = "select t.codigo from ESTADOS t where t.Nome = #parametro#";
			}

			cmd.AddParameter("parametro", Spartacus.Database.Type.STRING);
			cmd.SetValue("parametro", p_SiglaOuNome);

			DataTable tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Codigo"].ToString();
			}

			return Saida;
		}

		private static DataTable ObterTabelaDoBanco(string p_Query)
		{
			DataTable tabelaSaida = new DataTable();
			Spartacus.Database.Generic database;
			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());
				tabelaSaida = database.Query(p_Query, "Resultado");
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return tabelaSaida;
		}

		private static List<Estado> ObterListaDoBanco(string p_Query)
		{
			Spartacus.Database.Generic database;
			List<Estado> ListaDeEstados = new List<Estado>();

			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());

				ListaDeEstados = database.QueryList<Estado>(p_Query);
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return ListaDeEstados;
		}
	}
}
