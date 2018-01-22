using System;

namespace DotCEP
{
    public class CEP
    {
        public CEP(string valor)
        {
            Valor = valor;

            Valido = VerificarValidadeDoCep();
        }

        public string Valor { get; private set; }
        public bool Valido { get; private set; }

        public bool VerificarValidadeDoCep()
        {
            if (this.Valor.Trim().Length == 9)
            {
                return System.Text.RegularExpressions.Regex.IsMatch(this.Valor, ("[0-9]{5}-[0-9]{3}"));
            }
            else if (this.Valor.Trim().Length == 8)
            {
                this.Valor = Formatar();
                return System.Text.RegularExpressions.Regex.IsMatch(this.Valor, ("[0-9]{5}-[0-9]{3}"));
            }
            else
            {
                return false;
            }
        }

        public void Formatar()
        {
            Valor = Valor.Replace(" ", "");
            Valor = Valor.Replace("-", "");

            try
            {
                Valor = Convert.ToUInt64(Valor).ToString(@"00000\-000");
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Não foi possívl formatar o CEP {this.Valor}\n{ex.Message}");
            }
        }
    }
}