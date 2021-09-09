using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Master.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Master.WebApp.Setup
{
    public class MasterContextFactory : IDesignTimeDbContextFactory<MasterContext>
    {
        public MasterContext CreateDbContext(string[] args)
        {
            var connectionString = "server=127.0.0.1;port=6000;uid=root;pwd=1234;database=Master";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var optionBuilder = new DbContextOptionsBuilder<MasterContext>();
            optionBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(new System.Version(8, 0, 23)),
                mySqlOptions =>
                {
                    mySqlOptions.MigrationsAssembly(migrationsAssembly);
                    mySqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                });
            return new MasterContext(optionBuilder.Options);
        }
    }
}
