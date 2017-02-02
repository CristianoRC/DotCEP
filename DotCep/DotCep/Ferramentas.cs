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

		internal static string ObterCaminhoBancoLugares()
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
	}
}
