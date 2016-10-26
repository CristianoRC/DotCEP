using System;
using System.Collections.Generic;
using DotCEP;

namespace CEP_Testes
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			//ConsultarListaDeEnderecos(UF.RS, "Porto Alegre", "Olavo");
			//ConsultarCEP(UF.RS, "Pelotas", "Avenida Saldanha Marinho", true);
			ObterEndereco(70160900);

			//ValidarCEP("70160-900");
			//VerificarExistenciaCEP("70160900");

			//FormatarCEP(70160900);
			//FormatarCEP("70160900");

			Console.ReadKey();
		}

		private static void ObterEndereco(uint CEP)
		{
			Endereco enderecoBase = new Endereco();

			enderecoBase = Consultas.ObterEnderecoCompleto(CEP);

			Console.WriteLine(enderecoBase.cep);
			Console.WriteLine(enderecoBase.uf);
			Console.WriteLine(enderecoBase.localidade);
			Console.WriteLine(enderecoBase.bairro);
			Console.WriteLine(enderecoBase.logradouro);
			Console.WriteLine(enderecoBase.complemento);
			Console.WriteLine(enderecoBase.ibge);
			Console.WriteLine(enderecoBase.gia);
			Console.WriteLine(enderecoBase.unidade);
		}

		private static void ConsultarListaDeEnderecos(UF uf, string Cidade, string Logradouro)
		{
			List<Endereco> enderecos = new List<Endereco>();

			enderecos = Consultas.ObterListaDeEnderecos(uf, Cidade, Logradouro);

			foreach (Endereco enderecoBase in enderecos)
			{
				Console.WriteLine(enderecoBase.cep);
				Console.WriteLine(enderecoBase.uf);
				Console.WriteLine(enderecoBase.localidade);
				Console.WriteLine(enderecoBase.bairro);
				Console.WriteLine(enderecoBase.logradouro);
				Console.WriteLine(enderecoBase.complemento);
				Console.WriteLine(enderecoBase.ibge);
				Console.WriteLine(enderecoBase.gia);
				Console.WriteLine(enderecoBase.unidade);

				Console.WriteLine(" ");
				Console.WriteLine("---------------------------");
				Console.WriteLine(" ");
			}
		}

		private static void ConsultarCEP(UF uf, string Cidade, string Logradouro, bool RetornarCEPformatado)
		{
			string CEP = Consultas.ObterCEP(uf, Cidade, Logradouro, RetornarCEPformatado);

			Console.WriteLine(CEP);
		}


		private static void VerificarExistenciaCEP(string CEP)
		{
			bool saida = DotCEP.Validacoes.VerificarExistenciaDoCEP(CEP);

			Console.WriteLine(saida.ToString());
		}

		private static void ValidarCEP(string CEP)
		{
			bool saida = DotCEP.Validacoes.VerificarValidadeDoCep(CEP);

			Console.WriteLine(saida.ToString());
		}


		private static void FormatarCEP(string CEP)
		{
			Console.WriteLine(Formatacao.FormatarCEP(CEP));
		}

		private static void FormatarCEP(uint CEP)
		{
			Console.WriteLine(Formatacao.FormatarCEP(CEP));
		}
	}
}
