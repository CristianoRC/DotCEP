using Microsoft.Data.Sqlite;

namespace DotCEP
{
    internal class BancosDeDados
    {
        internal SqliteConnection Conexao { get; private set; }

        internal BancosDeDados()
        {
            Conexao = new SqliteConnection(@"Data Source=./Cache/Lugares.db");
        }
    }
}