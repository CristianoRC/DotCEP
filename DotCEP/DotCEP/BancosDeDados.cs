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
                Conexao = new SqliteConnection(StrConnBancoCache());
            else
                Conexao = new SqliteConnection(StrConnBancoLugares());
        }

        #region String de Conexão
        string caminhoexecutavel = AppDomain.CurrentDomain.BaseDirectory;
        string strconnBase = "Data Source=#;Version=3;Synchronous=Full;Journal Mode=Off";

        private string StrConnBancoCache()
        {
            if (((int)Environment.OSVersion.Platform) < 4)
            {
                return strconnBase.Replace("#", $"{caminhoexecutavel}\\Cache\\Cache.db");// Windows
            }
            else
            {
                return strconnBase.Replace("#", $"{caminhoexecutavel}/Cache/Cache.db");// Linux e MacOSX
            }
        }

        private string StrConnBancoLugares()
        {
            if (((int)Environment.OSVersion.Platform) < 4)
            {
                return strconnBase.Replace("#", $"{caminhoexecutavel}\\Cache\\Lugares.db");// Windows
            }
            else
            {
                return strconnBase.Replace("#", $"{caminhoexecutavel}/Lugares/Cache.db");// Linux e MacOSX
            }
        }
        #endregion
    }
}
