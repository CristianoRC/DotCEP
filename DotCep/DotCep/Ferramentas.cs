using System;

namespace DotCEP
{
	internal static class Ferramentas
	{
		internal static string ObterCaminhoBanco()
		{
			String caminhoexecutavel = System.AppDomain.CurrentDomain.BaseDirectory;


			if (((int)Environment.OSVersion.Platform) < 4)
			{
				return string.Format(@"{0}\\Cache\\Cache.db", caminhoexecutavel); // Windows
			}
			else
			{
				return String.Format(@"{0}/Cache/Cache.db", caminhoexecutavel); // Linux e MacOSX
			}
		}

		internal static string FormatarStrParametros(UF p_UF, string Localidade, string Logradouro)
		{
			return String.Format("{0},{1},{2}", p_UF.ToString(), Localidade, Logradouro);
		}
	}
}
