using System;
using System.Text.RegularExpressions;

namespace DotCEP
{
    public class CEP
    {
        private string _valor;

        public CEP(string valor)
        {
            Valor = valor;
        }

        public string Valor
        {
            get => _valor;
            set
            {
                _valor = value;
                Validar();
                Formatar();
            }
        }

        public bool Valido { get; private set; }

        private void Formatar()
        {
            var valorTemp = Valor.Replace(" ", "").Replace("-", "");

            try
            {
                _valor = Convert.ToUInt64(valorTemp).ToString(@"00000\-000");
            }
            catch
            {
                throw new ArgumentException($"Não foi possívl formatar o CEP {Valor}");
            }
        }

        private void Validar()
        {
            if (Valor.Trim().Length == 9)
            {
                Valido = Regex.IsMatch(Valor, "[0-9]{5}-[0-9]{3}");
            }
            else if (Valor.Trim().Length == 8)
            {
                Formatar();
                Valido = Regex.IsMatch(Valor, "[0-9]{5}-[0-9]{3}");
            }
            else
            {
                Valido = false;
            }
        }

        public bool VerificarExistencia()
        {
            if (!Valido) return false;

            return Requisicoes.ExistenciaDoCep(this);
        }
    }
}