using System;

namespace DotCEP
{
    public class CEP
    {

        public string Valor { get; private set; }
        public bool Valido { get; private set; }

        public CEP(string valor)
        {
            Atualizar(valor);
        }

        public void Atualizar(string valor)
        {
            Valor = Valor;
            Validar();
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

        private void Validar()
        {
            if (this.Valor.Trim().Length == 9)
            {
                Valido = System.Text.RegularExpressions.Regex.IsMatch(this.Valor, ("[0-9]{5}-[0-9]{3}"));
            }
            else if (this.Valor.Trim().Length == 8)
            {
                Formatar();
                Valido = System.Text.RegularExpressions.Regex.IsMatch(this.Valor, ("[0-9]{5}-[0-9]{3}"));
            }
            else
            {
                Valido = false;
            }
        }
    }
}