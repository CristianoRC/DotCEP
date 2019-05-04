using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotCEP
{
    internal static class ManipulacaoJSON
    {
        internal static string ObterCEPdaStrJSON(string strJSON)
        {
            var enderecoBase = JsonConvert.DeserializeObject<Endereco>(strJSON);

            var CEPtemp = enderecoBase.CEP.Replace("-", "");

            return CEPtemp;
        }

        internal static List<Endereco> ObterEnderecos(List<string> enderecosJSON)
        {
            var enderecosDeRetorno = new List<Endereco>();

            foreach (var item in enderecosJSON) enderecosDeRetorno.Add(JsonConvert.DeserializeObject<Endereco>(item));

            return enderecosDeRetorno;
        }

        internal static Endereco ObterEndereco(string enderecoJSON)
        {
            return JsonConvert.DeserializeObject<Endereco>(enderecoJSON);
        }

        /// <summary>
        ///     Separa o array JSON em objetos e logo após converte novamente para um objeto em JSON.
        /// </summary>
        /// <param name="strJSON">String json.</param>
        internal static List<string> SepararArrayJSON(string strJSON)
        {
            var EnderecosJSON = new List<string>();

            var Enderecos = new List<Endereco>();

            Enderecos = JsonConvert.DeserializeObject<List<Endereco>>(strJSON);


            foreach (var item in Enderecos) EnderecosJSON.Add(JsonConvert.SerializeObject(item));

            return EnderecosJSON;
        }
    }
}