using System;
using System.Data;
using System.Collections.Generic;

namespace DotCEP.Localidades
{
	public class Municipio
	{
		#region Propriedades

		public int CodigoEstado { get; private set; }

		public int Codigo { get; private set; }

		public string Nome { get; private set; }

		#endregion

		#region Lista
		public static List<Municipio> ObterListaDeMunicipio()
		{
			List<Municipio> listaDeMunicipios = new List<Municipio>();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.* from Municipios t";
			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		public static List<Municipio> ObterListaDeMunicipio(UF SiglaEstado)
		{
			List<Municipio> listaDeMunicipios = new List<Municipio>();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.* from Municipios t where t.CodigoEstado = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", Convert.ToInt16(SiglaEstado).ToString());

			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		public static List<Municipio> ObterListaDeMunicipio(string Estado)
		{
			List<Municipio> listaDeMunicipios = new List<Municipio>();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			if (Estado.Length == 2)
			{
				cmd.v_text = "select m.* from Municipios m  " +
				"inner join Estados e " +
				"on e.codigo = m.codigoestado" +
				"  where e.sigla = #sigla#";


				cmd.AddParameter("sigla", Spartacus.Database.Type.STRING);

				cmd.SetValue("sigla", Estado);
			}
			else
			{
				cmd.v_text = "select m.* from Municipios m  " +
				"inner join Estados e " +
				"on e.codigo = m.codigoestado" +
				" where e.nome = #nome#";

				cmd.AddParameter("nome", Spartacus.Database.Type.STRING);

				cmd.SetValue("nome", Estado);

			}
			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		#endregion

		#region Nome
		public static string ObterNomeDoMunicipio(uint CodigoMunicipio)
		{
			String saida = String.Empty;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabelaResultado;

			cmd.v_text = "select t.nome from Municipios t where t.codigo = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", CodigoMunicipio.ToString());

			tabelaResultado = BancosDeDados.ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				saida = tabelaResultado.Rows[0]["nome"].ToString();
			}

			return saida;
		}
		#endregion

		#region Codigo

		public static int ObterCodigoDoMunicipio(string NomeMunicipio, UF SiglaEstado)
		{
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.Codigo from Municipios t where t.nome = #nome# and t.CodigoEstado = #estado#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("estado", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", Convert.ToInt16(SiglaEstado).ToString());

			return BuscarCodigoNoBanco(cmd.GetUpdatedText());
		}

		public static int ObterCodigoDoMunicipio(string NomeMunicipio, string Estado)
		{
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			if (Estado.Length == 2)
			{
				cmd.v_text = "select t.Codigo from Municipios t " +
				"inner join estados e " +
				"on e.codigo = t.codigoestado " +
				"where t.nome = #nome# and e.sigla = #estado#";
			}
			else
			{
				cmd.v_text = "select t.Codigo from Municipios t " +
				"inner join estados e " +
				"on e.codigo = t.codigoestado " +
				"where t.nome = #nome# and e.nome = #estado#";
			}

			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("estado", Spartacus.Database.Type.STRING);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", Estado);

			return BuscarCodigoNoBanco(cmd.GetUpdatedText());
		}

		public static int ObterCodigoDoMunicipio(string NomeMunicipio, int CodigoEstado)
		{
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.Codigo from Municipios t where t.nome = #nome# and t.CodigoEstado = #estado#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("estado", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", CodigoEstado.ToString());

			return BuscarCodigoNoBanco(cmd.GetUpdatedText());
		}

		private static int BuscarCodigoNoBanco(string query)
		{
			int saida = 0;
			DataTable tabelaResultado;

			tabelaResultado = BancosDeDados.ObterTabelaDoBanco(query);

			if (tabelaResultado.Rows.Count != 0)
			{
				saida = Convert.ToInt32(tabelaResultado.Rows[0]["Codigo"].ToString());
			}

			return saida;
		}

		#endregion

		#region Informacoes

		public static Municipio ObterInformacoesDoMunicipio(string NomeMunicipio, UF SiglaEstado)
		{
			Municipio municipioBase = new Municipio();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select m.* from estados e " +
					"inner join municipios m " +
					"on m.codigoestado = e.codigo " +
					"where m.nome = #nome# and e.codigo = #codigo#";


			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("codigo", Convert.ToInt16(SiglaEstado).ToString());

			//E retornado apenas o primeiro valor da lista caso ele tenha mais de um.
			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		public static Municipio ObterInformacoesDoMunicipio(string NomeMunicipio, string Estado)
		{
			Municipio municipioBase = new Municipio();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			if (Estado.Length == 2)
			{
				cmd.v_text = "select m.* from estados e " +
					"inner join municipios m " +
					"on m.codigoestado = e.codigo " +
					"where m.nome = #nome# and e.sigla = #sigla#";

				cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
				cmd.AddParameter("sigla", Spartacus.Database.Type.STRING);

				cmd.SetValue("nome", NomeMunicipio);
				cmd.SetValue("sigla", Estado);
			}
			else
			{
				cmd.v_text = "select m.* from estados e " +
					"inner join municipios m " +
					"on m.codigoestado = e.codigo " +
					"where m.nome = #nomemunicipio# and e.nome = #nomeestado#";

				cmd.AddParameter("nomemunicipio", Spartacus.Database.Type.STRING);
				cmd.AddParameter("nomeestado", Spartacus.Database.Type.STRING);

				cmd.SetValue("nomemunicipio", NomeMunicipio);
				cmd.SetValue("nomeestado", Estado);
			}

			//E retornado apenas o primeiro valor da lista caso ele tenha mais de um.
			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		public static Municipio ObterInformacoesDoMunicipio(uint CodigoMunicipio)
		{
			Municipio municipioBase = new Municipio();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select * from Municipios m where m.Codigo = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", CodigoMunicipio.ToString());

			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		#endregion

		private static List<Municipio> ObterListaDoBanco(string p_Query)
		{
			Spartacus.Database.Generic database;
			List<Municipio> ListaDeMunicipios = new List<Municipio>();

			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());

				ListaDeMunicipios = database.QueryList<Municipio>(p_Query);
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return ListaDeMunicipios;
		}
	}
}
