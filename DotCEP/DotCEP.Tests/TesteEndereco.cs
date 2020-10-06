using System.Linq;
using DotCEP.Compartilhado.Enumeradores;
using FluentAssertions;
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

            enderecoBase.Localidade.Should().Be("Pelotas");
            enderecoBase.Bairro.Should().Be("Areal");
            enderecoBase.Logradouro.Should().Be("Avenida Ferreira Viana");
        }


        [Fact]
        public void TesteConsultaEnderecoCompletoInvalido()
        {
            var servicos = new ServicoEnderecos();
            var enderecoBase = servicos.ObterEndereco(new CEP("960850000"));

            enderecoBase.Localidade.Should().BeNull();
            enderecoBase.Bairro.Should().BeNull();
            enderecoBase.Logradouro.Should().BeNull();
        }

        [Fact]
        public void TesteConsultaEnderecoCompletoValidoComString()
        {
            var servicos = new ServicoEnderecos();
            var enderecoBase = servicos.ObterEndereco("96085000");

            enderecoBase.Localidade.Should().Be("Pelotas");
            enderecoBase.Bairro.Should().Be("Areal");
            enderecoBase.Logradouro.Should().Be("Avenida Ferreira Viana");
        }

        [Fact]
        public void TesteConsultaEnderecoCompletoInvalidoComString()
        {
            var servicos = new ServicoEnderecos();
            var enderecoBase = servicos.ObterEndereco("960850000");

            enderecoBase.Localidade.Should().BeNull();
            enderecoBase.Bairro.Should().BeNull();
            enderecoBase.Logradouro.Should().BeNull();
        }

        [Fact]
        public void TesteConsultaListaEnderecos()
        {
            var servicos = new ServicoEnderecos();
            var listaEnderecos = servicos.Buscar(UF.RS, "Pelotas", "Ferreira");

            listaEnderecos.Count().Should().Be(11);
        }

        [Fact]
        public void TesteConsultaListaInvalidos()
        {
            var servicos = new ServicoEnderecos();
            var listaEnderecos = servicos.Buscar(UF.RS, "Test", "Ferreira");

            listaEnderecos.Should().BeEmpty();
        }
    }
}