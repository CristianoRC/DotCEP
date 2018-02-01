using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotCEP
{
    public class Endereco
    {
        #region Propriedades
        public CEP CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public UF UF { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        #endregion


        #region Construtores

        public Endereco() { }
        public Endereco(CEP cep)
        {
            var enderecoBase = new Endereco();

            if (cep.Valido)
            {
                var cache = new Cache();

                enderecoBase = cache.ObterCache(cep.Valor);

                if (enderecoBase.CEP.Valor != string.Empty)
                {
                    return enderecoBase;
                }
                else
                {
                    var url = ControleDeUrl.GerarURLDaPesquisa(cep.Valor);

                    var requisicaoJSON = Requisicoes.ObterJSON(url);

                    cache.Criar(cep.Valor, requisicaoJSON);

                    return JsonConvert.DeserializeObject<Endereco>(requisicaoJSON);
                }
            }
        }

        #endregion

        //TODO: Busca por sigla.
        public static List<Endereco> Buscar(UF UF, String Cidade, String Logradouro)
        {
            var enderecoBase = new Endereco();
            var enderecosDoCache = Cache.ObterCache(UF, Cidade, Logradouro);

            if (enderecosDoCache.Count != 0)
            {
                return enderecosDoCache;
            }
            else
            {
                var url = ControleDeUrl.GerarURLDaPesquisa(UF, Cidade, Logradouro);
                var StrJSON = Requisicoes.ObterJSON(url);

                Cache.Criar(UF, Cidade, Logradouro, StrJSON);

                return JsonConvert.DeserializeObject<List<Endereco>>(StrJSON);
            }
        }
    }
}

