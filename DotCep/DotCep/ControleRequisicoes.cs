using System.IO;
using System.Net;
using System.Text;

namespace DotCEP
{
	internal static class ControleRequisicoes
	{
		internal static string ObterJSON(string url)
		{
			try
			{
				HttpWebRequest request =
				(HttpWebRequest)WebRequest.Create(url);

				WebResponse response = request.GetResponse();

				using (Stream stream = response.GetResponseStream())
				{
					StreamReader reader = new StreamReader(stream, Encoding.UTF8);
					return reader.ReadToEnd();
				}
			}
			catch (System.Exception ex)
			{
				throw new System.Exception($"Erro ao tentar fazer a requisição: {ex.Message}");
			}
		}
	}
}

