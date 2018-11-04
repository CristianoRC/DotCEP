using System;
using System.Collections.Generic;
using Dapper;

namespace DotCEP.Localidades.Repositorio.Estado
{
    internal class EstadoRepositorio : IEstadoRepositorio
    {
        private readonly BancosDeDados _bancoDeDados;

        public EstadoRepositorio()
        {
            _bancoDeDados = new BancosDeDados();
        }

        public Localidades.Estado ObterPorCodigo(sbyte codigo)
        {
            var sql = "select * from estados where codigo = @codigo";
            try
            {
                return _bancoDeDados.Conexao.QueryFirst<Localidades.Estado>(sql, new {codigo = codigo});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Localidades.Estado ObterPorSiglaOuNome(string siglaOuNome)
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
                return _bancoDeDados.Conexao.QueryFirst<Localidades.Estado>(sql, new {parametro = siglaOuNome});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Localidades.Estado> Listar()
        {
            var sql = "select t.* from ESTADOS t order by t.Nome";
            try
            {
                return _bancoDeDados.Conexao.Query<Localidades.Estado>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}