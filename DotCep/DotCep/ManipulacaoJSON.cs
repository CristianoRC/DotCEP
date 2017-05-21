using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotCEP
{
	internal static class ManipulacaoJSON
	{


		internal static string ObterCEPdaStrJSON(string strJSON)
		{
			Endereco enderecobase = new Endereco();

			enderecobase = Newtonsoft.Json.JsonConvert.DeserializeObject<Endereco>(strJSON);

			string CEPtemp = enderecobase.cep.Replace("-", "");

			return CEPtemp;
		}

		internal static List<Endereco> ObterEnderecos(List<string> enderecosJSON)
		{
			List<Endereco> enderecosDeRetorno = new List<Endereco>();

			foreach (var item in enderecosJSON)
			{
				enderecosDeRetorno.Add(JsonConvert.DeserializeObject<Endereco>(item));
			}

			return enderecosDeRetorno;
		}

		internal static Endereco ObterEndereco(string enderecoJSON)
		{
			return JsonConvert.DeserializeObject<Endereco>(enderecoJSON);
		}

		/// <summary>
		/// Separa o array JSON em objetos e logo após converte novamente para um objeto em JSON.
		/// </summary>
		/// <param name="strJSON">String json.</param>
		internal static List<string> SepararArrayJSON(string strJSON)
		{
			List<string> EnderecosJSON = new List<string>();

			List<Endereco> Enderecos = new List<Endereco>();

			Enderecos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Endereco>>(strJSON);


			foreach (Endereco item in Enderecos)
			{
				EnderecosJSON.Add(Newtonsoft.Json.JsonConvert.SerializeObject(item));
			}

			return EnderecosJSON;
		}
	}
}
