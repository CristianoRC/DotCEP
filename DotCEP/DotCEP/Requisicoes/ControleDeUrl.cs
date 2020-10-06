namespace DotCEP
{
    internal static class ControleDeUrl
    {
        internal static string GerarUrlDaPesquisa(string cep)
        {
            cep = cep.Replace("-", "");

            return $"https://viacep.com.br/ws/{cep}/json/";
        }

        internal static string GerarUrlDaPesquisa(UF uf, string cidade, string logradouro)
        {
            return $"https://viacep.com.br/ws/{uf.ToString()}/{cidade}/{logradouro}/json/";
        }
    }
}