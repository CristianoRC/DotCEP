using System;

namespace DotCEP
{
	public static class Formatacao
	{
		internal static string FormatarStrParametros(UF p_UF, string Localidade, string Logradouro)
		{
			return String.Format("{0},{1},{2}", p_UF.ToString(), Localidade, Logradouro);
		}

		public static string FormatarCEP(string CEP)
		{
			CEP = CEP.Replace(" ", "");
			CEP = CEP.Replace("-", "");

			try
			{
				if (CEP.Length == 8)
				{
					return Convert.ToUInt64(CEP).ToString(@"00000\-000");
				}
				else
				{
					return String.Empty;
				}
			}
			catch
			{
				return "";
			}
		}
	}
}

