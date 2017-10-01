using System;
using System.Data;

namespace DotCEP
{
	internal static class BancosDeDados
	{
		static string caminhoexecutavel = AppDomain.CurrentDomain.BaseDirectory;

		internal static string ObterCaminhoBancoCache()
		{
			if (((int)Environment.OSVersion.Platform) < 4)
			{
				return $"{caminhoexecutavel}\\Cache\\Cache.db";// Windows
			}
			else
			{
				return $"{caminhoexecutavel}/Cache/Cache.db";// Linux e MacOSX			
			}
		}

		internal static string ObterCaminhoBancoLugares()
		{
			if (((int)Environment.OSVersion.Platform) < 4)
			{
				return $"{caminhoexecutavel}\\Cache\\Lugares.db";// Windows
			}
			else
			{
				return $"{caminhoexecutavel}/Cache/Lugares.db";// Linux e MacOSX
			}
		}

		internal static DataTable ObterTabelaDoBanco(string p_Query)
		{
			var tabelaSaida = new DataTable();
            SpartacusMin.Database.Generic database;
			try
			{
				database = new SpartacusMin.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());
				tabelaSaida = database.Query(p_Query, "Resultado");
			}
			catch (SpartacusMin.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return tabelaSaida;
		}
	}
}
