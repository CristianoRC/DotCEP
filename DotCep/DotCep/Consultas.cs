using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotCEP
{
	public static class Consultas
	{
		public static Endereco ObterEnderecoCompleto(string CEP)
		{
			Endereco enderecoBase = new Endereco();
			String StrJSON = String.Empty;

			if (Validacoes.VerificarValidadeDoCep(CEP))
			{
				CEP = CEP.Replace("-", "").Trim();

				StrJSON = Cache.ObterJsonDoCacheLocal(CEP);

				if (StrJSON != String.Empty)
				{
					enderecoBase = JsonConvert.DeserializeObject<Endereco>(StrJSON);
				}
				else
				{
					StrJSON = ControleRequisicoes.ObterJSON(ControleDeUrl.GerarURLDaPesquisa(CEP));

					enderecoBase = JsonConvert.DeserializeObject<Endereco>(StrJSON);

					Cache.Criar(CEP, StrJSON);
				}
			}

			return enderecoBase;
		}

		public static List<Endereco> ObterListaDeEnderecos(UF UF, String Cidade, String Logradouro)
		{
			List<Endereco> enderecosDeRetorno = new List<Endereco>();

			List<string> EnderecosDoCache = Cache.ObterJsonDoCacheLocal(UF, Cidade, Logradouro);

			if (EnderecosDoCache.Count != 0)
			{
				foreach (string item in EnderecosDoCache)
				{
					enderecosDeRetorno.Add(JsonConvert.DeserializeObject<Endereco>(item));
				}
			}
			else
			{
				String url = ControleDeUrl.GerarURLDaPesquisa(UF, Cidade, Logradouro);
				String StrJSON = ControleRequisicoes.ObterJSON(url);

				enderecosDeRetorno = JsonConvert.DeserializeObject<List<Endereco>>(StrJSON);

				Cache.Criar(UF, Cidade, Logradouro, StrJSON);
			}

			return enderecosDeRetorno;
		}
	}
}
