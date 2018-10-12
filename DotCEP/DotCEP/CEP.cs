using System;

namespace DotCEP
{
    public class CEP
    {
        private readonly IEnderecoCache _enderecoCache;

        private string _valor;

        public string Valor
        {
            get => _valor;
            set
            {
                _valor = value;
                Formatar();
                Validar();
            }
        }

        public bool Valido { get; set; }


        public CEP(string valor)
        {
            Valor = valor;
        }

        public CEP(IEnderecoCache enderecoCache)
        {
            _enderecoCache = enderecoCache;
        }

        public CEP(string valor, IEnderecoCache enderecoCache)
        {
            _enderecoCache = enderecoCache;
            Valor = valor;
        }

        private void Formatar()
        {
            var valorTemp = Valor.Replace(" ", "").Replace("-", "");

            try
            {
                _valor = Convert.ToUInt64(valorTemp).ToString(@"00000\-000");
            }
            catch
            {
                throw new Exception($"Não foi possívl formatar o CEP {Valor}");
            }
        }

        private void Validar()
        {
            if (Valor.Trim().Length == 9)
            {
                Valido = System.Text.RegularExpressions.Regex.IsMatch(Valor, ("[0-9]{5}-[0-9]{3}"));
            }
            else if (Valor.Trim().Length == 8)
            {
                Formatar();
                Valido = System.Text.RegularExpressions.Regex.IsMatch(Valor, ("[0-9]{5}-[0-9]{3}"));
            }
            else
            {
                Valido = false;
            }
        }

        public bool VerificarExistencia()
        {
            if (!Valido) return false;

            try
            {
                if (_enderecoCache.ObterCache(this) != null)
                    return true;
            }
            catch (NotImplementedException)
            {
                return false;
            }

            return false;
        }
    }
}