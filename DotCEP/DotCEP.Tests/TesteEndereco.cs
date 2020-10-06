using System.Linq;
using DotCEP.Compartilhado.Enumeradores;
using Xunit;

namespace DotCEP.Tests
{
    public class TesteEndereco
    {

        [Fact]
        public void TesteConsultaEnderecoCompletoValido()
        {
            var servicos = new ServicoEnderecos();

            var enderecoBase = servicos.ObterEndereco(new CEP("96085000"));

            Assert.Equal("Pelotas", enderecoBase.Localidade);
            Assert.Equal("Areal", enderecoBase.Bairro);
            Assert.Equal("Avenida Ferreira Viana", enderecoBase.Logradouro);
        }


        [Fact]
        public void TesteConsultaEnderecoCompletoInvalido()
        {
            var servicos = new ServicoEnderecos();

          var  enderecoBase = servicos.ObterEndereco(new CEP("960850000"));

            Assert.Null(enderecoBase.Localidade);
            Assert.Null(enderecoBase.Bairro);
            Assert.Null(enderecoBase.Logradouro);
        }

        [Fact]
        public void TesteConsultaEnderecoCompletoValidoComString()
        {
            var servicos = new ServicoEnderecos();

            var enderecoBase = servicos.ObterEndereco("96085000");

            Assert.Equal("Pelotas", enderecoBase.Localidade);
            Assert.Equal("Areal", enderecoBase.Bairro);
            Assert.Equal("Avenida Ferreira Viana", enderecoBase.Logradouro);
        }

        [Fact]
        public void TesteConsultaEnderecoCompletoInvalidoComString()
        {
            var servicos = new ServicoEnderecos();

            var enderecoBase = servicos.ObterEndereco("960850000");

            Assert.Null(enderecoBase.Localidade);
            Assert.Null(enderecoBase.Bairro);
            Assert.Null(enderecoBase.Logradouro);
        }

        [Fact]
        public void TesteConsultaListaEnderecos()
        {
            var servicos = new ServicoEnderecos();

            var listaEnderecos = servicos.Buscar(UF.RS, "Pelotas", "Ferreira");

            Assert.Equal(11, listaEnderecos.ToList().Count);
        }

        [Fact]
        public void TesteConsultaListaInvalidos()
        {
            var servicos = new ServicoEnderecos();

            var listaEnderecos = servicos.Buscar(UF.RS, "Test", "Ferreira");

            Assert.Empty(listaEnderecos.ToList());
        }
    }
}