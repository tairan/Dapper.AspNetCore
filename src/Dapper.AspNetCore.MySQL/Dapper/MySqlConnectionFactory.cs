using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dapper
{
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetDbConnection()
        {
            using (var conn = new MySqlConnection())
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                return conn;
            }
        }

        public IDbTransaction GetDbTransaction(IDbConnection connection)
        {
            using (var trans = connection.BeginTransaction())
            {
                return trans;
            }
        }
    }
}
