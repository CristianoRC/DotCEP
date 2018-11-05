using System;

namespace DotCEP.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var cepLeitura = Console.ReadLine();
            var cep = new CEP(cepLeitura);
            Console.Clear();

            if (cep.Valido)
            {
                Console.WriteLine($"Cep formatado: {cep.Valor}");
                var endereco = new Endereco(cep.Valor);

                Console.WriteLine("-------------------------");
                if (!string.IsNullOrEmpty(endereco.Localidade))
                {
                    Console.WriteLine(endereco.CEP);
                    Console.WriteLine(endereco.UF);
                    Console.WriteLine(endereco.Localidade);
                    Console.WriteLine(endereco.Bairro);
                    Console.WriteLine(endereco.Logradouro);
                    Console.WriteLine(endereco.Ibge);
                    Console.WriteLine(endereco.Gia);
                }
                else
                {
                    Console.WriteLine($"CEP \"{cep.Valor}\" não encontrado.");
                }
            }
            else
            {
                Console.WriteLine($"CEP \"{cep.Valor}\" inválido.");
            }
        }
    }
}