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
					StrJSON = ControleRequisicoes.ObterStringJSONS(ControleDeUrl.GerarURLDaPesquisa(CEP));

					enderecoBase = JsonConvert.DeserializeObject<Endereco>(StrJSON);

					Cache.Criar(CEP, StrJSON);
				}
			}

			return enderecoBase;
		}

		public static List<Endereco> ObterListaDeEnderecos(UF UF, String Cidade, String Logradouro)
		{
			List<Endereco> Enderecos = new List<Endereco>();

			List<string> EnderecosJSON = Cache.ObterJsonDoCacheLocal(UF, Cidade, Logradouro);

			if (EnderecosJSON.Count != 0)
			{
				foreach (string item in EnderecosJSON)
				{
					Enderecos.Add(JsonConvert.DeserializeObject<Endereco>(item));
				}
			}
			else
			{
				String url = ControleDeUrl.GerarURLDaPesquisa(UF, Cidade, Logradouro);
				String StrJSON = ControleRequisicoes.ObterStringJSONS(url);

				Enderecos = JsonConvert.DeserializeObject<List<Endereco>>(StrJSON);

				Cache.Criar(UF, Cidade, Logradouro, StrJSON);
			}

			return Enderecos;
		}
	}
}
