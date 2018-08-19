using System;
using DotCEP.Enumeradores;

namespace DotCEP
{
    internal static class ControleDeUrl
    {
        internal static string GerarURLDaPesquisa(string CEP)
        {
            CEP = CEP.Replace("-", "");

            return $"https://viacep.com.br/ws/{CEP}/json/";
        }

        internal static string GerarURLDaPesquisa(UF UF, string Cidade, String Logradouro)
        {
            return $"https://viacep.com.br/ws/{UF.ToString()}/{Cidade}/{Logradouro}/json/";
        }
    }
}