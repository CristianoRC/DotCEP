using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotCEP
{
    internal static class ManipulacaoJson
    {
        internal static string ObterCePdaStrJson(string strJson)
        {
            var enderecoBase = JsonConvert.DeserializeObject<Endereco>(strJson);

            var cepTemp = enderecoBase.CEP.Replace("-", "");

            return cepTemp;
        }

        internal static List<Endereco> ObterEnderecos(IEnumerable<string> enderecosJson)
        {
            var enderecosDeRetorno = new List<Endereco>();

            foreach (var item in enderecosJson) enderecosDeRetorno.Add(JsonConvert.DeserializeObject<Endereco>(item));

            return enderecosDeRetorno;
        }

        internal static Endereco ObterEndereco(string enderecoJson)
        {
            return JsonConvert.DeserializeObject<Endereco>(enderecoJson);
        }

        /// <summary>
        ///     Separa o array JSON em objetos e logo após converte novamente para um objeto em JSON.
        /// </summary>
        /// <param name="strJson">String json.</param>
        internal static List<string> SepararArrayJson(string strJson)
        {
            var enderecosJson = new List<string>();
            
           var enderecos = JsonConvert.DeserializeObject<List<Endereco>>(strJson);


            foreach (var item in enderecos) enderecosJson.Add(JsonConvert.SerializeObject(item));

            return enderecosJson;
        }
    }
}