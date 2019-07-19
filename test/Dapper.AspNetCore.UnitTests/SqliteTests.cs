using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Dapper.AspNetCore.UnitTests
{
    public class SqliteTests : TestBase
    {
        [Fact]
        public void Sqlite_ExecuteSql_Success()
        {
            var uow = ServiceProvider.GetService<IUnitOfWork>();

            uow.Connection.Execute("select 1");
        }
    }
}
