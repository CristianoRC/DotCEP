using System;
using System.Collections.Generic;
using Dapper;

namespace DotCEP.Localidades
{
    internal class EstadoRepositorio : IEstadoRepositorio
    {
        private readonly BancosDeDados _bancoDeDados;

        public EstadoRepositorio()
        {
            _bancoDeDados = new BancosDeDados();
        }

        public Estado ObterPorCodigo(sbyte codigo)
        {
            var sql = "select * from estados where codigo = @codigo";
            try
            {
                return _bancoDeDados.Conexao.QueryFirst<Estado>(sql, new {codigo});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Estado ObterPorSiglaOuNome(string siglaOuNome)
        {
            var sql = string.Empty;

            if (siglaOuNome.Length == 2)
            {
                sql = "select * from ESTADOS t where t.sigla = @parametro";
                siglaOuNome = siglaOuNome.ToUpper();
            }
            else
            {
                sql = "select * from ESTADOS t where t.Nome = @parametro";
            }

            try
            {
                return _bancoDeDados.Conexao.QueryFirst<Estado>(sql, new {parametro = siglaOuNome});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Estado> Listar()
        {
            var sql = "select t.* from ESTADOS t order by t.Nome";
            try
            {
                return _bancoDeDados.Conexao.Query<Estado>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}