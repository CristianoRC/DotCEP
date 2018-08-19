using System.Globalization;
using System.Text;

namespace DotCEP
{
    public static class Ferramentas
    {
        public static string RemoverAcentos(this string text)
        {
            /*Código fonte retirado do site Código Simples - 27/01/2018 / 21:18

                https://codigosimples.net/2016/04/12/remover-acentos-de-uma-string-com-c/*/

            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

    }
}