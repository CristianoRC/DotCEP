using System;

namespace DotCEP
{
	public static class Validacoes
	{
		public static bool VerificarValidadeDoCep(string CEP)
		{
			if (CEP.Trim().Length == 9)
			{
				return System.Text.RegularExpressions.Regex.IsMatch(CEP, ("[0-9]{5}-[0-9]{3}"));
			}
			else if (CEP.Trim().Length == 8)
			{
				CEP = Formatacao.FormatarCEP(CEP);
				return System.Text.RegularExpressions.Regex.IsMatch(CEP, ("[0-9]{5}-[0-9]{3}"));
			}
			else
			{
				return false;
			}
		}

		public static bool VerificarExistenciaDoCEP(string CEP)
		{
			if (VerificarValidadeDoCep(CEP))
			{
				CEP = CEP.Replace("-", "");

				String StrJSON = ControleRequisicoes.ObterStringJSONS(ControleDeUrl.GerarURLDaPesquisa(CEP));

				if (!StrJSON.Contains("\"erro\": true"))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}
	}
}

