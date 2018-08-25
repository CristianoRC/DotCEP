using System;
using Microsoft.Data.Sqlite;

namespace DotCEP.Localidades
{
    internal class BancosDeDados
    {
        internal SqliteConnection Conexao { get; private set; }

        internal BancosDeDados()
        {
            Conexao = new SqliteConnection($@"Data Source={System.AppDomain.CurrentDomain.BaseDirectory.ToString()}/Lugares.db");
            Console.WriteLine(Conexao.ConnectionString);
                
        }
    }
}