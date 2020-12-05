using System.Collections.Generic;
using System.Threading.Tasks;
using DotCEP.Compartilhado.Enumeradores;

namespace DotCEP
{
    public interface IEnderecoCache
    {
        Task<Endereco> ObterCache(CEP cep);
        Task<IEnumerable<Endereco>> ObterCache(UF uf, string cidade, string logradouro);
        Task CriarCache(Endereco endereco);
        Task CriarCache(IEnumerable<Endereco> enderecos);
    }
}