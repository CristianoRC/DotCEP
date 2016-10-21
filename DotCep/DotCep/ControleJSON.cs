using System;
using System.Net;
using System.IO;
using System.Text;

namespace DotCep
{
    internal static class ControleJSON
    {
        internal static string ObterStringJSONS(uint CEP)
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(ObterURL(CEP));
            
            WebResponse response = request.GetResponse();

            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(
                                          stream, Encoding.UTF8);
                return reader.ReadToEnd();
            }
        }

        private static string ObterURL(uint CEP)
        {
            const String CaminhoPadrao = @"https://viacep.com.br/ws/{0}/json/";
            return String.Format(CaminhoPadrao, CEP.ToString());
        }
    }
}

