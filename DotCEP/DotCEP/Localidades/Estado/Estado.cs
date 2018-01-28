using System;
using System.Collections.Generic;
using Dapper;

namespace DotCEP.Localidades
{
    public class Estado
    {

        #region Propriedades

        public SByte Codigo { get; private set; }

        public String Sigla { get; private set; }

        public String Nome { get; private set; }

        #endregion

        #region Construtores
        public Estado() { }
        public Estado(string SiglaOuNome)
        {
            string sql = string.Empty;

            if (SiglaOuNome.Length == 2) //Se tiver 2 caracteres é uma sigla
            {
                sql = "select * from ESTADOS t where t.sigla = @parametro";

                SiglaOuNome = SiglaOuNome.ToUpper();
            }
            else
            {
                sql = "select * from ESTADOS t where t.Nome = @parametro";
            }

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                var estadoTemp = banco.Conexao.QueryFirst<Estado>(sql, new { parametro = SiglaOuNome });

                this.Codigo = estadoTemp.Codigo;
                this.Nome = estadoTemp.Nome;
                this.Sigla = estadoTemp.Sigla;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Estado(sbyte codigo)
        {
            var sql = "select * from estados where codigo = codigo";
            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                var estadoTemp = banco.Conexao.QueryFirst<Estado>(sql, new { codigo = codigo });

                this.Codigo = estadoTemp.Codigo;
                this.Nome = estadoTemp.Nome;
                this.Sigla = estadoTemp.Sigla;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Estado(SByte codigo, String sigla, String nome)
        {
            this.Codigo = codigo;
            this.Sigla = sigla;
            this.Nome = nome;

        }

        #endregion

        #region Lista
        public static IEnumerable<Estado> ObterListaDeEstados()
        {
            var sql = "select t.* from ESTADOS t order by t.Nome";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.Query<Estado>(sql);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Nome
        public static string ObterNomeDoEstado(SByte Codigo)
        {
            var sql = "select t.nome from ESTADOS t where t.codigo = @codigo";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<string>(sql, new { codigo = Codigo });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string ObterNomeDoEstado(string Sigla)
        {
            var sql = "select t.nome from ESTADOS t where t.sigla = @sigla";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<string>(sql, new { sigla = Sigla });
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Codigo
        public static SByte ObterCodigoDoEstado(string SiglaOuNome)
        {
            string sql = string.Empty;

            if (SiglaOuNome.Length == 2) //Se tiver 2 caracteres é uma sigla
            {
                sql = "select t.codigo from ESTADOS t where t.sigla = @parametro";

                SiglaOuNome = SiglaOuNome.ToUpper();
            }
            else
            {
                sql = "select t.codigo from ESTADOS t where t.Nome = @parametro";
            }

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<SByte>(sql, new { parametro = SiglaOuNome });
            }
            catch (System.Exception e)
            {

                throw new Exception($"Não foi possível efetuar a busca: {e.Message}");
            }
        }

        #endregion

        #region Sigla
        public static string ObterSiglaDoEstado(int Codigo)
        {

            var sql = "select t.Sigla from ESTADOS t where t.codigo = @codigo";

            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<string>(sql, new { codigo = Codigo });
            }
            catch (System.Exception e)
            {
                throw new Exception($"Não foi possível efetuar a busca: {e.Message}");
            }
        }

        public static string ObterSiglaDoEstado(string Nome)
        {

            var sql = "select t.Sigla from ESTADOS t where t.Nome = @nome";
            try
            {
                var banco = new BancosDeDados(EBancoDeDados.localidades);

                return banco.Conexao.QueryFirst<string>(sql, new { nome = Nome });
            }
            catch (System.Exception e)
            {
                throw new Exception($"Não foi possível efetuar a busca: {e.Message}");
            }
        }

        #endregion
    }
}
