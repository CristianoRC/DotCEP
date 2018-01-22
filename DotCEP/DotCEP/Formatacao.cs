using System;

namespace DotCEP
{
	public static class Formatacao
	{
		internal static string FormatarStrParametros(UF p_UF, string Localidade, string Logradouro)
		{
			return String.Format("{0},{1},{2}", p_UF.ToString(), Localidade, Logradouro);
		}
	}
}

