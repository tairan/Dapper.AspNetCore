using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace Dapper
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnectionFactory _factory;

        public UnitOfWork(IDbConnectionFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IDbConnection Connection => _factory.GetDbConnection();

        public void Dispose()
        {
            if (Connection != null)
            {
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                }

                Connection.Dispose();
            }
        }

        public Task ExecuteTransaction(Action<IDbTransaction> action)
        {
            using (var trans = Connection.BeginTransaction())
            {
                try
                {
                    action?.Invoke(trans);
                    trans.Commit();
                }
                catch (DbException)
                {
                    trans.Rollback();
                }
            }

            return Task.CompletedTask;
        }
    }
}
