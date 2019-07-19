using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Dapper
{
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public SqliteConnectionFactory(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection GetDbConnection()
        {
            var conn = new SQLiteConnection(_connectionStringProvider.GetConnectionString());
            conn.Open();

            return conn;
        }
    }
}
