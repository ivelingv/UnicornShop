using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnicornShop.Application.Services.Interfaces;
using UnicornShop.Infrastructure.Repositories;

namespace UnicornShop.Infrastructure.Database.Configuration
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services, 
            string connectionString, 
            Assembly mappingAssembly)
        {
            services.AddDbContext<DatabaseContext>(opt =>
            {
                opt.UseSqlite(connectionString, config =>
                {
                    config.MigrationsAssembly(mappingAssembly.GetName().Name);
                    config.MigrationsHistoryTable("migration_history", "dbo");
                });

                opt.EnableDetailedErrors(true);
                opt.ConfigureWarnings(e =>
                {
                    e.Default(WarningBehavior.Log);
                });
            });

            return services;
        }

        public static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPriceReposity, PriceReposity>();

            return services;
        }

        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app)
        {
            var database = app.ApplicationServices.CreateScope()
                .ServiceProvider
                .GetRequiredService<DatabaseContext>();

            database.Database.Migrate();

            return app;
        }

    }
}
