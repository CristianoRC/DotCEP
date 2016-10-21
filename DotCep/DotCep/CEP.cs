using System;
using Newtonsoft.Json;

namespace DotCep
{
    public static class CEP
    {
        public static Endereco ObterEndereco(uint CEP)
        {
            Endereco enderecoBase = new Endereco();

            if (VerificarValidadeDoCep(CEP))
            {
                String StrJSON = ControleJSON.ObterStringJSONS(CEP);

                if (VerificarExistencia(StrJSON))
                {
                    enderecoBase = JsonConvert.DeserializeObject<Endereco>(StrJSON);
                }
            }

            return enderecoBase;
        }

        /// <summary>
        /// Verifica se o CEP (válido) existe, ou são apenas 8 numeros que não formam um CEP verdadeiro.
        /// </summary>
        /// <returns><c>true</c>, if existencia was verificared, <c>false</c> otherwise.</returns>
        /// <param name="JSON">JSO.</param>
        private static bool VerificarExistencia(string JSON)
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

    }
}

