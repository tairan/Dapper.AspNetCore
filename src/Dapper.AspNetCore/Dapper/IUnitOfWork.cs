using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Dapper
{
    public interface IUnitOfWork : IDisposable
    {
        Task ExecuteTransaction(Action<IDbTransaction> action);

        IDbConnection Connection { get; }
    }
}
