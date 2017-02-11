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
			string StrJSON;

			if (VerificarValidadeDoCep(CEP))
			{

				CEP = CEP.Replace("-", "").Trim();
				StrJSON = Cache.ObterJsonDoCacheLocal(CEP);


				if (StrJSON == string.Empty)
				{
					StrJSON = ControleRequisicoes.ObterJSON(ControleDeUrl.GerarURLDaPesquisa(CEP));

					Cache.Criar(CEP, StrJSON);
				}


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

