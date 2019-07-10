using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Dapper
{
    public class SqlConnectionFactory : IDbConnectionFactory
    {
        private readonly IConnectionStringProvider _provider;

        public SqlConnectionFactory(IConnectionStringProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        public IDbConnection GetDbConnection()
        {
            using (var conn = new SqlConnection(_provider.GetConnectionString()))
            {
                return conn;
            }
        }
    }
}
