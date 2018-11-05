using System.Collections.Generic;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace DotCEP.Exemplo
{
    public class Cache : IEnderecoCache
    {
        public Endereco ObterCache(CEP cep)
        {
            using (var redis = ConnectionMultiplexer.Connect("172.17.0.2:6379"))
            {
                var db = redis.GetDatabase();

                var json = db.StringGet(cep.Valor);

                redis.Close();

                if (!json.IsNullOrEmpty)
                    return JsonConvert.DeserializeObject<Endereco>(json);

                return null;
            }
        }

        public void CriarCache(Endereco endereco)
        {
            using (var redis = ConnectionMultiplexer.Connect("172.17.0.2:6379"))
            {
                var db = redis.GetDatabase();

                db.StringSet(endereco.CEP, JsonConvert.SerializeObject(endereco));

                redis.Close();
            }
        }

        
        public IEnumerable<Endereco> ObterCache(UF UF, string Cidade, string Logradouro)
        {
            throw new System.NotImplementedException();
        }

        public void CriarCache(IEnumerable<Endereco> enderecos)
        {
            throw new System.NotImplementedException();
        }
    }
}