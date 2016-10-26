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

            if (CEP.ToString().Length == 8)
            {
                String StrJSON = ControleRequisicoes.ObterStringJSONS(ControleDeUrl.GerarURLDaPesquisa(CEP));

                enderecoBase = JsonConvert.DeserializeObject<Endereco>(StrJSON);
            }

            return enderecoBase;
        }

        /// <summary>
        /// Possíveis enderecos, utilizando o filtro de estado, cidade e logradouro,
        /// </summary>
        /// <returns>The lista de possiveis enderecos.</returns>
        /// <param name="UF">UF.</param>
        /// <param name="Cidade">Cidade.</param>
        /// <param name="logradouro">Logradouro.</param>
        public static List<Endereco> ObterListaDeEnderecos(UF UF, String Cidade, String Logradouro)
        {
            List<Endereco> Enderecos = new List<Endereco>();
            String url = ControleDeUrl.GerarURLDaPesquisa(UF, Cidade, Logradouro);
            String StrJSON = ControleRequisicoes.ObterStringJSONS(url);

            Enderecos = JsonConvert.DeserializeObject<List<Endereco>>(StrJSON);

            return Enderecos;
        }

        /// <summary>
        /// Obtem um CEP, mas só se as informações forem unicos e verdadeiros, se não ele retorna valores Empty.
        /// </summary>
        /// <returns>The CEP.</returns>
        /// <param name="UF">UF.</param>
        /// <param name="Cidade">Cidade.</param>
        /// <param name="Logradouro">Logradouro.</param>
        /// <param name="Formatado">If set to <c>true</c> formatado.</param>
        public static string ObterCEP(UF UF, String Cidade, String Logradouro, bool Formatado)
        {
            string saida = string.Empty;
            List<Endereco> ListaDeEnderecos = ObterListaDeEnderecos(UF, Cidade, Logradouro);

            if (ListaDeEnderecos.Count == 1)
            {
                if (Formatado)
                {
                    saida = ListaDeEnderecos[0].cep;
                }
                else
                {
                    saida = ListaDeEnderecos[0].cep.Replace("-", "");
                }  
            }
            else
            {
                if (Formatado)
                {
                    saida = "     -   ";
                }
                else
                {
                    saida = String.Empty;
                }
            }

            return saida;
        }
    }
}
