using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

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

                return !VerificarProblemas(json);
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
            catch (System.Exception ex)
            {
                throw new System.Exception($"Erro ao tentar fazer a requisição: {ex.Message}");
            }
        }

        internal static bool VerificarProblemas(string strJSON)
        {
            return strJSON.Contains("\"erro\": true");
        }

    }
}

