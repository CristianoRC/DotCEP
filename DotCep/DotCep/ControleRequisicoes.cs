using System.Net;
using System.IO;
using System.Text;

namespace DotCEP
{
	internal static class ControleRequisicoes
	{
		internal static string ObterStringJSONS(string url)
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
				throw new System.Exception(string.Format("Erro ao tentar fazer a requisição: {0}", ex.Message));
			}
		}
	}
}

