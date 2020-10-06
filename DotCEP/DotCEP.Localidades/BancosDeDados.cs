using System;
using Microsoft.Data.Sqlite;

namespace DotCEP.Localidades
{
    internal class BancosDeDados
    {
        internal BancosDeDados()
        {
            var asd = $"{AppDomain.CurrentDomain.BaseDirectory}Lugares.db";
            Conexao = new SqliteConnection($@"Data Source={AppDomain.CurrentDomain.BaseDirectory}Lugares.db");
        }

        internal SqliteConnection Conexao { get; }
    }
}