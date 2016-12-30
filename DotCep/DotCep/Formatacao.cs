using System;

namespace DotCEP
{
	public static class Formatacao
	{
		internal static string FormatarStrParametros(UF p_UF, string Localidade, string Logradouro)
		{
			return System.String.Format("{0},{1},{2}", p_UF.ToString(), Localidade, Logradouro);
		}

		public static string FormatarCEP(string CEP)
		{
			CEP = CEP.Replace(" ", "");
			CEP = CEP.Replace("-", "");

			try
			{
				return Convert.ToUInt64(CEP).ToString(@"00000\-000");
			}
			catch
			{
				return String.Empty;
			}
		}
	}
}

