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
			string CEPformatado = CEP;

			if (CEPformatado.Length == 8)
			{
				CEPformatado = CEPformatado.Substring(0, 5) + "-" + CEPformatado.Substring(5, 3);
			}

			return CEPformatado;
		}
	}
}

