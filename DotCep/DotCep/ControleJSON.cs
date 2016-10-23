using System.Net;
using System.IO;
using System.Text;

namespace DotCEP
{
    internal static class ControleJSON
    {
        internal static string ObterStringJSONS(string url)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(url);
            
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(
                                          stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }
    }
}

