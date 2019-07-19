using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection UseDapperWithMySQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDapper();

            services.TryAddSingleton<IConnectionStringProvider>(new ConnectionStringProvider(configuration));
            services.TryAddScoped<IDbConnectionFactory, MySqlConnectionFactory>();

            return services;
        }
    }
}
