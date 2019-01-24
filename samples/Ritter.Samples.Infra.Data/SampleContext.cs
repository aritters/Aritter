using Microsoft.EntityFrameworkCore;
using Ritter.Infra.Data;
using Ritter.Samples.Domain.Aggregates.Employees;
using System.Threading.Tasks;

namespace Ritter.Samples.Infra.Data
{
    public class SampleContext : DbContext, IEFUnitOfWork, ISql
    {
        public DbSet<Employee> Employees { get; set; }

        public SampleContext(DbContextOptions<SampleContext> options) : base(options) { }

        public void BeginTransaction()
        {
            Database.BeginTransaction();
        }

        public void Commit()
        {
            Database.CommitTransaction();
        }

        public void Rollback()
        {
            Database.RollbackTransaction();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public int ExecuteCommand(string sqlCommand, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCommand, parameters);
        }
    }
}