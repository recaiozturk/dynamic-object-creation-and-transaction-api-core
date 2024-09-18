

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MicromarinCase.Repositories.Extensions
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContex>(options =>
            {

                var connectionStrings = configuration.GetSection(ConnectionStringOption.Key).Get<ConnectionStringOption>();

                options.UseSqlServer(connectionStrings!.SqlServer, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.MigrationsAssembly(typeof(RepositoryAsambly).Assembly.FullName);
                });

            });

            return services;
        }
    }
}
