using System;
using System.Data;
using Dapper;

namespace DotCEP
{
    /// <summary>
    /// Manipulação do cache de consulta de endereço 
    /// </summary>
    internal partial class Cache
    {
        private BancosDeDados bancoDeDados = new BancosDeDados(EBancoDeDados.cache);

        internal void Criar(string CEP, string Resultado)
        {

            var sql = "insert into cache (cep,retorno,dataconsulta) values(@cep,@retorno,@dataconsulta)";

            try
            {
                bancoDeDados.Conexao.Execute(sql,
                new { cep = CEP, retorno = Resultado, dataconsulta = DateTime.Now.ObterDataFormatada() });
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro no banco: {ex.Message}");
            }
        }

        internal void Criar(string CEP, string Resultado, string IDConsulta)
        {
            var sql = "insert into cache values(@cep,@retorno,@dataconsulta,@idconsultandereco)";

            try
            {
                bancoDeDados.Conexao.Execute(sql,
                new { cep = CEP, retorno = Resultado, dataconsulta = DateTime.Now.ObterDataFormatada(), idconsultandereco = IDConsulta })
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro no banco: {ex.Message}");
            }
        }

        internal void Deletar(string CEP)
        {

            var sql = "delete from cache where CEP = @cep";

            try
            {
                bancoDeDados.Conexao.Execute(sql, new { cep = CEP });
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro no banco: {ex.Message}");
            }
        }

        internal Endereco ObterCache(string CEP)
        {

            var sql = "select * from cache where CEP = #cep#";

            try
            {

                var listaDeCEP = bancoDeDados.Conexao

                if (tabela.Rows.Count != 0)
                {
                    var strJSON = tabela.Rows[0]["Retorno"].ToString();

                    enderecoBase = ManipulacaoJSON.ObterEndereco(strJSON);
                }
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Erro no banco: {ex.Message}");
            }
        }
    }
}
