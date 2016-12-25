using System;

namespace DotCEP
{
	internal static class Ferramentas
	{
		static String caminhoexecutavel = System.AppDomain.CurrentDomain.BaseDirectory;

		internal static string ObterCaminhoBancoCache()
		{
			if (((int)Environment.OSVersion.Platform) < 4)
			{
				return string.Format(@"{0}\\Cache\\Cache.db", caminhoexecutavel); // Windows
			}
			else
			{
				return String.Format(@"{0}/Cache/Cache.db", caminhoexecutavel); // Linux e MacOSX
			}
		}

		internal static string ObterCaminhoBancoLugare()
		{
			if (((int)Environment.OSVersion.Platform) < 4)
			{
				return string.Format(@"{0}\\Cache\\Lugares.db", caminhoexecutavel); // Windows
			}
			else
			{
				return String.Format(@"{0}/Cache/Lugares.db", caminhoexecutavel); // Linux e MacOSX
			}
		}

		internal static string FormatarStrParametros(UF p_UF, string Localidade, string Logradouro)
		{
			return String.Format("{0},{1},{2}", p_UF.ToString(), Localidade, Logradouro);
		}
	}
}
