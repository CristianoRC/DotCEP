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
                String StrJSON = ControleJSON.ObterStringJSONS(GerarURLDaPesquisa(CEP));

                enderecoBase = JsonConvert.DeserializeObject<Endereco>(StrJSON);
            }

            return enderecoBase;
        }

        /// <summary>
        /// Possíveis enderecos, utilizando o filtro de estado, cidade e logradouro,
        /// </summary>
        /// <returns>The lista de possiveis enderecos.</returns>
        /// <param name="UF">U.</param>
        /// <param name="Cidade">Cidade.</param>
        /// <param name="logradouro">Logradouro.</param>
        public static List<Endereco> ObterListaDeEnderecos(UF UF, String Cidade, String Logradouro)
        {
            List<Endereco> Enderecos = new List<Endereco>();
            String url = GerarURLDaPesquisa(UF, Cidade, Logradouro);
            String StrJSON = ControleJSON.ObterStringJSONS(url);

            Enderecos = JsonConvert.DeserializeObject<List<Endereco>>(StrJSON);

            return Enderecos;
        }

        /// <summary>
        /// Obtem um CEP, mas só se as informações forem unicos e verdadeiros, se não ele retorna valores Empty.
        /// </summary>
        /// <returns>The CE.</returns>
        /// <param name="UF">U.</param>
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

        public static bool VerificarExistenciaDoCEP(string CEP)
        {
            uint CEPsemFormato;

            if (VerificarValidadeDoCep(CEP))
            {
                CEP = CEP.Replace("-", "");

                CEPsemFormato = Convert.ToUInt32(CEP);

                String StrJSON = ControleJSON.ObterStringJSONS(GerarURLDaPesquisa(CEPsemFormato));

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

        public static string FormatarCEP(uint CEP)
        {
            string CEPformatado = CEP.ToString();

            if (CEPformatado.Length == 8)
            {
                CEPformatado = CEPformatado.Substring(0, 5) + "-" + CEPformatado.Substring(5, 3);
            }

            return  CEPformatado;
        }

        public static string FormatarCEP(string CEP)
        {
            string CEPformatado = CEP;

            if (CEPformatado.Length == 8)
            {
                CEPformatado = CEPformatado.Substring(0, 5) + "-" + CEPformatado.Substring(5, 3);
            }

            return  CEPformatado;
        }



        private static string GerarURLDaPesquisa(uint CEP)
        {
            const String CaminhoPadrao = @"https://viacep.com.br/ws/{0}/json/";
            return String.Format(CaminhoPadrao, CEP.ToString());
        }

        private static string GerarURLDaPesquisa(UF UF, string Cidade, String Logradouro)
        {
            const String CaminhoPadrao = @"https://viacep.com.br/ws/{0}/{1}/{2}/json/";

            string caminhoFinal = String.Format(CaminhoPadrao, UF.ToString(), Cidade, Logradouro);

            return caminhoFinal;
        }
    }
}
