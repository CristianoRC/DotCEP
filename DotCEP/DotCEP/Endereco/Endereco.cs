using System;
using System.Collections.Generic;
using System.Linq;
using DotCEP.Enumeradores;
using Newtonsoft.Json;

namespace DotCEP
{
    public class Endereco
    {
        private readonly IEnderecoCache _enderecoCache;

        #region Propriedades

        public CEP CEP { get; private set; }
        public string Logradouro { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Localidade { get; private set; }
        public UF UF { get; private set; }
        public string Unidade { get; private set; }
        public string Ibge { get; private set; }
        public string Gia { get; private set; }

        #endregion

        #region Construtores

        public Endereco(CEP cep)
        {
            if (cep.Valido)
            {
                //TODO: Verificar se o código funciona como o esperado
                var endereco = this;
                endereco = ObterEndereco(cep);
            }
        }

        public Endereco(CEP cep, IEnderecoCache enderecoCache)
        {
            _enderecoCache = enderecoCache;

            var endereco = this;

            if (cep.Valido)
            {
                var enderecoBase = _enderecoCache.ObterCache(cep);

                if (enderecoBase.CEP.Valor != null)
                {
                    endereco = enderecoBase;
                }
                else
                {
                    endereco = ObterEndereco(cep);
                    _enderecoCache.CriarCache(endereco);
                }
            }
        }

        #endregion

        public static IEnumerable<Endereco> Buscar(UF UF, string Cidade, string Logradouro,
            IEnderecoCache enderecoCache)
        {
            var enderecosDoCache = enderecoCache.ObterCache(UF, Cidade, Logradouro);

            if (enderecosDoCache.ToList().Count != 0)
            {
                return enderecosDoCache;
            }

            var enderecos = ObterEnderecos(UF, Cidade, Logradouro);

            enderecoCache.CriarCache(enderecos);
            return enderecos;
        }

        private Endereco ObterEndereco(CEP cep)
        {
            var enderecoBase = _enderecoCache.ObterCache(cep);

            var url = ControleDeUrl.GerarURLDaPesquisa(cep.Valor);

            var requisicaoJSON = Requisicoes.ObterJSON(url);

            enderecoBase = JsonConvert.DeserializeObject<Endereco>(requisicaoJSON);
            return enderecoBase;
        }

        private static IEnumerable<Endereco> ObterEnderecos(UF UF, String cidade, String logradouro)
        {
            var url = ControleDeUrl.GerarURLDaPesquisa(UF, cidade, logradouro);
            var strJSON = Requisicoes.ObterJSON(url);

            return JsonConvert.DeserializeObject<List<Endereco>>(strJSON);
        }
    }
}