using System.Collections.Generic;

namespace DotCEP
{
    public interface IEnderecoCache
    {
        Endereco ObterCache(CEP cep);
        IEnumerable<Endereco> ObterCache(UF UF, string Cidade, string Logradouro);

        void CriarCache(Endereco endereco);
        void CriarCache(IEnumerable<Endereco> enderecos);
    }
}