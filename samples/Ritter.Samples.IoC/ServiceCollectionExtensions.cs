using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ritter.Application.Seedwork.Services;
using Ritter.Domain.Seedwork;
using Ritter.Infra.Data.Seedwork;
using Ritter.Samples.Application;
using Ritter.Samples.Infra.Data;

namespace Ritter.Samples.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, Action<RegistrationOptions> setupAction)
        {
            RegistrationOptions options = new RegistrationOptions();
            setupAction?.Invoke(options);

            Action<DbContextOptionsBuilder> dbContextOptionsBuilder = (builder) =>
            {
                var connectionString = $"FileName=ritter-db.db";
                builder.UseSqlite(connectionString);
                builder.EnableSensitiveDataLogging();
            };

            services.AddDbContext<UnitOfWork>(dbContextOptionsBuilder, ServiceLifetime.Transient);
            services.AddTransient<IQueryableUnitOfWork>(provider =>
            {
                IQueryableUnitOfWork uow = provider.GetService<UnitOfWork>();
                EnsureMigrateDatabase(uow);

                return uow;
            });
            services.FromAssembly<EmployeeRepository>().ConfigureAll<IRepository>((service, implementation) => services.AddTransient(service, implementation));
            services.FromAssembly<EmployeeAppService>().ConfigureAll<IAppService>((service, implementation) => services.AddTransient(service, implementation));

            return services;
        }

        public static RegistrationBuilder FromAssembly<TServiceSource>(this IServiceCollection services)
            where TServiceSource : class
        {
            Assembly assembly = typeof(TServiceSource).Assembly;
            return new RegistrationBuilder(assembly);
        }

        public static RegistrationBuilder ConfigureAll<TService>(this IServiceCollection services, Action<Type, Type> registrationAction)
             where TService : class
        {
            Assembly assembly = typeof(TService).Assembly;
            RegistrationBuilder builder = new RegistrationBuilder(assembly);
            builder.ConfigureAll<TService>(registrationAction);

            return builder;
        }

        private static void EnsureMigrateDatabase(IQueryableUnitOfWork uow)
        {
            var pendingMigrations = (uow as DbContext).Database.GetPendingMigrations();

            if (pendingMigrations.Any())
                (uow as DbContext).Database.MigrateAsync();
        }
    }
}
