using System;

namespace DotCEP
{
    public static class Validacoes
    {
        public static bool VerificarExistenciaDoCEP(string CEP)
        {
            uint CEPsemFormato;

            if (VerificarValidadeDoCep(CEP))
            {
                CEP = CEP.Replace("-", "");

                CEPsemFormato = Convert.ToUInt32(CEP);

                String StrJSON = ControleJSON.ObterStringJSONS(ControleDeUrl.GerarURLDaPesquisa(CEPsemFormato));

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

        public static bool VerificarValidadeDoCep(string CEPformatado)
        {    
            if (CEPformatado.Trim().Length == 9)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(CEPformatado, ("[0-9]{5}-[0-9]{3}"));
            }
            else
            {
                return false;
            }
        }

    }
}

