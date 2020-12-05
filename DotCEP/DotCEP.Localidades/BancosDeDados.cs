using System;
using Microsoft.Data.Sqlite;

namespace DotCEP.Localidades
{
    internal class BancosDeDados
    {
        internal BancosDeDados()
        {
            Conexao = new SqliteConnection($@"Data Source={AppDomain.CurrentDomain.BaseDirectory}Lugares.db");
        }

        internal SqliteConnection Conexao { get; }
    }
}