using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DotCEP
{
    public static class Consultas
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
        /// Verifica se o CEP existe, ou são apenas 8 numeros que não formam um CEP verdadeiro.
        /// </summary>
        /// <returns><c>true</c>, if existencia was verificared, <c>false</c> otherwise.</returns>
        /// <param name="JSON">JSO.</param>
        public static bool VerificarExistenciaDoCEP(uint CEP)
        {
            if (VerificarValidadeDoCep(CEP))
            {
                String StrJSON = ControleJSON.ObterStringJSONS(GerarURLDaPesquisaPorCEP(CEP));

                if (!StrJSON.Contains("\"erro\": true"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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
