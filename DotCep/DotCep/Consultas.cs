using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotCEP
{
	public static class Consultas
	{
		public static Endereco ObterEnderecoCompleto(string CEP)
		{
			var enderecoBase = new Endereco();

            if (Validacoes.VerificarValidadeDoCep(CEP))
			{
				CEP = CEP.Replace("-", "").Trim();

				enderecoBase = Cache.ObterCache(CEP);

				if (enderecoBase.cep != null)
				{
					return enderecoBase;
				}
				else
				{
					var url = ControleDeUrl.GerarURLDaPesquisa(CEP);

					var requisicaoJSON = Requisicoes.ObterJSON(url);

					Cache.Criar(CEP, requisicaoJSON);

					return JsonConvert.DeserializeObject<Endereco>(requisicaoJSON);
				}
			}

			return enderecoBase;
		}

		public static List<Endereco> ObterListaDeEnderecos(UF UF, String Cidade, String Logradouro)
		{

			var enderecosDoCache = Cache.ObterCache(UF, Cidade, Logradouro);

			if (enderecosDoCache.Count != 0)
			{
				return enderecosDoCache;
			}
			else
			{
				var url = ControleDeUrl.GerarURLDaPesquisa(UF, Cidade, Logradouro);
				var StrJSON = Requisicoes.ObterJSON(url);

				Cache.Criar(UF, Cidade, Logradouro, StrJSON);

				return JsonConvert.DeserializeObject<List<Endereco>>(StrJSON);
			}
		}
	}
}
