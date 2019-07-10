using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dapper
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetDbConnection();
    }
}
