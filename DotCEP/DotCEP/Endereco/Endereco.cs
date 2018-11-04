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

        public string CEP { get; set; }
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

        public Endereco()
        {
        }

        public Endereco(CEP cep)
        {
            Endereco endereco;

            if (cep.Valido)
            {
                endereco = ObterEndereco(cep);
                AtualziarPropriedades(endereco);
            }
        }

        public Endereco(string cep)
        {
            Endereco endereco;

            var cepTemp = new CEP(cep);

            if (cepTemp.Valido)
            {
                endereco = ObterEndereco(cepTemp);

                AtualziarPropriedades(endereco);
            }
        }

        public Endereco(CEP cep, IEnderecoCache enderecoCache)
        {
            _enderecoCache = enderecoCache;

            Endereco endereco;

            if (cep.Valido)
            {
                var enderecoBase = _enderecoCache.ObterCache(cep);

                if (!string.IsNullOrEmpty(enderecoBase.CEP))
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

        public Endereco(string cep, IEnderecoCache enderecoCache)
        {
            _enderecoCache = enderecoCache;

            var cepTemp = new CEP(cep);
            var endereco = this;

            if (cepTemp.Valido)
            {
                var enderecoBase = _enderecoCache.ObterCache(cepTemp);

                if (string.IsNullOrEmpty(enderecoBase.CEP))
                {
                    endereco = enderecoBase;
                }
                else
                {
                    endereco = ObterEndereco(cepTemp);
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

            var enderecos = Buscar(UF, Cidade, Logradouro);

            enderecoCache.CriarCache(enderecos);
            return enderecos;
        }

        public static IEnumerable<Endereco> Buscar(UF UF, string cidade, string logradouro)
        {
            var url = ControleDeUrl.GerarURLDaPesquisa(UF, cidade, logradouro);
            var strJSON = Requisicoes.ObterJSON(url);

            return JsonConvert.DeserializeObject<List<Endereco>>(strJSON);
        }


        private Endereco ObterEndereco(CEP cep)
        {
            Endereco enderecoBase;

            var url = ControleDeUrl.GerarURLDaPesquisa(cep.Valor);

            var requisicaoJSON = Requisicoes.ObterJSON(url);

            enderecoBase = JsonConvert.DeserializeObject<Endereco>(requisicaoJSON);
            return enderecoBase;
        }

        private void AtualziarPropriedades(Endereco endereco)
        {
            Bairro = endereco.Bairro;
            Complemento = endereco.Complemento;
            Gia = endereco.Gia;
            Ibge = endereco.Ibge;
            Localidade = endereco.Localidade;
            Logradouro = endereco.Logradouro;
            Unidade = endereco.Unidade;
            UF = endereco.UF;
            CEP = endereco.CEP;
        }
    }
}