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
        public static IServiceCollection AddDapper(this IServiceCollection services)
        {
            services.TryAddScoped<IConnectionStringProvider, ConnectionStringProvider>();
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
