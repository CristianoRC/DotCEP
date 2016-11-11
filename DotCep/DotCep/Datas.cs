using System;
using System.Globalization;

namespace DotCEP
{
	internal static class Datas
	{
		/// <summary>
		/// Gera a data no formatado certo para salvar no banco.
		/// </summary>
		/// <returns>A data formatada.</returns>
		internal static string ObterDataFormatada()
		{
			return DateTime.Now.ToString("yyyyMMdd HHmmss");
		}

		/// <summary>
		/// Verifica se o interváli de tempo é maior que 30 dias.
		/// </summary>
		/// <returns><c>true</c>, se a data for menor que 30 dias, <c>false</c> mais que 30 dias.</returns>
		/// <param name="DataConsulta">Data consulta.</param>
		internal static bool ValidarIntervaloDeTempo(string p_DataConsulta)
		{
			bool resultado = false;

			string HoraEdataAtual = DateTime.Now.ToString("yyyyMMdd HHmmss");

			DateTime dataAtual = DateTime.ParseExact(HoraEdataAtual, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture);
			DateTime dataDaConsulta = DateTime.ParseExact(p_DataConsulta, "yyyyMMdd HHmmss", CultureInfo.InvariantCulture);


			TimeSpan ts = new TimeSpan();

			ts = dataAtual - dataDaConsulta;

			if (ts.Days < 31)
			{
				resultado = true;
			}


			return resultado;
		}
	}
}
