using DotCEP.Compartilhado.Enumeradores;

namespace DotCEP
{
    public class Endereco
    {
        public Endereco()
        {
        }

        public Endereco(string cep, string logradouro, string complemento, string bairro, string localidade, UF uf, string unidade, string ibge, string gia)
        {
            CEP = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            UF = uf;
            Unidade = unidade;
            Ibge = ibge;
            Gia = gia;
        }

        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public UF UF { get; set; }
        public string Unidade { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
    }
}