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


        public async Task<IEnumerable<Endereco>> Buscar(UF uf, string cidade, string logradouro)
        {
            if (_enderecoCache != null)
            {
                var enderecosDoCache = await _enderecoCache.ObterCache(uf, cidade, logradouro);

                if (enderecosDoCache.Any()) return enderecosDoCache;

                var enderecos = BuscarSemCache(uf, cidade, logradouro);

                await _enderecoCache.CriarCache(enderecos);
                return enderecos;
            }

            return BuscarSemCache(uf, cidade, logradouro);
        }

        private IEnumerable<Endereco> BuscarSemCache(UF uf, string cidade, string logradouro)
        {
            var url = ControleDeUrl.GerarUrlDaPesquisa(uf, cidade, logradouro);
            var json = Requisicoes.ObterJson(url);

            return JsonConvert.DeserializeObject<List<Endereco>>(json);
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
                    await _enderecoCache.CriarCache(endereco);
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
            var url = ControleDeUrl.GerarUrlDaPesquisa(cep.Valor);

            var requisicaoJson = Requisicoes.ObterJson(url);

            if (Requisicoes.ContemErros(requisicaoJson))
                return null;

            return JsonConvert.DeserializeObject<Endereco>(requisicaoJson);
        }
    }
}