using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Npgsql;

namespace Dapper
{
    public class NpgsqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public NpgsqlConnectionFactory(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }

        public IDbConnection GetDbConnection()
        {
            var conn = new NpgsqlConnection(_connectionStringProvider.GetConnectionString());
            conn.Open();

            return conn;
        }
    }
}
