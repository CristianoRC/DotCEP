using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotCEP.Compartilhado.Enumeradores;
using Newtonsoft.Json;

namespace DotCEP
{
    public class ServicoEnderecos
    {
        private readonly IEnderecoCache _enderecoCache;

        public ServicoEnderecos()
        {
        }

        public ServicoEnderecos(IEnderecoCache enderecoCache)
        {
            _enderecoCache = enderecoCache;
        }


        public async Task<IEnumerable<Endereco>> Buscar(UF UF, string Cidade, string Logradouro)
        {
            if (_enderecoCache != null)
            {
                var enderecosDoCache = await _enderecoCache.ObterCache(UF, Cidade, Logradouro);

                if (enderecosDoCache.ToList().Any()) return enderecosDoCache;

                var enderecos = BuscarSemCache(UF, Cidade, Logradouro);

                _enderecoCache.CriarCache(enderecos);
                return enderecos;
            }

            return BuscarSemCache(UF, Cidade, Logradouro);
        }

        private IEnumerable<Endereco> BuscarSemCache(UF UF, string cidade, string logradouro)
        {
            var url = ControleDeUrl.GerarUrlDaPesquisa(UF, cidade, logradouro);
            var strJSON = Requisicoes.ObterJson(url);

            return JsonConvert.DeserializeObject<List<Endereco>>(strJSON);
        }

        public async Task<Endereco> ObterEndereco(CEP cep)
        {
            if (!cep.Valido)
                return new Endereco();

            if (_enderecoCache != null)
            {
                var cache = await _enderecoCache.ObterCache(cep);
                if (cache != null) return cache;

                var endereco = ObterEnderecoSemCache(cep);

                if (endereco != null)
                {
                    _enderecoCache.CriarCache(endereco);
                    return endereco;
                }

                return new Endereco();
            }

            return ObterEnderecoSemCache(cep);
        }

        public async Task<Endereco> ObterEndereco(string cep)
        {
            var cepConvertido = new CEP(cep);

            return await ObterEndereco(cepConvertido);
        }

        private Endereco ObterEnderecoSemCache(CEP cep)
        {
            Endereco endereco;

            var url = ControleDeUrl.GerarUrlDaPesquisa(cep.Valor);

            var requisicaoJson = Requisicoes.ObterJson(url);

            if (Requisicoes.ContemErros(requisicaoJson))
                return null;

            endereco = JsonConvert.DeserializeObject<Endereco>(requisicaoJson);

            return endereco;
        }
    }
}