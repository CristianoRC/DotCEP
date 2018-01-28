using System;
using System.Collections.Generic;
using Dapper;

namespace DotCEP.Localidades
{
    public class Municipio
    {
        #region Propriedades

        public int CodigoEstado { get; private set; }

        public int Codigo { get; private set; }

        public string Nome { get; private set; }

        #endregion

        #region Construtores
        public Municipio() { }

        public Municipio(uint CodigoMunicipio)
        {
            Municipio municipioTemp;
            var sql = "Select * from Municipios m where m.Codigo = @codigo";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                municipioTemp = banco.Conexao.QueryFirst<Municipio>(sql, new { codigo = CodigoMunicipio });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            this.Codigo = municipioTemp.Codigo;
            this.CodigoEstado = municipioTemp.CodigoEstado;
            this.Nome = municipioTemp.Nome;
        }

        public Municipio(string NomeMunicipio, UF SiglaEstado)
        {
            Municipio municipioTemp;
            var sql = "select m.* from estados e " +
                    "inner join municipios m " +
                    "on m.codigoestado = e.codigo " +
                    "where m.nome = @nome and e.codigo = @codigo";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                municipioTemp = banco.Conexao.QueryFirst<Municipio>(sql, new { nome = NomeMunicipio, codigo = (byte)SiglaEstado });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            this.Codigo = municipioTemp.Codigo;
            this.CodigoEstado = municipioTemp.CodigoEstado;
            this.Nome = municipioTemp.Nome;
        }

        public Municipio(string NomeMunicipio, string Estado)
        {
            Municipio municipioTemp;
            string sql = string.Empty;

            if (Estado.Length == 2)
            {
                sql = "select m.* from estados e " +
                    "inner join municipios m " +
                    "on m.codigoestado = e.codigo " +
                    "where m.nome = @municipio and e.sigla = @estado";
            }
            else
            {
                sql = "select m.* from estados e " +
                    "inner join municipios m " +
                    "on m.codigoestado = e.codigo " +
                    "where m.nome = @municipio and e.nome = @estado";
            }

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                municipioTemp = banco.Conexao.QueryFirst<Municipio>(sql, new { municipio = NomeMunicipio, estado = Estado });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            this.Codigo = municipioTemp.Codigo;
            this.CodigoEstado = municipioTemp.CodigoEstado;
            this.Nome = municipioTemp.Nome;
        }


        #endregion

        #region Lista
        public static IEnumerable<Municipio> ObterListaDeMunicipio()
        {
            var sql = "select t.* from Municipios t";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.Query<Municipio>(sql);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<Municipio> ObterListaDeMunicipio(UF SiglaEstado)
        {
            var sql = "select t.* from Municipios t where t.CodigoEstado = @codigo";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.Query<Municipio>(sql, new { codigo = (byte)SiglaEstado });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<Municipio> ObterListaDeMunicipio(string Estado)
        {
            string sql = string.Empty;

            if (Estado.Length == 2)
            {
                sql = @"select m.* from Municipios m  
                inner join Estados e
                on e.codigo = m.codigoestado
                where e.sigla = @parametro";
            }
            else
            {
                sql = @"select m.* from Municipios m  
                inner join Estados e
                on e.codigo = m.codigoestado
                where e.nome = @parametro";
            }

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.Query<Municipio>(sql, new { parametro = Estado.RemoverAcentos() });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region Nome
        public static string ObterNomeDoMunicipio(uint CodigoMunicipio)
        {
            var sql = "select t.nome from Municipios t where t.codigo = @codigo";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<string>(sql, new { codigo = CodigoMunicipio });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Codigo

        public static int ObterCodigoDoMunicipio(string NomeMunicipio, UF SiglaEstado)
        {
            var sql = "select t.Codigo from Municipios t where t.nome = @nome and t.CodigoEstado = @codigo";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<int>(sql, new { codigo = (byte)SiglaEstado, nome = NomeMunicipio });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int ObterCodigoDoMunicipio(string NomeMunicipio, string Estado)
        {
            string sql = string.Empty;

            if (Estado.Length == 2)
            {
                sql = "select t.Codigo from Municipios t " +
                "inner join estados e " +
                "on e.codigo = t.codigoestado " +
                "where t.nome = @municipio and e.sigla = @estado";
            }
            else
            {
                sql = "select t.Codigo from Municipios t " +
                 "inner join estados e " +
                 "on e.codigo = t.codigoestado " +
                 "where t.nome = @municipio and e.nome = @estado";
            }

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<int>(sql, new { municipio = NomeMunicipio, estado = Estado });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int ObterCodigoDoMunicipio(string NomeMunicipio, int CodigoEstado)
        {
            var sql = "select t.Codigo from Municipios t where t.nome = @municipio and t.CodigoEstado = @estado";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<int>(sql, new { municipio = NomeMunicipio, estado = CodigoEstado });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
