using System;
using System.Globalization;

namespace DotCEP
{
	public static class Datas
	{
		/// <summary>
		/// Gera a data no formatado certo para salvar no banco.
		/// </summary>
		/// <returns>A data formatada.</returns>
		public static string ObterDataFormatada(this DateTime data)
		{
			return DateTime.Now.ToString("yyyyMMdd HHmmss");
		}

		/// <summary>
		/// Verifica se o interválo de tempo é maior que 30 dias.
		/// </summary>
		/// <returns><c>true</c>, se a data for menor que 30 dias, <c>false</c> mais que 30 dias.</returns>
		/// <param name="p_DataConsulta">Data consulta.</param>
		public static bool ValidarIntervaloDeTempo(this DateTime data, string p_DataConsulta)
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
