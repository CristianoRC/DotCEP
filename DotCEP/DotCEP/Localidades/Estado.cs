using System;
using System.Collections.Generic;

namespace DotCEP.Localidades
{
	public class Estado
	{
		#region Propriedades
		public int Codigo { get; private set; }

		public string Sigla { get; private set; }

		public string Nome { get; private set; }

		#endregion

		#region Lista
		public static List<Estado> ObterListaDeEstados()
		{
			var listaDeEstados = new List<Estado>();
            var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.* from ESTADOS t order by t.Nome";

			try
			{

				listaDeEstados = ObterListaDoBanco(cmd.GetUpdatedText());
			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return listaDeEstados;
		}
		#endregion

		#region Nome
		public static string ObterNomeDoEstado(int p_Codigo)
		{
			var Saida = "Estado não encontrado, verifique o codigo";
            var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.nome from ESTADOS t where t.codigo = #codigo#";
			cmd.AddParameter("codigo", SpartacusMin.Database.Type.INTEGER);
			cmd.SetValue("codigo", p_Codigo.ToString());


			var tabelaResultado = BancosDeDados.ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Nome"].ToString();
			}

			return Saida;
		}

		public static string ObterNomeDoEstado(string p_Sigla)
		{
			String Saida = "Estado não encontrado, verifique a sigla";
			var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.nome from ESTADOS t where t.sigla = #sigla#";
			cmd.AddParameter("sigla", SpartacusMin.Database.Type.STRING);
			cmd.SetValue("sigla", p_Sigla.ToUpper());

			var tabelaResultado = BancosDeDados.ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Nome"].ToString();
			}

			return Saida;
		}

		#endregion

		#region Codigo
		public static string ObterCodigoDoEstado(string p_SiglaOuNome)
		{
			var saida = "Código não encontrado, verifique o nome!";
			var cmd = new SpartacusMin.Database.Command();

            if (p_SiglaOuNome.Length == 2) //Se tiver 2 caracteres é uma sigla
			{
				cmd.v_text = "select t.codigo from ESTADOS t where t.sigla = #parametro#";

				p_SiglaOuNome = p_SiglaOuNome.ToUpper();
			}
			else
			{
				cmd.v_text = "select t.codigo from ESTADOS t where t.Nome = #parametro#";
			}

			cmd.AddParameter("parametro", SpartacusMin.Database.Type.STRING);
			cmd.SetValue("parametro", p_SiglaOuNome);

			var tabelaResultado = BancosDeDados.ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				saida = tabelaResultado.Rows[0]["Codigo"].ToString();
			}

			return saida;
		}

		#endregion

		#region Sigla
		public static string ObterSiglaDoEstado(int p_Codigo)
		{
			var Saida = "Estado não encontrado, verifique o codigo";
            var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.Sigla from ESTADOS t where t.codigo = #codigo#";
			cmd.AddParameter("codigo", SpartacusMin.Database.Type.INTEGER);
			cmd.SetValue("codigo", p_Codigo.ToString());

			var tabelaResultado = BancosDeDados.ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Sigla"].ToString();
			}

			return Saida;
		}

		public static string ObterSiglaDoEstado(string p_Nome)
		{
			var Saida = "Estado não encontrado, verifique a sigla";
            var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.Sigla from ESTADOS t where t.Nome = #nome#";
			cmd.AddParameter("nome", SpartacusMin.Database.Type.STRING);
			cmd.SetValue("nome", p_Nome);

			var tabelaResultado = BancosDeDados.ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				Saida = tabelaResultado.Rows[0]["Sigla"].ToString();
			}

			return Saida;
		}

		#endregion

		private static List<Estado> ObterListaDoBanco(string p_Query)
		{
			SpartacusMin.Database.Generic database;
			var ListaDeEstados = new List<Estado>();

            try
			{
				database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());

				ListaDeEstados = database.QueryList<Estado>(p_Query);
			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return ListaDeEstados;
		}
	}
}
