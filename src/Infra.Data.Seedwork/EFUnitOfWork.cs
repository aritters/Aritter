using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ritter.Infra.Data
{
    public abstract class EFUnitOfWork : DbContext, IEFUnitOfWork, ISql
    {
        private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

        protected EFUnitOfWork(DbContextOptions options) : base(options)
        {
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string environment = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);

            if (Equals(environment, "Development"))
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }

            base.OnConfiguring(optionsBuilder);
        }
    }
}
