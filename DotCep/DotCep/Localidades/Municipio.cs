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
			var listaDeMunicipios = new List<Municipio>();
            var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.* from Municipios t";
			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		public static List<Municipio> ObterListaDeMunicipio(UF SiglaEstado)
		{
			var listaDeMunicipios = new List<Municipio>();
            var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.* from Municipios t where t.CodigoEstado = #codigo#";
			cmd.AddParameter("codigo", SpartacusMin.Database.Type.INTEGER);
			cmd.SetValue("codigo", Convert.ToInt16(SiglaEstado).ToString());

			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		public static List<Municipio> ObterListaDeMunicipio(string Estado)
		{
			var listaDeMunicipios = new List<Municipio>();
            var cmd = new SpartacusMin.Database.Command();

            if (Estado.Length == 2)
			{
				cmd.v_text = "select m.* from Municipios m  " +
				"inner join Estados e " +
				"on e.codigo = m.codigoestado" +
				"  where e.sigla = #sigla#";


				cmd.AddParameter("sigla", SpartacusMin.Database.Type.STRING);

				cmd.SetValue("sigla", Estado);
			}
			else
			{
				cmd.v_text = "select m.* from Municipios m  " +
				"inner join Estados e " +
				"on e.codigo = m.codigoestado" +
				" where e.nome = #nome#";

				cmd.AddParameter("nome", SpartacusMin.Database.Type.STRING);

				cmd.SetValue("nome", Estado);

			}
			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		#endregion

		#region Nome
		public static string ObterNomeDoMunicipio(uint CodigoMunicipio)
		{
			var saida = String.Empty;
            var cmd = new SpartacusMin.Database.Command();
            DataTable tabelaResultado;

			cmd.v_text = "select t.nome from Municipios t where t.codigo = #codigo#";
			cmd.AddParameter("codigo", SpartacusMin.Database.Type.INTEGER);
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
			var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.Codigo from Municipios t where t.nome = #nome# and t.CodigoEstado = #estado#";
			cmd.AddParameter("nome", SpartacusMin.Database.Type.STRING);
			cmd.AddParameter("estado", SpartacusMin.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", Convert.ToInt16(SiglaEstado).ToString());

			return BuscarCodigoNoBanco(cmd.GetUpdatedText());
		}

		public static int ObterCodigoDoMunicipio(string NomeMunicipio, string Estado)
		{
			var cmd = new SpartacusMin.Database.Command();

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

			cmd.AddParameter("nome", SpartacusMin.Database.Type.STRING);
			cmd.AddParameter("estado", SpartacusMin.Database.Type.STRING);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", Estado);

			return BuscarCodigoNoBanco(cmd.GetUpdatedText());
		}

		public static int ObterCodigoDoMunicipio(string NomeMunicipio, int CodigoEstado)
		{
			var cmd = new SpartacusMin.Database.Command();

            cmd.v_text = "select t.Codigo from Municipios t where t.nome = #nome# and t.CodigoEstado = #estado#";
			cmd.AddParameter("nome", SpartacusMin.Database.Type.STRING);
			cmd.AddParameter("estado", SpartacusMin.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", CodigoEstado.ToString());

			return BuscarCodigoNoBanco(cmd.GetUpdatedText());
		}

		private static int BuscarCodigoNoBanco(string query)
		{
			var saida = 0;
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
			SpartacusMin.Database.Command cmd = new SpartacusMin.Database.Command();

			cmd.v_text = "select m.* from estados e " +
					"inner join municipios m " +
					"on m.codigoestado = e.codigo " +
					"where m.nome = #nome# and e.codigo = #codigo#";


			cmd.AddParameter("nome", SpartacusMin.Database.Type.STRING);
			cmd.AddParameter("codigo", SpartacusMin.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("codigo", Convert.ToInt16(SiglaEstado).ToString());

			//E retornado apenas o primeiro valor da lista caso ele tenha mais de um.
			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		public static Municipio ObterInformacoesDoMunicipio(string NomeMunicipio, string Estado)
		{
			Municipio municipioBase = new Municipio();
			SpartacusMin.Database.Command cmd = new SpartacusMin.Database.Command();

			if (Estado.Length == 2)
			{
				cmd.v_text = "select m.* from estados e " +
					"inner join municipios m " +
					"on m.codigoestado = e.codigo " +
					"where m.nome = #nome# and e.sigla = #sigla#";

				cmd.AddParameter("nome", SpartacusMin.Database.Type.STRING);
				cmd.AddParameter("sigla", SpartacusMin.Database.Type.STRING);

				cmd.SetValue("nome", NomeMunicipio);
				cmd.SetValue("sigla", Estado);
			}
			else
			{
				cmd.v_text = "select m.* from estados e " +
					"inner join municipios m " +
					"on m.codigoestado = e.codigo " +
					"where m.nome = #nomemunicipio# and e.nome = #nomeestado#";

				cmd.AddParameter("nomemunicipio", SpartacusMin.Database.Type.STRING);
				cmd.AddParameter("nomeestado", SpartacusMin.Database.Type.STRING);

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
			SpartacusMin.Database.Command cmd = new SpartacusMin.Database.Command();

			cmd.v_text = "Select * from Municipios m where m.Codigo = #codigo#";
			cmd.AddParameter("codigo", SpartacusMin.Database.Type.INTEGER);
			cmd.SetValue("codigo", CodigoMunicipio.ToString());

			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		#endregion

		private static List<Municipio> ObterListaDoBanco(string p_Query)
		{
			SpartacusMin.Database.Generic database;
			var ListaDeMunicipios = new List<Municipio>();

            try
			{
				database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());

				ListaDeMunicipios = database.QueryList<Municipio>(p_Query);
			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return ListaDeMunicipios;
		}
	}
}
