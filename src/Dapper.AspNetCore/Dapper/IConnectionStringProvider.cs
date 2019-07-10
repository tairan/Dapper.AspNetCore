using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();

        string GetConnectionString(string name);
    }
}
