using System;
using System.Data;
using System.Collections.Generic;

namespace DotCEP.Localidades
{
	public class Municipio
	{
		#region Propriedades
		public int CodigoEstado { get; set; }
		public int Codigo { get; set; }
		public string Nome { get; set; }
		#endregion

		private static Municipio ConverterRowParaEntidade(DataRow LinhaDaTabela)
		{
			Municipio municipioBase = new Municipio();

			municipioBase.Codigo = Convert.ToInt16(LinhaDaTabela["Codigo"]);
			municipioBase.CodigoEstado = Convert.ToInt16(LinhaDaTabela["CodigoEstado"]);
			municipioBase.Nome = LinhaDaTabela["Nome"].ToString();

			return municipioBase;
		}

		private static DataTable ObterInformacoesDoBanco(String p_Query)
		{
			DataTable tabelaSaida = new DataTable();
			Spartacus.Database.Generic database;
			try
			{
				database = new Spartacus.Database.Sqlite(Ferramentas.ObterCaminhoBancoLugare());
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
