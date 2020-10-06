using System;
using System.Collections.Generic;
using Dapper;
using DotCEP.Compartilhado.Enumeradores;

namespace DotCEP.Localidades
{
    internal class MunicipioRepositorio : IMunicipioRepositorio
    {
        private readonly BancosDeDados _bancoDeDados;

        public MunicipioRepositorio()
        {
            _bancoDeDados = new BancosDeDados();
        }

        public Municipio ObterMunicipio(uint codigo)
        {
            var sql = "Select * from Municipios m where m.Codigo = @codigo";

            return _bancoDeDados.Conexao.QueryFirst<Municipio>(sql, new {codigo});
        }

        public Municipio ObterMunicipio(string nomeMunicipio, string nomeEstado)
        {
            var sql = "select m.* from estados e " +
                      "inner join municipios m " +
                      "on m.codigoestado = e.codigo " +
                      "where m.nome = @municipio and e.nome = @estado";


            return _bancoDeDados.Conexao.QueryFirst<Municipio>
                (sql, new {municipio = nomeMunicipio, estado = nomeEstado});
        }

        public Municipio ObterMunicipio(string nomeMunicipio, UF Estado)
        {
            var sql = "select m.* from estados e " +
                      "inner join municipios m " +
                      "on m.codigoestado = e.codigo " +
                      "where m.nome = @nome and e.codigo = @codigo";

            return _bancoDeDados.Conexao.QueryFirst<Municipio>(sql,
                new {nome = nomeMunicipio, codigo = (byte) Estado});
        }

        public IEnumerable<Municipio> ListarTodos()
        {
            var sql = "select t.* from Municipios t";

            return _bancoDeDados.Conexao.Query<Municipio>(sql);
        }

        public IEnumerable<Municipio> ListarPorEstado(UF estado)
        {
            var sql = "select t.* from Municipios t where t.CodigoEstado = @codigo";

            return _bancoDeDados.Conexao.Query<Municipio>(sql, new {codigo = (byte) estado});
        }

        public IEnumerable<Municipio> ListarPorEstado(string nomeEstado)
        {
            var sql = "select m.* from Municipios m" +
                      "inner join Estados e" +
                      "on e.codigo = m.codigoestado" +
                      "where e.nome = @parametro";

            return _bancoDeDados.Conexao.Query<Municipio>(sql,
                new {parametro = nomeEstado.RemoverAcentos()});
        }
    }
}