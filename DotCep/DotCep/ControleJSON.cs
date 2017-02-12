using System.Collections.Generic;

namespace DotCEP
{
	internal static class ControleJSON
	{

		internal static string ObterCEPdaStrJSON(string strJSON)
		{
			Endereco enderecobase = new Endereco();

			enderecobase = Newtonsoft.Json.JsonConvert.DeserializeObject<Endereco>(strJSON);

			string CEPtemp = enderecobase.cep.Replace("-", "");

			return CEPtemp;
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
