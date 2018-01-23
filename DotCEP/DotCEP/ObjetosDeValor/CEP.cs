using System;

namespace DotCEP
{
    public class CEP
    {

        public string Valor { get; set; }
        public bool Valido { get; private set; }

        public CEP(string valor)
        {
            AtualizarValores(valor);
        }

        public void AtualizarValores(string Novovalor)
        {
            Valor = Novovalor;
            Validar();
        }

        public string Formatar()
        {
            var valorTemp = Valor.Replace(" ", "").Replace("-", "");

            try
            {
                Valor = Convert.ToUInt64(valorTemp).ToString(@"00000\-000");
            }
            catch
            {
                throw new Exception($"Não foi possívl formatar o CEP {this.Valor}");
            }

            return Valor;
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

        public bool VerificarExistencia()
        {
            var requisicaoJSON = string.Empty;

            if (Valido)
            {
                //var cache = new Cache();
                //enderecoBase = cache.ObterCache(CEP.Valor);


                if (Valor == string.Empty)//TODO: Validar se o valor do cache é != string.Empty
                {
                    var valorTemp = Valor.Replace("-", "").Trim();
                    requisicaoJSON = Requisicoes.ObterJSON(ControleDeUrl.GerarURLDaPesquisa(valorTemp));

                    //cache.Criar(CEP.Valor, requisicaoJSON);
                }
                else
                {
                    return true;
                }


                if (Requisicoes.VerificarProblemas(requisicaoJSON))
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                return false;
            }
        }
    }
}