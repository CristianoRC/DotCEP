using System.Linq;
using System.Threading.Tasks;
using DotCEP.Compartilhado.Enumeradores;
using FluentAssertions;
using Xunit;

namespace DotCEP.Tests
{
    public class TesteEndereco
    {
        [Fact]
        public async Task TesteConsultaEnderecoCompletoValido()
        {
            var servicos = new ServicoEnderecos();
            var enderecoBase = await servicos.ObterEndereco(new CEP("96085000"));

            enderecoBase.Localidade.Should().Be("Pelotas");
            enderecoBase.Bairro.Should().Be("Areal");
            enderecoBase.Logradouro.Should().Be("Avenida Ferreira Viana");
        }


        [Fact]
        public async Task TesteConsultaEnderecoCompletoInvalido()
        {
            var servicos = new ServicoEnderecos();
            var enderecoBase = await servicos.ObterEndereco(new CEP("960850000"));

            enderecoBase.Localidade.Should().BeNull();
            enderecoBase.Bairro.Should().BeNull();
            enderecoBase.Logradouro.Should().BeNull();
        }

        [Fact]
        public async Task TesteConsultaEnderecoCompletoValidoComString()
        {
            var servicos = new ServicoEnderecos();
            var enderecoBase = await servicos.ObterEndereco("96085000");

            enderecoBase.Localidade.Should().Be("Pelotas");
            enderecoBase.Bairro.Should().Be("Areal");
            enderecoBase.Logradouro.Should().Be("Avenida Ferreira Viana");
        }

        [Fact]
        public async Task TesteConsultaEnderecoCompletoInvalidoComString()
        {
            var servicos = new ServicoEnderecos();
            var enderecoBase = await servicos.ObterEndereco("960850000");

            enderecoBase.Localidade.Should().BeNull();
            enderecoBase.Bairro.Should().BeNull();
            enderecoBase.Logradouro.Should().BeNull();
        }

        [Fact]
        public async Task TesteConsultaListaEnderecos()
        {
            var servicos = new ServicoEnderecos();
            var listaEnderecos = await servicos.Buscar(UF.RS, "Pelotas", "Ferreira");

            listaEnderecos.Count().Should().Be(11);
        }

        [Fact]
        public async Task TesteConsultaListaInvalidos()
        {
            var servicos = new ServicoEnderecos();
            var listaEnderecos = await servicos.Buscar(UF.RS, "Test", "Ferreira");

            listaEnderecos.Should().BeEmpty();
        }
    }
}