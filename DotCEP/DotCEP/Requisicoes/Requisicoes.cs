using System;
using System.Net;
using System.Net.Http;

namespace DotCEP
{
    internal static class Requisicoes
    {
        internal static bool ExistenciaDoCEP(CEP cep)
        {
            try
            {
                var url = ControleDeUrl.GerarURLDaPesquisa(cep.Valor);

                var json = ObterJSON(url);

                return !ContemErros(json);
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        internal static string ObterJSON(string url)
        {
            try
            {
                var request = new HttpClient();

                var response = request.GetAsync(url).Result;

                if (response.StatusCode == HttpStatusCode.BadRequest)
                    throw new ArgumentException();

                return response.Content.ReadAsStringAsync().Result;
            }
            catch (ArgumentException ex)
            {
                throw new Exception($"Erro ao tentar fazer a requisição: {ex.Message}");
            }
        }

        internal static bool ContemErros(string strJSON)
        {
            return strJSON.Contains("\"erro\": true");
        }
    }
}