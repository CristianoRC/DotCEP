using System;

namespace DotCEP
{
    internal static class ControleDeUrl
    {
        internal static string GerarURLDaPesquisa(uint CEP)
        {
            const String CaminhoPadrao = @"https://viacep.com.br/ws/{0}/json/";
            return String.Format(CaminhoPadrao, CEP.ToString());
        }

        internal static string GerarURLDaPesquisa(UF UF, string Cidade, String Logradouro)
        {
            const String CaminhoPadrao = @"https://viacep.com.br/ws/{0}/{1}/{2}/json/";

            string caminhoFinal = String.Format(CaminhoPadrao, UF.ToString(), Cidade, Logradouro);

            return caminhoFinal;
        }
    }
}

