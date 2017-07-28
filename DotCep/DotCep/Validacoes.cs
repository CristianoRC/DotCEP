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
			var enderecoBase = new Endereco();
			var requisicaoJSON = string.Empty;

			if (VerificarValidadeDoCep(CEP))
			{

				CEP = CEP.Replace("-", "").Trim();
				enderecoBase = Cache.ObterCache(CEP);


				if (enderecoBase.cep == string.Empty)
				{
					requisicaoJSON = Requisicoes.ObterJSON(ControleDeUrl.GerarURLDaPesquisa(CEP));

					Cache.Criar(CEP, requisicaoJSON);
				}
				else
				{
					return true;
				}


				if (verificarProblemasNaRequisicao(requisicaoJSON))
				{
					return false;
				}
				else
				{
					return true;
				}

			}
			else
			{
				return false;
			}
		}

		private static bool verificarProblemasNaRequisicao(string strJSON)
		{
            return strJSON.Contains("\"erro\": true");
        }
	}
}

