using System.Collections.Generic;

namespace DotCEP
{
    public interface IEnderecoCache
    {
        Endereco ObterCache(CEP cep);
        IEnumerable<Endereco> ObterCache(UF uf, string cidade, string logradouro);

        void CriarCache(Endereco endereco);
        void CriarCache(IEnumerable<Endereco> enderecos);
    }
}