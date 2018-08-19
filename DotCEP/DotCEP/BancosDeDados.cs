using System;
using Microsoft.Data.Sqlite;

namespace DotCEP
{
    internal class BancosDeDados
    {
        internal SqliteConnection Conexao { get; private set; }
        internal BancosDeDados(EBancoDeDados banco)
        {
            if (banco == EBancoDeDados.cache)
                Conexao = new SqliteConnection(strconnCache);
            else
                Conexao = new SqliteConnection(strconnLugares);
        }

        #region String de Conexão
        string strconnCache = "Data Source=./Cache/Cache.db";
        string strconnLugares = "Data Source=./Cache/Lugares.db";
        #endregion

    }

}
