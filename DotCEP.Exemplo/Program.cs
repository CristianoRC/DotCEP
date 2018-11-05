using System;

namespace DotCEP.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            byte resposta = 0;
            var cache = new Cache();

            do
            {
                Console.Clear();
                Console.Write("Digite \'1\' para busca de CEP, \'2\' para busca de endereço e \'0\' para sair: ");
                resposta = Convert.ToByte(Console.ReadLine());

                if (resposta == 1)
                    BuscaDeCEP(cache);
                else if (resposta == 2)
                    BuscaDeEndereco(cache);
                else
                    Console.WriteLine("Até mais!");
            } while (resposta != 0);

            Console.ReadKey();
        }


        private static void BuscaDeEndereco(Cache cache)
        {
            Console.WriteLine("Não implementado!");
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }

        private static void BuscaDeCEP(Cache cache)
        {
            Console.Write("Digite o CEP: ");
            var cepLeitura = Console.ReadLine();
            var cep = new CEP(cepLeitura);
            Console.Clear();

            if (cep.Valido)
            {
                Console.WriteLine($"Cep formatado: {cep.Valor}");
                var endereco = new Endereco(cep.Valor, cache);

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

            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadKey();
        }
    }
}