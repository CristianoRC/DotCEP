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


			if (Validacoes.VerificarValidadeDoCep(CEP))
			{
				if (CEP.Length == 9)
				{
					CEP = CEP.Replace("-", "");
				}

				String StrJSON = ControleRequisicoes.ObterStringJSONS(ControleDeUrl.GerarURLDaPesquisa(CEP));

				enderecoBase = JsonConvert.DeserializeObject<Endereco>(StrJSON);
			}

			return enderecoBase;
		}


		public static List<Endereco> ObterListaDeEnderecos(UF UF, String Cidade, String Logradouro)
		{
			List<Endereco> Enderecos = new List<Endereco>();
			String url = ControleDeUrl.GerarURLDaPesquisa(UF, Cidade, Logradouro);
			String StrJSON = ControleRequisicoes.ObterStringJSONS(url);

			Enderecos = JsonConvert.DeserializeObject<List<Endereco>>(StrJSON);

			return Enderecos;
		}


		public static string ObterCEP(UF UF, String Cidade, String Logradouro, bool Formatado)
		{
			string saida = string.Empty;
			List<Endereco> ListaDeEnderecos = ObterListaDeEnderecos(UF, Cidade, Logradouro);

			if (ListaDeEnderecos.Count == 1)
			{
				if (Formatado)
				{
					saida = ListaDeEnderecos[0].cep;
				}
				else
				{
					saida = ListaDeEnderecos[0].cep.Replace("-", "");
				}
			}
			else
			{
				if (Formatado)
				{
					saida = "     -   ";
				}
				else
				{
					saida = String.Empty;
				}
			}

			return saida;
		}
	}
}
