using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.AspNetCore.UnitTests
{
    public class TestBase
    {
        public TestBase()
        {
            var services = new ServiceCollection();
            var builder = new ConfigurationBuilder();

            var configuration = new Dictionary<string, string>
            {
                { "ConnectionStrings:DefaultConnection", "Data Source=:memory:" }
            };

            builder.AddInMemoryCollection(configuration);
            Configuration = builder.Build();
            
            services.UseDapperWithSQLite(Configuration);
            ServiceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; }

        public IConfiguration Configuration { get; }
    }
}
