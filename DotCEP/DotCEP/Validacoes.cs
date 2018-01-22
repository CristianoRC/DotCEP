namespace DotCEP
{
	public static class Validacoes
	{
	

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

