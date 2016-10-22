using System;

namespace DotCEP
{
    public static class Formatacao
    {
        public static string FormatarCEP(uint CEP)
        {
            string CEPformatado = CEP.ToString();

            if (CEPformatado.Length == 8)
            {
                CEPformatado = CEPformatado.Substring(0, 5) + "-" + CEPformatado.Substring(5, 3);
            }

            return  CEPformatado;
        }

        public static string FormatarCEP(string CEP)
        {
            string CEPformatado = CEP;

            if (CEPformatado.Length == 8)
            {
                CEPformatado = CEPformatado.Substring(0, 5) + "-" + CEPformatado.Substring(5, 3);
            }

            return  CEPformatado;
        }

    }
}

