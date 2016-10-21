using System;
using Newtonsoft.Json;

namespace DotCEP
{
    public static class Consulta
    {
        /// <summary>
        /// Retorna um objeto do tipo Enereco com todas as informações do CEP informado.
        /// </summary>
        /// <returns>The endereco completo.</returns>
        /// <param name="CEP">CE.</param>
        public static Endereco ObterEnderecoCompleto(uint CEP)
        {
            Endereco enderecoBase = new Endereco();

            if (VerificarValidadeDoCep(CEP))
            {
                String StrJSON = ControleJSON.ObterStringJSONS(GerarURLDaPesquisaPorCEP(CEP));

                enderecoBase = JsonConvert.DeserializeObject<Endereco>(StrJSON);
            }

            return enderecoBase;
        }

        /// <summary>
        /// Verifica se o CEP (válido) existe, ou são apenas 8 numeros que não formam um CEP verdadeiro.
        /// </summary>
        /// <returns><c>true</c>, if existencia was verificared, <c>false</c> otherwise.</returns>
        /// <param name="JSON">JSO.</param>
        private static bool VerificarExistenciaDoCEP(string JSON)
        {
            if (JSON.Contains("\"erro\": true"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Verifica se o CEP é válido, se ele contém 8 numeros.
        /// </summary>
        /// <returns><c>true</c>, if validade do cep was verificared, <c>false</c> otherwise.</returns>
        /// <param name="CEP">CE.</param>
        private static bool VerificarValidadeDoCep(uint CEP)
        {
            if (CEP.ToString().Length == 8)
            {
                return true;
            }
            else
            {    
                return false;
            }
        }

        private static string GerarURLDaPesquisaPorCEP(uint CEP)
        {
            const String CaminhoPadrao = @"https://viacep.com.br/ws/{0}/json/";
            return String.Format(CaminhoPadrao, CEP.ToString());
        }
    }
}
